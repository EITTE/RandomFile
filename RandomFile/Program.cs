using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace RandomFile
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                string curFolder = Environment.CurrentDirectory;
                //totalSize is in MB
                int totalSize = Int32.Parse(args[0]) * 1024;
                int currentSize = 0;
                while (currentSize < totalSize)
                {
                    Random ran = new Random();
                    //size is in Byte
                    int size = ran.Next(1024, 52428800);
                    int year = ran.Next(16) + 2000;
                    int month = ran.Next(12) + 1;
                    int day = ran.Next(27) + 1;
                    int hour = ran.Next(24);
                    int min = ran.Next(60);
                    int sec = ran.Next(60);
                    int only = ran.Next(100, 999);
                    string fileName = year.ToString() + '.' + month.ToString() + '.' + day.ToString() + '.' +
                                      hour.ToString() + '.' + min.ToString() + '.' + sec.ToString() + '.' + only.ToString();
                    Console.WriteLine(fileName + "      " + size / 1048576 + "MB");
                    string absFileName = curFolder + "\\" + fileName + ".txt";

                    StreamWriter file = new StreamWriter(absFileName);
                    int loop = size / 10;
                    for (int i = 0; i < loop; i++)
                    {
                        file.Write(ran.Next(1000000000, 2147483647));
                    }
                    file.Close();

                    //int loop = (size / 1024) * 1000; 
                    //Byte[] b = new Byte[loop];
                    //ran.NextBytes(b);
                    //File.WriteAllBytes(absFileName, b);

                    DateTime date = new DateTime(year, month, day, hour, min, sec);
                    File.SetCreationTime(absFileName, date);
                    File.SetLastAccessTime(absFileName, date);
                    File.SetLastWriteTime(absFileName, date);
                    currentSize += size / 1048576;
                }

            }
            else if ( args.Length == 0)
            {
                Console.WriteLine("Usage: randomfile [data size in GB]");
                Console.WriteLine("Example: randomfile 2");
            }
            else
            {
                Console.WriteLine("INPUT ERROR");
            }
            
        }
    }
}
