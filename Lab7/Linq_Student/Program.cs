using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Student
{
    internal class Program
    {
        
        public class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int ID { get; set; }
            public List<int> Scores;
        }

        static List<Student> students = new List<Student>
        {
             new Student {FirstName="Svetlana", LastName="Omelchenko", 
                 ID=111, Scores= new List<int> {97, 92, 81, 60}},
             new Student {FirstName="Claire", LastName="O’Donnell", 
                 ID=112, Scores= new List<int> {75, 84, 91, 39}},
             new Student {FirstName="Mikhael", LastName="Garcia",
                 ID=112, Scores= new List<int> {96, 75, 88, 40}}
        };

        static void Main(string[] args)
        {
            IEnumerable<Student> studentQuery = 
                from student in students 
                where student.Scores[0]>90 && student.Scores[3]< 80
                orderby student.Scores[0] descending
                select student;

            foreach (Student student in studentQuery)
            {
                Console.WriteLine("{0}, {1} {2}", 
                    "1.Student "  +
                    student.LastName,  student.FirstName,  "has " + student.Scores[0] + " balls" + "\n");
            }

            var studentQuery2 =
                from student in students
                group student by student.LastName[0];

            
            foreach (var studentGroup in studentQuery2)
            {
                Console.WriteLine("2.Student List group by letter:" + " " + studentGroup.Key);
                foreach (Student student in studentGroup)
                {
                    Console.WriteLine("  {0}, {1}", 
                        student.LastName, student.FirstName);
                }
                Console.WriteLine("\n");
            }

            var studentQuery3 =
                from student in students
                group student by student.LastName[0]; 
            foreach (var groupOfStudents in studentQuery3)
            {
                Console.WriteLine("3.Student List group by letter:" + " " + groupOfStudents.Key);
                foreach (var student in groupOfStudents)
                {
                    Console.WriteLine(" {0}, {1}",
                        student.LastName, student.FirstName);
                }
                Console.WriteLine("\n");
            }

            var studentQuery4 =
                from student in students
                group student by student.LastName[0] into studentGroup
                orderby studentGroup.Key
                select studentGroup;
            foreach (var studentGroup in studentQuery4)
            {
                Console.WriteLine("4.Student List group by letter:" + " " + studentGroup.Key);
                foreach (var student in studentGroup)
                {
                    Console.WriteLine(" {0}, {1}",
                        student.LastName, student.FirstName);
                }
                Console.WriteLine("\n");
            }

            var studentQuery5 =
                from student in students
                let totalScore = student.Scores[0] + student.Scores[1] +
                    student.Scores[2] + student.Scores[3]
                where totalScore / 4 < student.Scores[0]
                select student.LastName + " " + student.FirstName;

            Console.WriteLine("5.Student with average score < first score:");
            foreach (string s in studentQuery5)
            {
                Console.WriteLine(" " + s);
            }
            Console.WriteLine("\n");

            var studentQuery6 =
                from student in students
                let totalScore = student.Scores[0] + student.Scores[1] +
                    student.Scores[2] + student.Scores[3]
                select totalScore;

            double averageScore = studentQuery6.Average();
            Console.WriteLine("6.Class averige score = {0}", averageScore + "\n");

            IEnumerable<string> studentQuery7 =
                from student in students
                where student.LastName == "Garcia"
                select student.FirstName;

            Console.WriteLine("7.The Garcias in the class are:");
            foreach (string s in studentQuery7) 
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("\n");

            var studentQuery8 =
                from student in students
                let totalScore = student.Scores[0] + student.Scores[1] +
                    student.Scores[2] + student.Scores[3]
                where totalScore > averageScore
                select new { id = student.ID,  score = totalScore};

            foreach (var item in studentQuery8)
            {
                Console.WriteLine("8.Student ID: {0}, Score: {1}", item.id, item.score);
            }
        }

    }
}
