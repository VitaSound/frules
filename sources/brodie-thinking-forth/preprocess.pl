#!/usr/bin/env perl
# Preprocess Thinking Forth LaTeX into pandoc-friendly TeX.
# Reads stdin, writes stdout.
#
# Handles tf.sty / lstforth.sty custom macros so pandoc can produce clean
# Markdown without leftover \Forth{}, \index{...}, \Code, \wepsfig*, etc.

use strict;
use warnings;

# Read raw bytes; upstream has stray Latin-1 NBSPs that would break strict UTF-8.
binmode STDIN;
binmode STDOUT;

local $/;
my $t = <STDIN>;

# Normalise stray Latin-1 bytes that occur in upstream chapter6/7:
# 0xA0 (NBSP) and 0xE9 (é) appear as bare Latin-1 in a few places.
$t =~ s/\xC2?\xA0/ /g;        # NBSP -> ASCII space
$t =~ s/(?<![\xC0-\xFD])\xE9/\xC3\xA9/g;  # bare é -> UTF-8 é

# Single-level balanced brace argument and bracket option.
# These are compiled regexes; interpolated into other regexes as sub-patterns.
my $arg  = qr/\{(?:[^{}]+|\{[^{}]*\})*\}/;
my $oarg = qr/\[[^\]]*\]/;

