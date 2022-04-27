using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPR_opgave
{
    internal class Maths
    {
        public static string Test(string input)
        {
            bool parser;
            if (input.Length == 11 && input.Contains('-'))
            {
                //split input til dato og unik
                string[] spliter = input.Split('-');
                string date = spliter[0];
                string unique = spliter[1];
                bool test = Maths.Mod11(date, unique);
                //kontrollér at dato er gyldig
                parser = int.TryParse(date, out int d);
                if (test && parser && date.Length == 6)
                {
                    int day = d / 10000,
                        month = (d / 100) - (day * 100),
                        year = d - ((day * 10000) + (month * 100));
                    parser = Maths.DateCheck(day, month, year);
                    if (parser)
                    {
                        //kontrollér at unik er gyldig + hvad køn cpr tilhører
                        parser = int.TryParse(unique, out int u);
                        if (parser && unique.Length == 4)
                        {
                            if (u % 2 == 1)//mand
                            {
                                return "mand";
                            }
                            else//u % 2 == 0 => dame
                            {
                                return "kvinde";
                            }
                        }
                        else
                        {
                            return "fejl4";
                        }
                    }
                    else
                    {
                        return "fejl3";
                    }
                }
                else
                {
                    return "fejl2";
                }
            }
            else
            {
                return "fejl1";
            }
        }
        public static bool Mod11(string date, string unique)
        {
            string cpr = string.Concat(date, unique);
            char[] ar = cpr.ToCharArray();
            int[] ar2 = new int[ar.Length];
            int[] mod = { 4, 3, 2, 7, 6, 5, 4, 3, 2, 1 };
            for(int i = 0; i < 10; i++)
            {
                bool parser = int.TryParse(ar[i].ToString(), out int x); 
                if (parser)
                {
                    ar2[i] = x;
                }
                else
                {
                    return false;
                }
            }
            int sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += ar2[i] * mod[i];
            }
            /*sum = (ar2[0] * 4) + (ar2[1] * 3) + (ar2[2] * 2) + (ar2[3] * 7) + (ar2[4] * 6) 
                + (ar2[5] * 5) + (ar2[6] * 4) + (ar2[7] * 3) + (ar2[8] * 2) + (ar2[9] * 1);*/
            if (sum % 11 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool DateCheck(int day, int month, int year)
        {
            int[] lang = { 1, 3, 5, 7, 8, 10, 12 },
                kort = { 4, 6, 9, 11 };
            if (lang.Contains(month) && day <= 31)//lang måned, går til 31 dage
            {
                return true;
            }
            else if (kort.Contains(month) && day <= 30)//kort måned, går til 30 dage
            {
                return true;
            }
            else if (month == 2 && year % 4 == 0 && day <= 29)//feb skudår, 29 dage
            {
                return true;
            }
            else if (month == 2 && day <= 28)//feb normal, 28 dage
            {
                return true;
            }
            else//ingen af ovenstående virker
            {
                return false;
            }
        }
    }
}
