using System;

namespace fixmultipication
{
    class FixMultipication
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Test("42*47=1??4", -1);

        }
        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            int result = -1;
            //spliting the given equation 
            string[] str = equation.Split(new char[] { '*', '=' });
            string str1 = str[0];
            string str2 = str[1];
            string str3 = str[2];

            int tmpresult = 0;
            if (str1.Contains('?'))
            {
                int c = int.Parse(str3);
                int b = int.Parse(str2);
                //checking result values are same 
                if (c % b == 0)
                {
                    tmpresult = c / b;
                    //getting number of '?' index in string
                    result = checkIndex(tmpresult, str1);
                }

            }
            else if (str2.Contains('?'))
            {
                int c = int.Parse(str3);
                int a = int.Parse(str1);
                if (c % a == 0)
                {
                    tmpresult = c / a;
                    result = checkIndex(tmpresult, str2);
                }

            }
            else if (str3.Contains('?'))
            {
                tmpresult = int.Parse(str1) * int.Parse(str2);
                result = checkIndex(tmpresult, str3);
            }
            return result;

        }

        public static int checkIndex(int tmpres, string str)
        {
            int res = -1;
            //spliting the string into an array using the character as a delimiter
            if ((str.Split('?').Length - 1) > 1) return -1;

            int ind = str.IndexOf('?');
            string strRes = tmpres.ToString();
            if (str.Length == strRes.Length)
            {
                res = strRes[ind] - '0';
            }
            return res;
        }

    }
}

