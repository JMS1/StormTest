using StormTest.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;


namespace StormTest.Utility
{
    public static class FormatCells
    {
        public static double RemoveMonetaryCharacters(string inputAmount)
        {
            var trimmed = inputAmount.TrimStart('$');
            return Double.Parse(trimmed);
                
        }

    }
}