: find-idx ( key addr u -- idx|-1 )
  { key# addr# u# }  -1 { idx# }
  u# 0 do
    addr# i cells + @ key# = if i to idx# then
  loop
  idx# ;

create sorted  2 , 4 , 6 , 9 , 11 ,
2 sorted 5 find-idx .
