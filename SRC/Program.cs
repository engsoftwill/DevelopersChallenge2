using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Windows;
using System.Xml.Xsl;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics.Tracing;

namespace SRC
{
    class Program
    {
        static void Main(string[] args)
        {
            var path1 = @"C:\Users\willi\Dropbox\Nibo\DevelopersChallenge2-master\OFX\extrato1.ofx";            //find the file 1
            var path2 = @"C:\Users\willi\Dropbox\Nibo\DevelopersChallenge2-master\OFX\extrato2.ofx";            //find the file 2
            
            List<string> lines1 = ReadLines(path1);
            List<string> lines2 = ReadLines(path2);
            var final = lines1;
            
                int counter = lines2.Count-1;
                var finallast4 = final.TakeLast(4);
            foreach (var testline2 in lines2)
            {
                
                var testlinefinal = lines2.ElementAt(counter);                                                  //execute 4 tests in TRNTYPE DTPOSTED TRNAMT MEMO all of them must match to consider that was a duplicity operation
                if (finallast4.Contains(lines2.ElementAt(counter)))
                    if (finallast4.Contains(lines2.ElementAt(counter + 1)))
                        if (finallast4.Contains(lines2.ElementAt(counter + 2)))
                            if (finallast4.Contains(lines2.ElementAt(counter + 3)))
                            {
                                final.RemoveRange(final.Count-4,4);                                             //remove the duplicity operation and test the next one
                                finallast4 = final.TakeLast(4);
                            }
                    counter -= 1;
            }
            final.AddRange(lines2);
            Console.WriteLine(final);                                                                           //final contains all transactions data from files, this program can be called and return this variable with this information
            //var pathdestiny4 = @"C:\Users\willi\Dropbox\Nibo\DevelopersChallenge2-master\OFX\teste1.csv";     //alternative path to save the data 
            //WriteFiles(final, pathdestiny4);                                                                  //we can save this file in the specified path above
            static void WriteFiles(List<string> Lines , string Path)                                            //method to write a file
            {
                using (StreamWriter sr = new StreamWriter(Path))
                {
                    foreach (var line in Lines)
                    {
                        sr.WriteLine(line);
                    }
                    sr.Flush();
                    sr.Close();
                }
            }
            
            static List<string> ReadLines(string pathOfxFile)
            {
                using (var reader1 = new StreamReader(pathOfxFile)) 
                {
                    List<string> aux = new List<string>();
                    List<string> options = new List<string> { "<TRNTYPE", "<DTPOSTED", "<TRNAMT", "<MEMO" };
                    string lines;
                    while (!reader1.EndOfStream)                                                             //inside the loop each  line will be read, separated and saved insine aux
                    {
                        lines = reader1.ReadLine();
                        string[] spliter = Regex.Split(lines, ">");
                        if (options.Contains(spliter[0]))
                        {
                            aux.Add(lines);
                        }
                    }
                    return aux;                                                                              //when this method is called it will return the data of files
                }
            }
        }
    }
}


// I did not finish the web service until Monday 9:00 but I have the begging of implementation
//I was planning to use the ORM of Entity Framework and send this information in a Asp.NET API Application
