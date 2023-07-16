using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyShopProject.Models
{
    public class Regexp
    {
        //Проверка на валидность логина
        public static bool IsLoginValided(string log)
        {
            bool result = true;
            // Массив символов, которые не должны быть в логине
            string[] symbols = new string[]
            {
                "!",
                "@",
                "#",
                "%",
                "&",
                "=",
                "<",
                ">",
                "/",
                ",",
                "{",
                "}",
                "~",
                ";",
                ":",
                "'",
                "№"
            };

            if (string.IsNullOrEmpty(log) || log.Length > 15)
            {
                result = false;
            }
            
            for (int i = 0; i < symbols.Length; i++)
            {
                Regex regex = new Regex(symbols[i]);
                MatchCollection match = regex.Matches(log);
                if (match.Count > 0)
                {
                    result = false;
                    break;
                }
            }
            return result;
            

            
        }
        //Проверка на валидность емайла
        public static bool IsEmailValided(string email)
        {
            if (string.IsNullOrEmpty(email) || email.Length > 20)
                return false;

            Regex regex = new Regex(@"@");
            MatchCollection matchCollection = regex.Matches(email);

            if (matchCollection.Count > 0)
                return false;
            else
                return true;

        }

    }
}
