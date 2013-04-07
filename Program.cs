using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            List<long> times = new List<long>();
            StreamReader file = new StreamReader(args[0]);
            
            while ((line = file.ReadLine()) != null)
            {
                Solver solver = new Solver(line);
                Console.WriteLine("Solving: \n" + solver.ToString());
                Stopwatch sw = new Stopwatch();
                sw.Restart();
                solver.Solve();
                sw.Stop();
                times.Add(sw.ElapsedMilliseconds);
                Console.WriteLine("Solved: \n" + solver.ToString() + "\nin " + sw.ElapsedMilliseconds + " miliseconds\n");
            }

            file.Close();

            Console.WriteLine("");
            Console.WriteLine("Times:");

            foreach (long time in times.OrderBy(x => x))
            {
                Console.WriteLine(time);
            }
            Console.WriteLine("Medium: " + times.Sum(x => x) / times.Count);

            Console.ReadKey();
        }

        private static void Convert(string inFile)
        {
            StreamReader file = new StreamReader(inFile);
            StreamWriter sw = new StreamWriter(new FileStream(@"c:\temp\aaa.txt", FileMode.CreateNew));
            string fullLine = "";
            string line;
            while ((line = file.ReadLine()) != null)
            {
                if (!line.StartsWith("Grid"))
                {
                    fullLine += line;
                }
                else
                {
                    sw.WriteLine(fullLine);
                    fullLine = "";
                }
            }
            file.Close();
            file.Close();
        }
    }
}
