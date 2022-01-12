Æ
RC:\Users\strat\Documents\GitHub\SentiTweet\DomainLayer\Models\Common\BaseEntity.cs
	namespace 	
DomainLayer
 
. 
Models 
{ 
public 

abstract 
class 

BaseEntity $
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
} 
}		 è
EC:\Users\strat\Documents\GitHub\SentiTweet\DomainLayer\Models\Post.cs
	namespace 	
DomainLayer
 
. 
Models 
{ 
public 

class 
Post 
: 

BaseEntity  
{ 
public 
string 
content 
{ 
get  #
;# $
set% (
;( )
}* +
public 
string 
	sentiment 
{  !
get" %
;% &
set' *
;* +
}, -
} 
} 