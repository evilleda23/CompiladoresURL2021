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
                    throw new Exception("Syntax Error");
                   

            }
        }

        private double EP() 
        {
       
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
                    return 0; //se devuelve 0 para que no afecte las sumas
                   
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
                    return N() * ((1 / F()) * TP());

                //Se contempla el epsilon
                default:
                    return 1; //se devuelve uno para que no afecte el resultado de la multiplicacion

            }
        }

        private double F()
        {
           
            double num;
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
                        throw new Exception("Syntax Error");
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
            return E(); //si ya no hay tokens, no devuelve nada, si hay token y no es valido, devuelve sintax error
        }
    }
}
