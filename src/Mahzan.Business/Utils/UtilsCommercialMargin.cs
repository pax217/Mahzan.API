using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Business.Utils
{
    public static class UtilsCommercialMargin
    {
        public static decimal? GetCommercialMargin(decimal price, decimal? cost ) 
        {
            decimal? result = null;

            if (cost!=null)
            {
                result = price - cost;
            }

            return result;
        }

        public static decimal? GetCommercialMarginPercentaje(decimal price, decimal? cost)
        {
            decimal? result = null;

            if (cost != null)
            {
                decimal? commercialMargin = price - cost;

                result = ((commercialMargin * 100)/price);
            }

            return result;
        }
    }
}
