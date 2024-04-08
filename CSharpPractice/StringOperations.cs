using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace CSharpPractice
{
    /// <summary>
    /// Task 1,11- String operations in C#
    /// </summary>
    class StringOperations
    {
        static void Main(string[] args)
        {
            //string Concatenation/interpolation/format
            string message = "Welcome to tutorials";
            string name = "Sasi";
            string[] samplewords = { "east", "or", "west", "home", "is", "best" };
            string sampletext = string.Format("{0}{1}", message, name);
            string displaytext = $"{message + " " + name}";
            string concattext = string.Concat(samplewords);
            Console.WriteLine(sampletext);
            Console.WriteLine(displaytext);
            Console.WriteLine(concattext);

            //StringBuilder
            StringBuilder builder = new StringBuilder();
            builder.Append("StartText");
            builder.AppendLine("Long line appended here");
            builder.Replace('L','F');
            string buildertext = builder.ToString();
            Console.WriteLine(buildertext);

            stringCompare();
            Console.WriteLine("\n");
            stringTraversal();
            Console.WriteLine("\n");
            RegexPatternMatching();
            Console.ReadKey();
        }

        private static void stringCompare()
        {
            string a = "helloWo!4ls";
            string b = "helloWOR!l4s";
            string path1 = @"D:\EPAM\CSharpPractice\CSharpPractice";
            string path2 = @"D:\EPaM\cSharppractice\CsharpPRactice";

            Console.WriteLine(string.Compare(a, b, true));
            Console.WriteLine(string.Compare(path1, path2, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine(string.Compare(path1, path2, StringComparison.Ordinal));
            Console.WriteLine(string.Compare(path1, path2, StringComparison.CurrentCultureIgnoreCase));

        }

        static void stringTraversal()
        {
            string sampleText = "Peter bought some butter, but the butter was so bitter";
            string[] words = sampleText.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            string[] words1 = sampleText.Split(new string[] { "but", "bit" }, StringSplitOptions.RemoveEmptyEntries);
            string[] words2 = sampleText.Split().TakeWhile(x => x.Equals("but") || x.Equals("bit")).ToArray();
            foreach(string str in words)
                Console.WriteLine(str);

            foreach (string str2 in words1)
                Console.WriteLine(str2);

            foreach (string wrd in words2)
                Console.WriteLine(wrd);
        
        }


        //regex
        static void RegexPatternMatching()
        {
            string inputString = "To Live Life is to be in the present and not to look at past or future. To be completely at the moment without any momentary thought of other things. This to actually to live in the moment";
            string pattern1 = "to";
            string pattern2 = @".[a-z]{3,}(ent)$";
            Regex rx1 = new Regex(pattern1);
            MatchCollection matches1 = Regex.Matches(inputString, pattern1);
            MatchCollection matches2 = Regex.Matches(inputString, pattern2);

            foreach (Match match in matches1)
                Console.WriteLine(match.Value);
            foreach (Match match in matches2)
                Console.WriteLine(match.Value);
        }


    }
}
