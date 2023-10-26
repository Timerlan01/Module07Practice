using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module07Practice
{
    public Frac EvaluatePolynomial(Frac[] coefficients, Frac x)
    {
        Frac result = new Frac(0, 1);
        for (int i = 0; i < coefficients.Length; i++)
        {
            result = result + (coefficients[i] * Frac.Pow(x, i));
        }
        return result;
    }

}
