using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment02
{
    public class TriangleSolver
    {
        private double firstSide;
        private double secondSide;
        private double thirdSide;

        public TriangleSolver()
        {
            firstSide = 1;
            secondSide = 1;
            thirdSide = 1;
        }

        public TriangleSolver(double firstSide, double secondSide, double thirdSide)
        {
            this.firstSide = firstSide;
            this.secondSide = secondSide;
            this.thirdSide = thirdSide;
        }
        public string Analyze()
        {
            if (firstSide < 1 || secondSide < 1 || thirdSide < 1)
            {
                throw new ArgumentOutOfRangeException("Invalid length to form triangle");
            }
            else
            {
                if (firstSide + secondSide <= thirdSide || firstSide + thirdSide <= secondSide || secondSide + thirdSide <= firstSide)
                {
                    return "Does not from any triangle";
                }
                else
                {
                    if (firstSide == secondSide && secondSide == thirdSide)
                    { 
                        return "Equilateral Triangle"; 
                    }
                    else if (firstSide == secondSide || firstSide == thirdSide || secondSide == thirdSide)
                    {
                        return "Isosceles Triangle"; 
                    }
                    else
                    { 
                        return "Scalene Triangle"; 
                    }
                }
            }
        }
    }
}
