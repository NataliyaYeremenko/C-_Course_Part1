namespace Yeremenko_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lecturer lec1 = new Lecturer ("Sam", "Don", new DateOnly(1960, 9, 28), "Kyiv");
            Lecturer lec2 = new Lecturer("Lidia", "Don", new DateOnly(1968, 07, 01), "Kyiv");
            Lecturer lec3 = new Lecturer("Sonya", "Dast", new DateOnly(1976, 11, 11));

            Student std1 = new Student("Jhon", "Black", new DateOnly(1998, 11, 08), "Lviv");
            Student std2 = new Student("Katy", "Sun", new DateOnly(1998, 07, 03), "Kharkiv");
            Student std3 = new Student("Oleh", "Morn", new DateOnly(1998, 01, 01), "Lviv");
            Student std4 = new Student("Tom", "Soyer", new DateOnly(1990, 8, 23), "Kyiv");
            Student std5 = new Student("Taya", "Soyer", new DateOnly(1990, 8, 23), "Kyiv");
            Student std6 = new Student("Tamara", "Soyer", new DateOnly(1990, 8, 23), "Kyiv");
            Student std7 = new Student("Lev", "Pat", new DateOnly(1993, 7, 19));

            Course course1 = new Course("Discrete Math", lec1, 2, 25);
            Course course2 = new Course("Biology", lec2, 4, 25);
            Course course3 = new Course("Theory of Algorithm", lec1, 2, 25);
            Course course4 = new Course("OOP", lec1, 2, 25);
            Course course5 = new Course("Information technology", lec1, 2, 25);
            Course course6 = new Course("Techno", lec1, 2, 25);
            Course course7 = new Course("Techno", lec1, 2, 25);

            lec1.Print();

            Console.WriteLine("\n ================== Trying to Remove not enrolled Student from Course ================== "); 
            course1.RemoveStudentFromCourse(std1);

            Console.WriteLine("\n ================== Add Students to Course ================== ");
            Console.WriteLine("\n *** Before adding ***");
            course1.Print();
            Console.WriteLine("\n *** After adding ***");

            course1.AddStudentToCourse(std1);
            course1.AddStudentToCourse(std2);
            course1.AddStudentToCourse(std3);
            course1.AddStudentToCourse(std2);
            course1.AddStudentToCourse(std7);
            course1.Print();
            std1.Print();
            std2.Print();
            std3.Print();

            Console.WriteLine("\n ================== Add Course to Student Course List ================== ");
            Console.WriteLine("\n *** Before adding ***");
            course2.Print();
            std1.Print();
            Console.WriteLine("\n *** After adding ***");
            std1.AddStudentToCourse(course2);
            std1.Print();
            course2.Print();

            Console.WriteLine("\n ================== Delete Student from Course ================== ");
            Console.WriteLine("\n *** Before deleting ***");
            course1.Print();
            std1.Print();
            Console.WriteLine("\n *** After deleting ***");
            course1.RemoveStudentFromCourse(std1);
            course1.Print();
            std1.Print();

            course2.AddStudentToCourse(std4);
            course2.AddStudentToCourse(std5);
            course2.AddStudentToCourse(std6);

            Console.WriteLine("\n ================== Delete Course from student's Course List ================== ");
            Console.WriteLine("\n *** Before deleting ***");
            course2.Print();
            std4.Print();
            Console.WriteLine("\n *** After deleting ***");
            std4.RemoveStudentFromCourse(course2);
            course2.Print();
            std4.Print();

        }
    }
}