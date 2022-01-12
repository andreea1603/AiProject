¥
QC:\Users\strat\Documents\GitHub\SentiTweet\RepositoryLayer\Context\PostContext.cs
	namespace 	
RepositoryLayer
 
. 
Context !
{ 
public 

class 
PostContext 
: 
	DbContext (
{		 
public

 
PostContext

 
(

 
DbContextOptions

 +
<

+ ,
PostContext

, 7
>

7 8
options

9 @
)

@ A
:

B C
base

D H
(

H I
options

I P
)

P Q
{ 	
} 	
public 
DbSet 
< 
Post 
> 
Post 
{  !
get" %
;% &
set' *
;* +
}, -
public 
async 
Task 
< 
int 
> 
SaveChangesAsync /
(/ 0
)0 1
{ 	
return 
await 
base 
. 
SaveChangesAsync .
(. /
)/ 0
;0 1
} 	
internal 
Task 
AddAsync 
< 
TEntity &
>& '
(' (
TEntity( /
entity0 6
)6 7
where8 =
TEntity> E
:F G

BaseEntityH R
{ 	
throw 
new #
NotImplementedException -
(- .
). /
;/ 0
} 	
} 
} ú
\C:\Users\strat\Documents\GitHub\SentiTweet\RepositoryLayer\Interfaces\IApplicationContext.cs
	namespace 	
RepositoryLayer
 
. 

Interfaces $
{ 
public 

	interface 
IApplicationContext (
{ 
DbSet		 
<		 
Post		 
>		 
Post		 
{		 
get		 
;		 
set		  #
;		# $
}		% &
Task 
< 
int 
> 
SaveChangesAsync "
(" #
)# $
;$ %
} 
} ‹
XC:\Users\strat\Documents\GitHub\SentiTweet\RepositoryLayer\Interfaces\IPostRepository.cs
	namespace 	
RepositoryLayer
 
. 

Interfaces $
{ 
public 

	interface 
IPostRepository $
:% &
IRepository' 2
<2 3
Post3 7
>7 8
{ 
} 
}		 ½

TC:\Users\strat\Documents\GitHub\SentiTweet\RepositoryLayer\Interfaces\IRepository.cs
	namespace 	
RepositoryLayer
 
. 
RepositoryPattern +
{ 
public 

	interface 
IRepository  
<  !
TEntity! (
>( )
where* /
TEntity0 7
:8 9

BaseEntity: D
{		 
Task

 
<

 
TEntity

 
>

 
AddAsync

 
(

 
TEntity

 &
entity

' -
)

- .
;

. /
Task 
< 
TEntity 
> 
UpdateAsync !
(! "
TEntity" )
entity* 0
)0 1
;1 2
Task 
< 
TEntity 
> 
DeleteAsync !
(! "
TEntity" )
entity* 0
)0 1
;1 2
Task 
< 
IEnumerable 
< 
TEntity  
>  !
>! "
GetAllAsync# .
(. /
)/ 0
;0 1
Task 
< 
TEntity 
> 
GetByIdAsync "
(" #
Guid# '
id( *
)* +
;+ ,
} 
} ¬
^C:\Users\strat\Documents\GitHub\SentiTweet\RepositoryLayer\RepositoryPattern\PostRepository.cs
	namespace 	
RepositoryLayer
 
. 
RepositoryPattern +
{ 
public 

class 
PostRepository 
:  !

Repository" ,
<, -
Post- 1
>1 2
,2 3
IPostRepository4 C
{		 
public

 
PostRepository

 
(

 
PostContext

 )
context

* 1
)

1 2
:

3 4
base

5 9
(

9 :
context

: A
)

A B
{ 	
} 	
} 
} ˆ0
ZC:\Users\strat\Documents\GitHub\SentiTweet\RepositoryLayer\RepositoryPattern\Repository.cs
	namespace

 	
RepositoryLayer


 
.

 
RepositoryPattern

 +
{ 
public 

class 

Repository 
< 
TEntity #
># $
:% &
IRepository' 2
<2 3
TEntity3 :
>: ;
where< A
TEntityB I
:J K

BaseEntityL V
{ 
private 
readonly 
PostContext $
context% ,
;, -
public 

Repository 
( 
PostContext %
context& -
)- .
{ 	
this 
. 
context 
= 
context "
;" #
} 	
public 
Task 
< 
TEntity 
> 
Add  
(  !
TEntity! (
entity) /
)/ 0
{ 	
if 
( 
entity 
== 
null 
) 
{ 
throw 
new !
ArgumentNullException /
(/ 0
nameof0 6
(6 7
entity7 =
)= >
,> ?
$str? X
)X Y
;Y Z
} 
return 
AddAsync 
( 
entity "
)" #
;# $
} 	
public 
async 
Task 
< 
TEntity !
>! "
AddAsync# +
(+ ,
TEntity, 3
entity4 :
): ;
{ 	
await 
context 
. 
AddAsync "
(" #
entity# )
)) *
;* +
await 
context 
. 
SaveChangesAsync *
(* +
)+ ,
;, -
return   
entity   
;   
}!! 	
public## 
Task## 
<## 
TEntity## 
>## 
Delete## #
(### $
TEntity##$ +
entity##, 2
)##2 3
{$$ 	
if%% 
(%% 
entity%% 
==%% 
null%% 
)%% 
{&& 
throw'' 
new'' !
ArgumentNullException'' /
(''/ 0
nameof''0 6
(''6 7
entity''7 =
)''= >
,''> ?
$str''? X
)''X Y
;''Y Z
}(( 
return** 
DeleteAsync** 
(** 
entity** %
)**% &
;**& '
}++ 	
public,, 
async,, 
Task,, 
<,, 
TEntity,, !
>,,! "
DeleteAsync,,# .
(,,. /
TEntity,,/ 6
entity,,7 =
),,= >
{-- 	
context00 
.00 
Remove00 
(00 
entity00 !
)00! "
;00" #
await11 
context11 
.11 
SaveChangesAsync11 *
(11* +
)11+ ,
;11, -
return22 
entity22 
;22 
}33 	
public55 
async55 
Task55 
<55 
IEnumerable55 %
<55% &
TEntity55& -
>55- .
>55. /
GetAllAsync550 ;
(55; <
)55< =
{66 	
return77 
await77 
context77  
.77  !
Set77! $
<77$ %
TEntity77% ,
>77, -
(77- .
)77. /
.77/ 0
ToListAsync770 ;
(77; <
)77< =
;77= >
}88 	
public99 
Task99 
<99 
TEntity99 
>99 
GetById99 $
(99$ %
Guid99% )
id99* ,
)99, -
{:: 	
if;; 
(;; 
id;; 
==;; 
Guid;; 
.;; 
Empty;;  
);;  !
{<< 
throw== 
new== 
ArgumentException== +
(==+ ,
$str==, B
,==B C
nameof==D J
(==J K
id==K M
)==M N
)==N O
;==O P
}>> 
return?? 
GetByIdAsync?? 
(??  
id??  "
)??" #
;??# $
}@@ 	
publicAA 
asyncAA 
TaskAA 
<AA 
TEntityAA !
>AA! "
GetByIdAsyncAA# /
(AA/ 0
GuidAA0 4
idAA5 7
)AA7 8
{BB 	
returnDD 
awaitDD 
contextDD  
.DD  !
	FindAsyncDD! *
<DD* +
TEntityDD+ 2
>DD2 3
(DD3 4
idDD4 6
)DD6 7
;DD7 8
}EE 	
publicGG 
TaskGG 
<GG 
TEntityGG 
>GG 
UpdateGG #
(GG# $
TEntityGG$ +
entityGG, 2
)GG2 3
{HH 	
ifII 
(II 
entityII 
==II 
nullII 
)II 
{JJ 
throwKK 
newKK !
ArgumentNullExceptionKK /
(KK/ 0
nameofKK0 6
(KK6 7
entityKK7 =
)KK= >
,KK> ?
$strKK? X
)KKX Y
;KKY Z
}LL 
returnMM 
UpdateAsyncMM 
(MM 
entityMM %
)MM% &
;MM& '
}NN 	
publicOO 
asyncOO 
TaskOO 
<OO 
TEntityOO %
>OO% &
UpdateAsyncOO' 2
(OO2 3
TEntityOO3 :
entityOO; A
)OOA B
{PP 	
contextRR 
.RR 
UpdateRR 
(RR 
entityRR !
)RR! "
;RR" #
awaitSS 
contextSS 
.SS 
SaveChangesAsyncSS *
(SS* +
)SS+ ,
;SS, -
returnTT 
entityTT 
;TT 
}UU 	
}VV 
}WW 