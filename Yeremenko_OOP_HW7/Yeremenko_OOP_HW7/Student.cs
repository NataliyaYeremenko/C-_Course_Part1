using System;
using System.Collections.Generic;

namespace Yeremenko_OOP_HW7
{
    public class Student:Person
    {
        private static int _studentCount;
        public int MaxEnrolledCoursesCount { get; set; } 
        public int StudentId { get; private set; }
        public List<Course> CoursesList { get; private set; }
        public Student(string name, string lastName, DateOnly dob, string city) : this(name, lastName, dob)
        {
            City = city;
        }
        public Student(string name, string lastName, DateOnly dob) : base(name, lastName, dob)
        {
            StudentId = ++_studentCount;
            CoursesList = new List<Course>();
            MaxEnrolledCoursesCount = 10; // the maximum number of courses for one student is assumed to be 10
        }
        public string GetEnrolledCoursesFullInfo()
        {
            string enrolledCourses = "";
            if (CoursesList.Count != 0)
            {
                foreach(var course in CoursesList) 
                {
                    enrolledCourses += ($"\tCourse_ID={course.CourseId}: {course.CourseName}, Lecturer: {course.Lecturer.Name} {course.Lecturer.LastName}\n");
                }
            }
            return enrolledCourses;
        }
        public string GetEnrolledCoursesNames()
        {
            string enrolledCourses = "";
            if (CoursesList.Count != 0)
            {
                for (int i = 0; i < CoursesList.Count; i++)
                {
                    enrolledCourses += ($"{CoursesList[i].CourseName}");
                    if (i < CoursesList.Count - 1) enrolledCourses += ", ";
                }
            }
            return enrolledCourses;
        }
        public int GetEnrolledCoursesCount() { return CoursesList.Count; }
        public override void Print()
        {
            Console.WriteLine("\n*** Student Info ***");
            Console.WriteLine($"Student Id: {StudentId}");
            base.Print();
            if (CoursesList.Count != 0)
            {
                Console.WriteLine("Enrolled courses:\n" + GetEnrolledCoursesFullInfo());
            }
        }
        public override void DescribeYourself()
        {
            base.DescribeYourself();
            Console.Write("I am a Student. ");
            if (CoursesList.Count > 0)
            {
                Console.WriteLine($"I am taking {CoursesList.Count} course(s): {GetEnrolledCoursesNames()}");
            }
            else { Console.WriteLine("I haven't enrolled in any course yet."); }
        }
        public bool IsCourseCouldBeAddedToList(Course course)
        {
            bool condition = false;
            if (CoursesList.Count != MaxEnrolledCoursesCount)
            {
                condition = true;
                if (CoursesList.Contains(course))
                {
                    condition = false;
                    Console.WriteLine($"\nCourse '{course.CourseName}' is already added to the student {Name} {LastName} courses list");
                }
            }
            else Console.WriteLine($"\nStudent can't be added to course {course.CourseName} as (s)he's already enrolled to the {MaxEnrolledCoursesCount} courses");
            return condition;
        }
        public bool IsCourseCouldBeRemovedFromList(Course course)
        {
            bool isDeleted = false;
            if (CoursesList.Count != 0)
            {
                if (CoursesList.Contains(course))
                {
                    isDeleted = true;
                }
                else
                {
                    Console.WriteLine($"\nThere is no course '{course.CourseName}' in the student's {Name} {LastName} course list");
                }
            }
            else
            {
                Console.WriteLine($"\nThe student's {Name} {LastName} course list is empty");
            }
            return isDeleted;
        }
        public void AddStudentToCourse(Course course)
        {
            course.AddStudentToCourse(this);
        }
        public void RemoveStudentFromCourse(Course course)
        {
            course.RemoveStudentFromCourse(this);
        }
    }
}
