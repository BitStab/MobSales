using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MobSales.Logic.DataService
{
    public class SalesService
    {
        private static WebService.Test instance = null;


        public static WebService.Test Instance
        {
            get
            {
                if (instance == null)
                    throw new ArgumentNullException("SalesService: service instance");
                return instance;
            }
            set { instance = value; }
        }
    }
}