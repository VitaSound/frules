> Source: https://gforth.org/manual/Installing-gforth_002eel.html

<span id="Installing-gforth_002eel"></span>

<div class="header">

Next: [Emacs Tags](Emacs-Tags.html#Emacs-Tags), Previous: [Emacs and Gforth](Emacs-and-Gforth.html#Emacs-and-Gforth), Up: [Emacs and Gforth](Emacs-and-Gforth.html#Emacs-and-Gforth)   \[[Contents](index.html#SEC_Contents "Table of contents")\]\[[Index](Word-Index.html#Word-Index "Index")\]

</div>

-----

<span id="Installing-gforth_002eel-1"></span>

### 12.1 Installing gforth.el

<span id="index-_002eemacs"></span> <span id="index-gforth_002eel_002c-installation"></span>

To make the features from `gforth.el` available in Emacs, add the following lines to your `.emacs` file:

<div class="example">

``` example
(autoload 'forth-mode "gforth.el")
(setq auto-mode-alist (cons '("\\.fs\\'" . forth-mode) 
                auto-mode-alist))
(autoload 'forth-block-mode "gforth.el")
(setq auto-mode-alist (cons '("\\.fb\\'" . forth-block-mode) 
                auto-mode-alist))
(add-hook 'forth-mode-hook (function (lambda ()
   ;; customize variables here:
   (setq forth-indent-level 4)
   (setq forth-minor-indent-level 2)
   (setq forth-hilight-level 3)
   ;;; ...
)))
```

</div>
