using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetRunRate.RateCalculator
{
    class Rate_Calculator
    {
        
        private double num1 ,num2;
        string[] numberstorer = new string[2];
        private string temp;
        public double calculate(int runscore,int rungive, double overface, double overgive)
        {
            double output=0.0;
          overface =  pointchecker(overface);
            overgive = pointchecker(overgive);
            num1 = (runscore / overface);
            num2 = (rungive / overgive);
            output = num1 - num2;

            return output;
        }
        private double pointchecker(double num)
        { temp = Convert.ToString(num);

            if(temp.Contains('.'))
            {
                double i=0;
                string temp1, temp2;
               numberstorer= temp.Split('.');
                temp1 = numberstorer[0];
                temp2 = numberstorer[1];
                i = Convert.ToDouble(temp2);
                temp2 = Convert.ToString((i / 6));
                numberstorer = temp2.Split('.');
                temp2 = '.'+ numberstorer[1];
                temp = temp1 + temp2;
                num = Convert.ToDouble(temp);
            }
            return num;
           
        }
    }
}
