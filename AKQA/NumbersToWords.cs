
namespace AKQA
{
    public static class NumbersToWords
    {
        public static string ConvertToWords(decimal value)
        {
            string input = value.ToString();

            // take decimal part of input. convert it to word. add it at the end of method.
            string decimals = "";

            if (input.Contains("."))
            {
                decimals = input.Substring(input.IndexOf(".") + 1);
                // remove decimal part from input
                input = input.Remove(input.IndexOf("."));
            }

            // Convert input into words. save it into strWords
            string strWords = GetWords(input);

            if (decimals.Length > 2)
                throw new System.ArgumentException("Invalid Price");

            if (decimals.Length > 0)
            {
                // if there is any decimal part convert it to words and add it to strWords.
                strWords += " DOLLARS AND " + GetWords(decimals) + " CENTS";
            }
            else
            {
                strWords += " DOLLARS";
            }

            return strWords.ToUpper();
        }

        private static string GetWords(string input)
        {
            // these are seperators for each 3 digit in numbers. you can add more if you want convert beigger numbers.
            string[] seperators = { "", " Thousand ", " Million ", " Billion " };

            // Counter is indexer for seperators. each 3 digit converted this will count.
            int i = 0;

            string strWords = "";

            while (input.Length > 0)
            {
                // get the 3 last numbers from input and store it. if there is not 3 numbers just use take it.
                string _3digits = input.Length < 3 ? input : input.Substring(input.Length - 3);

                // remove the 3 last digits from input. if there is not 3 numbers just remove it.
                input = input.Length < 3 ? "" : input.Remove(input.Length - 3);

                int num = int.Parse(_3digits);

                // Convert 3 digit number into words.
                _3digits = GetWord(num);

                // apply the seperator.
                _3digits += seperators[i];
                
                // since we are getting numbers from right to left then we must append resault to strWords like this.
                strWords = _3digits + strWords;

                // 3 digits converted. count and go for next 3 digits
                i++;
            }
            return strWords;
        }

        // your method just to convert 3digit number into words.
        private static string GetWord(int num)
        {
            string[] Ones =
            {
                "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",
                "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"
            };

            string[] Tens = { "Ten", "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

            string word = "";

            if (num > 99 && num < 1000)
            {
                int i = num / 100;
                word = word + Ones[i - 1] + " Hundred ";
                num = num % 100;
            }

            if (num > 19 && num < 100)
            {
                int i = num / 10;
                word = word + Tens[i - 1] + " ";
                num = num % 10;
            }

            if (num > 0 && num < 20)
            {
                word = word + Ones[num - 1];
            }

            return word;
        }
    }
}