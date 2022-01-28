using System.Linq;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace FinalWorkWithFiles
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                string[] dirs = Directory.GetFiles(@"C:\Users\Alikhan_Tuyakbayev\Desktop\FinalWorkWithFiles", "*.txt");
                DirectoryInfo folderInfo = new DirectoryInfo(@"C:\Users\Alikhan_Tuyakbayev\Desktop\FinalWorkWithFiles\");
                FileInfo[] files = folderInfo.GetFiles();

                var result = dirs.OrderByDescending(x => x.Length).Take(5).ToList();
                var avg = dirs.Select(f =>
                            new FileInfo(f).Length).Average();

                int matches = Directory.GetFiles(@"C:\Users\Alikhan_Tuyakbayev\Desktop\FinalWorkWithFiles\", "A*.txt").Count();

                foreach (string item in result)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine(avg);
                Console.WriteLine("Starting from specified symbol  " + matches);

            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
           
            FileStream file;
        
            try
            {
                file = new FileStream(@"C:\Users\Alikhan_Tuyakbayev\Desktop\FinalWorkWithFiles\Test.txt", FileMode.Open);
            }
            catch (IOException exc)
            {
                Console.WriteLine(" " + exc.Message);
                return;
            }
            StreamWriter fileOut = new StreamWriter(file);
            StreamReader fileIn = new StreamReader(file);
            string line = fileIn.ReadLine();


            MatchCollection resultString = Regex.Matches(line, @"\d+");
            foreach (var item in line)
            {
                var resultString1 = Regex.Match(line, @"\d+").Value;
                Int32.Parse(resultString1);
            }
            file.Close();
            string path = @"C:\Users\Alikhan_Tuyakbayev\Desktop\FinalWorkWithFiles\";
            MatchFile(path);
            SecondVar();
        }

        static void MatchFile(string path)
        {
            DirectoryInfo info = new DirectoryInfo(path);
            var files = info.GetFiles("*.txt");
            Regex regexMathDigits = new Regex(@"\d");
            MatchCollection digits = null;
            List<string> tempData = new List<string>();
            string result = String.Empty;
            foreach (var item in files)
            {
                using (StreamReader reader = new StreamReader(item.FullName))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        tempData.Add(line.Trim());
                        line = reader.ReadLine();

                    }
                }
                foreach (var phrase in tempData)
                {
                    digits = regexMathDigits.Matches(phrase);
                }

            }

        }
        #region
        второй вариант
        #endregion
        static void SecondVar()
        {
            string[] lines = File.ReadAllLines(@"C:\Users\Alikhan_Tuyakbayev\Desktop\FinalWorkWithFiles\Test.txt");
            using (StreamWriter writer = new StreamWriter("result.txt"))
            {
                int n;
                foreach (string line in lines)
                {
                    if (int.TryParse(line, out n))
                        writer.WriteLine(n * n);
                }

                List<string> res = new List<string>();
                foreach (var item in lines)
                {
                    res.Add(item);
                }
                foreach (var item in res)

                    Console.WriteLine(item);
            }
        }


    }
}
