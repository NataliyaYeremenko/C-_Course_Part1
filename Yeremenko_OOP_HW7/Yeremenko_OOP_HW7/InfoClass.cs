using System;
using System.Collections.Generic;
using System.Linq;

namespace Yeremenko_OOP_HW7
{
    public static class InfoClass
    {
        public static List<Student> _students = new List<Student>();
        public static List<Course> _courses = new List<Course>();
        public static List<Lecturer> _lecturers = new List<Lecturer>();
        public static void PrintFullLecturersList()
        {
            if (_lecturers.Count != 0)
            {
                Console.WriteLine($"\n *** Full Lecturers List ***\n");
                foreach (var lec in _lecturers)
                {
                    lec.PrintInfo();
                }
            }
            else { Console.WriteLine("The Lectuters List is empty"); }
        }
        public static void PrintFullCoursesList()
        {
            if (_courses.Count != 0)
            {
                Console.WriteLine($"\n *** Full Courses List ***\n");
                foreach (var cor in _courses)
                {
                    cor.PrintInfo();
                }
            }
            else { Console.WriteLine("The Courses List is empty"); }
        }
        public static void PrintFullStudentsList()
        {
            if (_students.Count != 0)
            {
                Console.WriteLine($"\n *** Full Students List ***\n");
                foreach (var st in _students)
                {
                    st.PrintInfo();
                }
            }
            else { Console.WriteLine("The Students List is empty"); }
        }
        private static List<Student> FilteredStudentsList(string filter)
        {
            return _students.Where(x => x.Name.Contains(filter) || 
                                        x.LastName.Contains(filter) || 
                                        x.City.Contains(filter) ||
                                        x.GetEnrolledCoursesNames().Contains(filter)).ToList();
        }
        private static List<Lecturer> FilteredLecturersList(string filter)
        {
            return _lecturers.Where(x => x.Name.Contains(filter) ||
                                                        x.LastName.Contains(filter) ||
                                                        x.City.Contains(filter) ||
                                                        x.GetEnrolledCoursesNames().Contains(filter)).ToList();
        }
        private static List<Course> FilteredCoursesList(string filter)
        {
            return _courses.Where(x => x.CourseName.Contains(filter) ||
                                                       x.Lecturer.Name.Contains(filter) ||
                                                       x.GetEnrolledStudentsNames().Contains(filter)).ToList();
        }
        private static void PrintFilteredStudentsList (List<Student> std, out bool usingResult)
        {
            usingResult = false;
            if (std.Count != 0)
            {
                usingResult = true;
                foreach (var s in std)
                {
                    s.PrintInfo();
                }
            }
        }
        private static void PrintFilteredLecturersList(List<Lecturer> lec, out bool usingResult)
        {
            usingResult = false;
            if (lec.Count != 0)
            {
                usingResult = true;
                foreach (var l in lec)
                {
                    l.PrintInfo();
                }
            }
        }
        private static void PrintFilteredCoursesList(List<Course> cor, out bool usingResult)
        {
            usingResult = false;
            if (cor.Count != 0)
            {
                usingResult = true;
                foreach (var c in cor)
                {
                    c.PrintInfo();
                }
            }
        }
        private static void PrintFilteredList(int listNumber, string filter, out bool usingResult)
        {
            usingResult = false;
            bool res1, res2, res3;
            switch (listNumber)
            {
                case 1: PrintFilteredStudentsList(FilteredStudentsList(filter), out usingResult); break;
                case 2: PrintFilteredLecturersList(FilteredLecturersList(filter), out usingResult); break;
                case 3: PrintFilteredCoursesList(FilteredCoursesList(filter), out usingResult); break;
                case 4: PrintFilteredStudentsList(FilteredStudentsList(filter), out res1); 
                        PrintFilteredLecturersList(FilteredLecturersList(filter), out res2); 
                        usingResult = res1 || res2; break;
                case 5: PrintFilteredLecturersList(FilteredLecturersList(filter), out res1); 
                        PrintFilteredCoursesList(FilteredCoursesList(filter), out res2); 
                        usingResult = res1 || res2; break;
                case 6: PrintFilteredStudentsList(FilteredStudentsList(filter), out res1); 
                        PrintFilteredCoursesList(FilteredCoursesList(filter), out res2); 
                        usingResult = res1 || res2; break;
                case 7: PrintFilteredStudentsList(FilteredStudentsList(filter), out res1);
                        PrintFilteredLecturersList(FilteredLecturersList(filter), out res2);
                        PrintFilteredCoursesList(FilteredCoursesList(filter), out res3); 
                           usingResult = res1 || res2 || res3; break;
            }
        }

        public static void GetFilteredList()
        {
            int listNumber = 1;
            while (listNumber != 0)
            {
                Console.Write("\nChoose the filtration condition:\n" +
                    "\t1 - filtering for Students List only;\n" +
                    "\t2 - filtering for Lecturers List only;\n" +
                    "\t3 - filtering for Courses List only;\n" +
                    "\t4 - filtering for Students and Lecturers Lists;\n" +
                    "\t5 - filtering for Lecturers and Courses Lists;\n" +
                    "\t6 - filtering for Students and Courses Lists;\n" +
                    "\t7 - filtering for Students, Lecturers and Courses Lists;\n" +
                    "\t0 - exit;\n" +
                    "\n" +
                    "Please input the filtering restriction number: ");
                try
                {
                    listNumber = Convert.ToInt16(Console.ReadLine());
                    if (listNumber < 0 || listNumber > 7) throw new Exception("Inputted filtering restriction number more than 7 or less than 0\n");
                }
                catch (Exception ex)
                { 
                    Console.WriteLine($"{ex.Message}\n");
                    continue;
                }
                if (listNumber == 0) { break; }
                Console.Write("Please input the filtering restriction string:  ");
                string filter = Console.ReadLine();
                if (filter.Equals("")) 
                {
                    Console.WriteLine("\nThe filtering restriction string shouldn't be empty\n");
                    continue; 
                }
                Console.WriteLine();
                bool usingResult;
                PrintFilteredList(listNumber, filter, out usingResult);
                if (!usingResult) { Console.WriteLine("There are no records matching the filter condition"); }
            }
        }

    }
}
