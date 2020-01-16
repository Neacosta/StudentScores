using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace StudentScores
{
    public class StudentDB
    {
        
        private const string directory = @"C:\Users\nelso\Downloads\";
        private const string path = directory + "StudentScores.txt";

        
        public static IList<Student> GetStudents()
        {
            // if directory doesn't exist, create it
            if (!Directory.Exists(directory))
            {

                Directory.CreateDirectory(directory);


            }
            //object for an input stream for a text file

            var textIn = new StreamReader(
                new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read));

            var students = new List<Student>();


            while (textIn.Peek() != -1)
            {
                var row = textIn.ReadLine();
                var student = new Student(row);
                students.Add(student);

            }

            textIn.Close();

            return students;
        }
         public static void SaveStudents(IList<Student> students)
        {
            var textOut = new StreamWriter
                (new FileStream(path, FileMode.Create, FileAccess.Write));

            foreach (var student in students)
            {
                textOut.WriteLine(student.ToString());
            }
            textOut.Close();
         }
    }
}
