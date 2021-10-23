
/*true [tT]*/
true	[tT][rR][uU][eE]
false 	[fF][aA][lL][sS][eE]
not 	[nN][oO][tT]
or    	[oO][rR]
and		[aA][nN][dD]

%%

[ \t]		; { /* Espacios en blanco */ }
{true}		return true;
{false}		return false;
{not}		return not;
{or}		return or;
{and}		return and;
[\n()]		return yytext[0];
.			printf("Error\n");

%%

int yywrap(void)
{
	return 0;
}
