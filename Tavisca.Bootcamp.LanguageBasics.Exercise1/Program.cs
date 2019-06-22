using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string [] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Test("42*47=1??4",-1);
          
        }
          private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
           Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        { 
           var val= checkString(equation);
            if(val == -1) return -1;
            
        string [] str = equation.Split(new char[] {'*','='} );
           int num,mul=1,ind=0,result1;
           string str1="";
           int ind1= equation.IndexOf('?');
           if(ind1 == -1) return -1;
           int ind2 =equation.IndexOf('=');
           if(ind1>ind2)
           {
            foreach(var c in str)
            {
            
            num = getValue(c);
            if(num>0)
            mul *= num;
            else{
                 str1=c;
               ind= str1.IndexOf('?');
            }
            }
            string s = mul.ToString();
            if(s.Length != str1.Length)
            {
                return -1;
            }
            return (s[ind]-'0');
           }

           else if(ind1 < ind2){
                int divisor = getValue(str[2]);
                int a = getValue(str[0]);
                int b =getValue(str[1]);
                if(a>0)
                {
                    if(divisor%a == 0) result1 = divisor/a;
                    else return -1;
                    ind= str[1].IndexOf('?');
                    str1=str[1];
                }
                else{
                    if(divisor%b == 0) result1 = divisor/b;
                    else return -1;
                    ind= str[0].IndexOf('?');
                     str1=str[0];
                }
            string s = result1.ToString();
            if(s.Length != str1.Length)
            {
                return -1;
            }
            return (s[ind]-'0');

           }

         return -1; 

        }
      
        public static int getValue(string str)
        {
                int val=0;
                foreach(var c in str)
                {  
                     if(c!='?')
                     {
                   int num = c - '0';
                   val =val * 10 + num; 
                     }
                    else
                       return -1;
                }
                
                return val;
        }
        public static int checkString(string equ)
        {
                int count=0;
            foreach(char c in equ)
            {
            
                if((c > '0' && c <= '9') || c == '?' || c == '*' || c == '=' )
                {
                     if(c=='?')
                    {
                        count+=1;
                        if(count>1) return -1;
                    }
                
                }
                else{
                    return -1;
                }
            }
            return 0;
        }
   
    }
}
