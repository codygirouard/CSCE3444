﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public static class Helper
    {
        public static string CnnVal(string name)
        {
            // returning connection string
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
