﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Resources;
using System.Reflection;

namespace SuhovTask
{
    public static class Dictionary
    {
        private static string _language = null;

        private static ResourceManager _res;

        private static bool handleChange = true;

        public static string Language
        {
            get
            {
                if (_language == null)
                    _language = ConfigurationManager.AppSettings["Language"];
                return _language;
            }
            set 
            {
                handleChange = false;
                _language = value;
            }
        }

        private static ResourceManager Resource
        {
            get
            {
                if ((_res == null) || (!handleChange))
                {
                    _res = new ResourceManager("SuhovTask.LanguageFiles." + Language, Assembly.GetExecutingAssembly());
                    handleChange = true;
                };
                return _res;
            }
        }

        public static string Get(string key)
        {
            ResourceManager res = Resource;

            return res.GetString(key);
            
        }
    }
}
