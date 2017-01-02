using Grades.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class Program
    {
        static void Main(string[] args)
        {
            IGradeTracker book = CreateGradeBook();

            //GetBookName(book);
            AddGrades(book);
            SaveGrades(book);
            WriteResults(book);

            //GradeBook book2 = new GradeBook();
            //book2.AddGrade(75);

            ////======CHECK IF UTILS FUNC IS WORKING
            //byte[] res = UilsFunctions.WriteAsBytes(10);
            //foreach (byte b in res)
            //{
            //    Console.WriteLine("0x{0:X2} ", b);
            //}
            ////======CHECK IF UTILS FUNC IS WORKING
            //book.NameChanged += OnNameChanged;
            ////book.NameChanged = null; //Possible with an delegate, but Impossible with the event

            //book.Name = "Scott's Grade Book";
            //book.Name = "Grade Book";
            //book.Name = null;
        }

        private static IGradeTracker CreateGradeBook()
        {
            return new ThrowAwayGradeBook();
        }

        private static void WriteResults(IGradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();

            foreach (float grade in book)
            {
                Console.WriteLine(grade);
            }

            //Console.WriteLine(book.Name);
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult(stats.Description, stats.LetterGrade);
        }

        private static void SaveGrades(IGradeTracker book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);
            }
        }

        private static void AddGrades(IGradeTracker book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
        }

        private static void GetBookName(IGradeTracker book)
        {
            try
            {
                Console.WriteLine("Enter a name");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        ////Using the DELEGATE\the EVENT
        //static void OnNameChanged(object sender, NameChangedEventArgs args)
        //{
        //    Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}");
        //}

        //static void WriteResult(string description, int result)
        //{
        //    Console.WriteLine(description + ": " + result);
        //}

        static void WriteResult(string description, string result)
        {
            Console.WriteLine($"{description}: {result}");
            //Console.WriteLine("{0}: {1:F2}", description, result);
            //Console.WriteLine("{0}: {1:C}", description, result);
        }


        static void WriteResult(string description, float result)
        {
            Console.WriteLine($"{description}: {result:F2}");
            //Console.WriteLine("{0}: {1:F2}", description, result);
            //Console.WriteLine("{0}: {1:C}", description, result);
        }
    }
}
