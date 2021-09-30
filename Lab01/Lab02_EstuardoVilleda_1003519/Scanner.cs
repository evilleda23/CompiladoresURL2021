using System;
using System.Collections.Generic;
using System.Text;

namespace Lab01_EstuardoVilleda_1003519
{
    public class Scanner
    {
      

        private string _regexp = "";
        private int _index = 0;
        public Scanner(string regexp) 
        {
            _regexp = regexp + (char)TokenType.EOF;
            _index = 0;
        }
        public Token GetToken() 
        {
            Token result = new Token() { Value = (char)0 };
            bool tokenFound = false;

            while (!tokenFound) 
            {
                char peek = _regexp[_index];
                  
                        while (char.IsWhiteSpace(peek))
                        {
                            _index++;
                            peek = _regexp[_index];
                        }

                        switch (peek)
                        {                              
                                case (char)TokenType.Lparen:
                                case (char)TokenType.Rparen:
                                case (char)TokenType.Star:
                                case (char)TokenType.Div:
                                case (char)TokenType.Plus:
                                case (char)TokenType.Minus:
                                case (char)TokenType.EOF:
                                tokenFound = true;
                                result.Tag = (TokenType)peek;
                                    break;
                                case (char)48:
                                case (char)49:
                                case (char)50:
                                case (char)51:
                                case (char)52:
                                case (char)53:
                                case (char)54:
                                case (char)55:
                                case (char)56:
                                case (char)57:
                                    tokenFound = true;
                                    result.Tag = TokenType.Number;
                                    result.Value = peek;
                                    break;
                                default:
                                throw new Exception("Lex Error");
                           
                        }
                
                _index++;
                
            }//end while
 
            return result;
        }


    }
}
