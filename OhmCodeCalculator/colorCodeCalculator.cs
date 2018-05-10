using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorCodeCalculator
{
    public interface IOhmValueCalculator
    {
            ColorCodeResult CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor);
    }


}
