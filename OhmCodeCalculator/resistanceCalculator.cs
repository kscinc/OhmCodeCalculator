using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorCodeCalculator
{
    public class ResistanceCalculator : IOhmValueCalculator
    {

        public ColorCodeResult CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
           
            OhmCalculationInput ohmInput = new OhmCalculationInput();

         
            int ohmValue = Convert.ToInt32(string.Format("{0}{1}", ohmInput.significantFigures[bandAColor], ohmInput.significantFigures[bandBColor]));
            int multiplier = ohmInput.multiplier[bandCColor];
            double tolerance = ohmInput.tolerance[bandDColor];

            
            double resultMax = (ohmValue * Math.Pow(10, multiplier) * (1 + tolerance));
            double resultMin = (ohmValue * Math.Pow(10, multiplier) * (1 - tolerance));

            
            ColorCodeResult ccResult = new ColorCodeResult();
            ccResult.MinimumResistance = FormatResistance(resultMin);
            ccResult.MaximumResistance = FormatResistance(resultMax);

           
            return ccResult;
        }


        /// <summary>
        /// Used to format large resistance values
        /// </summary>
        /// <param name="num"> resistance value </param>
        /// <returns>formatted string of a resistance value</returns>
        public string FormatResistance(double num)
        {
             
            if (num >= 100000000)
                return (num / 1000000).ToString("#,0M");

            else if (num >= 10000000)
                return (num / 1000000).ToString("0.#") + "M";
          
            else if (num >= 100000)
                return (num / 1000).ToString("#,0K");

            else if (num >= 10000)
                return (num / 1000).ToString("0.#") + "K";

            else
                return num.ToString();

        }



    }

}
