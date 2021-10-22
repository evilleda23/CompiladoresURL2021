%{
	#include <ctype.h>
	#include <stdio.h>
	#define YYSTYPE double /* double type for Yacc stack */
	
	extern int yylex();
	void yyerror(char *msg);
%}

%token true
%token false
%token not
%token or 
%token and

%%
lines	: lines bexpr '\n' { $2 ? printf("true(%g)\n", $2) :printf("false(%g)\n", $2)  ;}
		| lines '\n'
		| /* empty */
		;
		
bexpr	: bexpr or bterm	{ $$ = $1 || $3 }
		| bterm
bterm 	: bterm and bfactor { $$ = $1 && $3 }
		| bfactor
		
bfactor : not bfactor {$$ = ! $2}
		| '(' bexpr ')' {$$ = $2}
		| true {$$ = 1}
		| false {$$ = 0}

%% 	

#include "lex.yy.c"

void yyerror(char *msg){
	printf("Error de sintaxis");
	exit(0);
}

int main(){
	yyparse();
	return 0;
}