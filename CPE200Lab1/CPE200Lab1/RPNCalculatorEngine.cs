using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public string Process(string str)
        {
            // your code here
            string first;
            string second;
            string op;
            string aws;
            Stack<string> numberstore = new Stack<string>();
            string [] NumberCo;
            NumberCo = str.Split(' ');
           
            if (NumberCo.Length < 2 ) return "E";
            for(int i=0;i< NumberCo.Length; i++)
            {
                if (!isOperator(NumberCo[i]))
                {
                     if (NumberCo[i] == "")
                    {
                        break;
                    }
                    else if (NumberCo[i] == "1/x" || NumberCo[i] == "√" || NumberCo[i] == "%")
                    {
                        if (numberstore.Count >= 1)
                        {
                            aws = unaryCalculate(NumberCo[i], numberstore.Pop(), 8);
                            numberstore.Push(aws);
                        }
                    }
                     else numberstore.Push(NumberCo[i]);
                }
                
                else if (numberstore.Count >= 2)
                {
                    op = NumberCo[i];
                    second = numberstore.Pop();
                    first = numberstore.Pop();
                    numberstore.Push(calculate(op, first, second, 4));
                }
                else return "E";
            }
             if(numberstore.Count == 1)return numberstore.Pop().ToString();
            return "E";
        }
    }
}
