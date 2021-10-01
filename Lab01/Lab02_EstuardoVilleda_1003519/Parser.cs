using System;
using System.Collections.Generic;
using System.Text;

namespace Lab01_EstuardoVilleda_1003519
{
    class Parser
    {
        Scanner _scanner;
        Token _token;

        private double E() 
        {
       
            switch (_token.Tag)
            {
                
                case TokenType.Lparen:
                case TokenType.Number:
                case TokenType.Minus:                  
                    return T() + EP();

                default:
                    return 0;

            }
        }

        private double EP() 
        {
            double t = 0; double ep = 0;
            switch (_token.Tag)
            {

                case TokenType.Plus:
                    Match(_token.Tag);
                return T() + EP();

                case TokenType.Minus:
                    Match(_token.Tag);
                    return -T() + EP();

                //Se contempla el epsilon
                default:
                    return 0;
                   
            }
        }

        private double T() 
        {
            return N() * F() * TP();

        }

        private double N()
        {
            switch (_token.Tag)
            {
                case TokenType.Minus:
                    Match(_token.Tag);
                    return -N();

                default:
                    return 1;

            }
        }

        private double TP()
        {
            switch (_token.Tag)
            {
                case TokenType.Star:
                    Match(_token.Tag);
                    return N() * F() * TP();
 
                case TokenType.Div:
                    Match(_token.Tag);
                    return N() *(( 1 / F()) * TP());

                //Se contempla el epsilon
                default:
                    return 1;
                    
            }
        }

        private double F()
        {
           
            double num = 0;
            switch (_token.Tag)
            {

                case TokenType.Lparen:
                    Match(TokenType.Lparen);
                    num= E();
                    Match(TokenType.Rparen);
                    return num;

                case TokenType.Number: 
                    return double.Parse(FP(_token.Value.ToString()));

                default:
                    return 0;
            }


        }

        private string FP(string number)
        {
            switch (_token.Tag)
            {
                case TokenType.Number:
                    Match(_token.Tag);
                    return FP(number + _token.Value);

                default:
                    return (number);
                  
            }
             
        }

        private void Match(TokenType tag) 
        {
            if (_token.Tag == tag)
            {
                _token = _scanner.GetToken();
            }
            else
            {
                throw new Exception("Syntax Error");
            }
        }
        public double Parse(string regexp) {
            _scanner = new Scanner(regexp + (char)TokenType.EOF);
            _token = _scanner.GetToken();

            switch (_token.Tag)
            {             
                case TokenType.Lparen:                                                              
                case TokenType.Number:
                case TokenType.Minus:
                    return E();                 
            }

            Match(TokenType.EOF);
            return 0;
        }
    }
}
