using System;
using System.Collections.Generic;
using System.Text;


namespace Helper.Logic
{
    class ConstantsLogic
    {
        public static string GetURL(double lat, double lon)
        {
            return string.Format(Constants.baseURL, lat, lon, Constants.token);
        }
    }
}
