using System;
namespace FinalWorkWithFiles
{
    public class RecursOb
    {
        public void RecursObject(string str)
        {
            if (str.Length > 0)
            
                RecursObject(str.Substring(1, str.Length - 1));
            else
            return;
            System.Console.Write(str[0]);
        }
    }
}