sub unbrace { my $s = shift; $s =~ s/^\{//; $s =~ s/\}$//; return $s; }

sub normalize_figpath {
    my $n = shift;
    $n =~ s/\.(?:eps|png|jpg|jpeg)\z//;
    return "\\includegraphics{figures/${n}.png}";
}

# ---- strip noisy metadata commands --------------------------------------
$t =~ s/\\index$arg%?//g;
$t =~ s/\\Chapmark$arg//g;
$t =~ s/\\Sectmark$arg//g;
$t =~ s/\\labelsect$arg//g;
$t =~ s/\\labelfig$arg//g;
$t =~ s/\\program$arg//g;
$t =~ s/\\fixme$arg//g;
$t =~ s/\\filename$arg//g;
$t =~ s/\\chapternum$arg//g;
$t =~ s/\\marginpar$arg//g;

# Drop \input{figN-N} (figure sub-sources we do not recurse into)
$t =~ s/\\input$arg//g;

# Drop \expandafter (no-op for textual conversion)
$t =~ s/\\expandafter\s*//g;

# ---- flatten tf.sty conditionals ----------------------------------------
# Defaults from tf.sty: eightyfourfalse, ofourfalse, tipnofalse, tipfalse,
# leofalse, thinkerfalse, latextocfalse, isbnfalse, initialfalse,
# prelimfalse, bnwfalse, splitcoverfalse, spineuptrue.
# Pick the modern (else) branch for false flags; the if branch for true.
# Nested conditionals are flattened innermost-first by iterating until stable.

my $false_flags = qr/(?:eightyfour|ofour|tipno|tip|leo|thinker|latextoc|isbn|initial|prelim|bnw|splitcover)/;
my $true_flags  = qr/(?:spineup)/;
my $no_nested   = qr/(?:(?!\\if|\\else|\\fi).)*?/s;

# Innermost-first, repeat until no change.
my $changed = 1;
while ($changed) {
    $changed = 0;
    $changed += $t =~ s/\\if$false_flags\b$no_nested\\else\b($no_nested)\\fi\b/$1/gs;
    $changed += $t =~ s/\\if$false_flags\b$no_nested\\fi\b//gs;
    $changed += $t =~ s/\\if$true_flags\b($no_nested)\\else\b$no_nested\\fi\b/$1/gs;
    $changed += $t =~ s/\\if$true_flags\b($no_nested)\\fi\b/$1/gs;
}

# ---- strip no-arg relax-like macros FIRST -------------------------------
# Both \initial / \initialb and \person are \let\...\relax by default in
# tf.sty.  Their no-arg form appears as e.g. `\expandafter\initial\Forth{}`
# — stripping them first prevents the next token from being glued to the
# macro name (which would cause pandoc to lose words like "Forth").
$t =~ s/\\initialb?(?![A-Za-z{])\s*//g;
$t =~ s/\\person(?![A-Za-z{])\s*//g;

# ---- \Forth and friends -> plain text -----------------------------------
$t =~ s/\\Forth\{\}/Forth/g;
$t =~ s/\\Forth(?![A-Za-z])/Forth/g;

# Inline text-passthrough macros: unwrap the single argument
for my $name (qw(forth forthb code person initial initialb pointto fwbox poorbf)) {
    $t =~ s/\\$name($arg)/unbrace($1)/ge;
}

# Cross-references that resolve to short text
$t =~ s/\\Chap($arg)/"Chapter " . unbrace($1)/ge;
$t =~ s/\\App($arg)/"Appendix " . unbrace($1)/ge;
$t =~ s/\\Sect($arg)/"Section " . unbrace($1)/ge;
$t =~ s/\\sect($arg)/"Section " . unbrace($1)/ge;
$t =~ s/\\Fig($arg)/"Figure " . unbrace($1)/ge;
$t =~ s/\\fig($arg)/"Figure " . unbrace($1)/ge;
$t =~ s/\\figref($arg)/unbrace($1)/ge;

# ---- figure macros ------------------------------------------------------
# Two-arg variants (label, caption). Order suffixes longest-first.
$t =~ s/\\wepsfig(?:pp|a|t|b|p)?($arg)($arg)/"\\begin{figure}\\includegraphics{" . unbrace($1) . "}\\caption{" . unbrace($2) . "}\\end{figure}"/ge;
# One-arg variants (label only)
$t =~ s/\\wepsfig(?:xx|x)($arg)/"\\begin{figure}\\includegraphics{" . unbrace($1) . "}\\end{figure}"/ge;
# texfig (input another .tex file) -> drop, no recursion
$t =~ s/\\wtexfig(?:t|b)$arg$arg//g;

# Normalize \includegraphics paths to figures/NAME.png
# Use '#' delimiter to avoid {} bracket-balance pitfalls.
$t =~ s#\\includegraphics(?:\[[^\]]*\])?\{([^}]+)\}#normalize_figpath($1)#ge;

# ---- environment renames ------------------------------------------------
# Verbatim-clone environments -> lstlisting with a language class so pandoc
# emits fenced Markdown code blocks (otherwise gfm uses indented blocks).
$t =~ s/\\begin\{(?:Code|Screen|File)\}/\\begin{lstlisting}[language=forth]/g;
$t =~ s/\\end\{(?:Code|Screen|File)\}/\\end{lstlisting}/g;

# tip / tfnote -> blockquote with a marker line
$t =~ s/\\begin\{tip\}/\n\n\\begin{quote}\n\\textbf{TIP.}\n/g;
$t =~ s/\\end\{tip\}/\n\\end{quote}\n\n/g;
$t =~ s/\\begin\{tfnote\}($arg)/"\n\n\\begin{quote}\n\\textbf{Note from " . unbrace($1) . ".}\n"/ge;
$t =~ s/\\end\{tfnote\}/\n\\end{quote}\n\n/g;

# tfquot -> plain quote
$t =~ s/\\begin\{tfquot\}/\\begin{quote}/g;
$t =~ s/\\end\{tfquot\}/\\end{quote}/g;

# interview environments -> just keep prose
$t =~ s/\\begin\{interview\*?\}//g;
$t =~ s/\\end\{interview\*?\}//g;

# verbfig{label}{caption} -> bold caption line
$t =~ s/\\verbfig($arg)($arg)/"\\textbf{Figure: }" . unbrace($2) . "\n"/ge;

# ---- layout / spacing primitives that add no semantic content -----------
$t =~ s/\\noindent//g;
$t =~ s/\\bigskip//g;
$t =~ s/\\medskip//g;
$t =~ s/\\smallskip//g;
$t =~ s/\\vspace\*?(?:\[[^\]]*\])?$arg//g;
$t =~ s/\\hspace\*?(?:\[[^\]]*\])?$arg//g;
$t =~ s/\\hfill//g;
$t =~ s/\\vfill//g;
$t =~ s/\\pagebreak[ \t]*(?:\[[^\]]*\])?//g;
$t =~ s/\\clearpage//g;
$t =~ s/\\newpage//g;
$t =~ s/\\dontbreak//g;
$t =~ s/\\blackline$arg//g;
$t =~ s/\\setcounter$arg$arg//g;
$t =~ s/\\stepcounter$arg//g;
$t =~ s/\\refstepcounter$arg//g;
$t =~ s/\\nopagebreak//g;
$t =~ s/\\samepage//g;
$t =~ s/\\sloppy//g;
$t =~ s/\\par\b//g;

# Hyphenation / kerning hints
$t =~ s/\\hy\b//g;
$t =~ s/\\penalty[ \t]*-?[0-9]+//g;
$t =~ s/\\hangindent[^ \t\n%]*//g;
$t =~ s/\\hangafter[ \t]*-?[0-9]+//g;

print $t;
