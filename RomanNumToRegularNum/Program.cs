using System.Collections;

namespace RomanNumToRegularNum
{
    public class RomanNumToRegularNum
    {
        private string RomanNum;
        private int Num;
        private Dictionary<char, int> RomanChars = new Dictionary<char, int>();

        public RomanNumToRegularNum()
        {
            RomanNum = "";
            Num = 0;
            RomanChars.Add('I', 1);
            RomanChars.Add('V', 5);
            RomanChars.Add('X', 10);
            RomanChars.Add('L', 50);
            RomanChars.Add('C', 100);
            RomanChars.Add('D', 500);
            RomanChars.Add('M', 1000);
        }

        public int RomanToInt(string s)
        {
            RomanNum = s;
            // for (var i = 0; i < s.Length; ++i)
            // {
            //     Num += RomanChars[s[i]];
            // }
            if (s.Length == 1)
            {
                Num = RomanChars[s[0]];
                return Num;
            }
            
            for (var i = s.Length - 1; i >= 0; i = i-2)
            {
                if (i - 1 < 0)
                {
                    Num += RomanChars[s[i]];
                }
                else if (RomanChars[s[i]] > RomanChars[s[i-1]])
                {
                    Num += (RomanChars[s[i]] - RomanChars[s[i - 1]]);
                }
                else
                {
                    Num += (RomanChars[s[i]] + RomanChars[s[i - 1]]);
                }
            }

            return Num;
        }

        public static void Main()
        {
            var romanNum1Test = new RomanNumToRegularNum();
            var romanNum1 = "CXIV";

            Console.WriteLine($"the roman number is {romanNum1}");
            Console.Write("the regular number is ");
            Console.WriteLine(romanNum1Test.RomanToInt(romanNum1));
        }
    }
}