using System;

namespace Yeremenko_OOP
{
    public class Lecturer : Person
    {
        private static int _lecturerCount;

        private const int MAX_ENROLLED_COURSES = 5;
        public int LecturerId { get; private set; }
        public Course[] CoursesList { get; private set; }
        public Lecturer(string name, string lastName, DateOnly dob) : base(name, lastName, dob)
        {
            LecturerId = ++_lecturerCount;
            CoursesList = new Course[MAX_ENROLLED_COURSES];  // the maximum number of courses for one lecturer is assumed to be 5
        }
        public Lecturer(string name, string lastName, DateOnly dob, string city) : this(name, lastName, dob)
        {
            City = city;
        }
        public int GetEnrolledCoursesCount()
        {
            int count = 0;
            foreach (var st in CoursesList)
            {
                if (st != null) { count++; }
            }
            return count;
        }
        public string GetEnrolledCoursesNames()
        {
            string enrolledCourses = "";
            if (GetEnrolledCoursesCount() != 0)
            {
                for (int i = 0; i < GetEnrolledCoursesCount(); i++)
                {
                    enrolledCourses += ($"{CoursesList[i].CourseName}");
                    if (i < GetEnrolledCoursesCount() - 1) enrolledCourses += ", ";
                }
            }
            return enrolledCourses;
        }
        public string GetEnrolledCoursesFullInfo()
        {
            string enrolledCourses = "";
            if (GetEnrolledCoursesCount() != 0)
            {
                for (int i = 0; i < GetEnrolledCoursesCount(); i++)
                {
                    enrolledCourses += ($"\tCourse_ID={CoursesList[i].CourseId}: {CoursesList[i].CourseName}, enrolled students count: {CoursesList[i].GetRealStudentsCountForCourse()}\n");
                }
            }
            return enrolledCourses;
        }
        public bool IsCourseCouldBeAddedToList(Course course)
        {
            bool condition = false;
            if (GetEnrolledCoursesCount() != MAX_ENROLLED_COURSES)
            {
                condition = true;
                for (int i = 0; i < GetEnrolledCoursesCount(); i++)
                {
                    if (CoursesList[i].CourseId == course.CourseId)
                    {
                        condition = false;
                        Console.WriteLine($"\nCourse '{course.CourseName}' is already added to the lecturer {Name} {LastName} courses list");
                    }
                }
            }
            else Console.WriteLine($"\nCourse can't be added to the lecturer {Name} {LastName} courses list as (s)he's already worked with the {MAX_ENROLLED_COURSES} courses");
            return condition;
        }
        public void AddCourse(Course course)
        {
            if (IsCourseCouldBeAddedToList(course))
            {
                CoursesList[GetEnrolledCoursesCount()] = course;
            }
        }
        public override void Print()
        {
            Console.WriteLine("\n*** Lecturer Info ***");
            Console.WriteLine($"Lecturer Id: {LecturerId}");
            base.Print();
            if (GetEnrolledCoursesCount() != 0)
            {
                Console.WriteLine("Enrolled courses:\n"+GetEnrolledCoursesFullInfo());
            }
        }
        public override void DescribeYourself()
        {
            base.DescribeYourself();
            Console.Write("I am a Lecturer. ");
            if (GetEnrolledCoursesCount() > 0)
            {
                Console.WriteLine($"I am working on {GetEnrolledCoursesCount()} course(s): {GetEnrolledCoursesNames()}");
            }
            else { Console.WriteLine("I haven't worked on any course yet."); }
        }
    }
}
