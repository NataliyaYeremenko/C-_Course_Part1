using System;
using System.Collections.Generic;
using System.Text;

namespace Yeremenko_OOP_HW7
{
    public class Lecturer : Person
    {
        private static int _lecturerCount;
        public int MaxEnrollerCoursesCount { get; set; }
        public int LecturerId { get; private set; }
        public List<Course> CoursesList { get; private set; }
        public Dictionary<Student, List<int>> StudentsList { get; private set; }
        public Lecturer(string name, string lastName, DateOnly dob) : base(name, lastName, dob)
        {
            LecturerId = ++_lecturerCount;
            CoursesList = new List<Course>();
            StudentsList = new Dictionary<Student, List<int>>();
            MaxEnrollerCoursesCount = 5;
            InfoClass._lecturers.Add(this);
        }
        public Lecturer(string name, string lastName, DateOnly dob, string city) : this(name, lastName, dob)
        {
            City = city;
        }
        public string GetEnrolledCoursesNames()
        {
            var enrolledCourses = new StringBuilder();
            if (CoursesList.Count != 0)
            {
                for (int i = 0; i < CoursesList.Count; i++)
                {
                    enrolledCourses.Append($"{CoursesList[i].CourseName}");
                    if (i < CoursesList.Count - 1) enrolledCourses.Append(", ");
                }
            }
            return enrolledCourses.ToString();
        }
        public int GetEnrolledCoursesCount() {  return CoursesList.Count; }
        public int GetStudentsListCount() { return StudentsList.Count; }    
        public string GetEnrolledCoursesFullInfo()
        {
            var enrolledCourses = new StringBuilder();
            if (CoursesList.Count != 0)
            {
                foreach (var course in CoursesList) 
                {
                    enrolledCourses.Append($"\tCourse_ID={course.CourseId}: {course.CourseName}, enrolled students count: {course.StudentsList.Count}\n");
                }
            }
            return enrolledCourses.ToString();
        }
        public bool IsCourseCouldBeAddedToList(Course course)
        {
            bool condition = false;
            if (CoursesList.Count != MaxEnrollerCoursesCount)
            {
                condition = true;
                if (CoursesList.Contains(course))
                {
                    condition = false;
                    Console.WriteLine($"\nCourse '{course.CourseName}' is already added to the lecturer {Name} {LastName} courses list");
                }
            }
            else Console.WriteLine($"\nCourse can't be added to the lecturer {Name} {LastName} courses list as (s)he's already worked with the {MaxEnrollerCoursesCount} courses");
            return condition;
        }
        public bool IsCourseCouldBeRemovedFromList(Course course)
        {
            bool condition = false;
            if (CoursesList.Count != 0)
            {
                if (CoursesList.Contains(course))
                {
                    condition = true;
                }
            }
            else Console.WriteLine($"\nCourse can't be removed from the lecturer {Name} {LastName} courses list as his(her) courses list is empty");
            return condition;
        }
        public void AddCourse(Course course)
        {
            if (IsCourseCouldBeAddedToList(course))
            {
                CoursesList.Add(course);
                foreach (var student in course.StudentsList)
                {
                    if ((StudentsList.Count!=0)&&(StudentsList.ContainsKey(student))) StudentsList[student].Add(course.CourseId);
                    else StudentsList.Add(student, new List<int> { course.CourseId });
                }
            }
        }
        public void RemoveCourse(Course course)
        {
            if (IsCourseCouldBeRemovedFromList(course))
            {
                foreach (var student in course.StudentsList)
                {
                    StudentsList[student].Remove(course.CourseId);
                    if (StudentsList[student].Count == 0) StudentsList.Remove(student);
                }
                CoursesList.Remove(course);
            }
        }
        public void PrintInfo()
        {
            Console.Write($"Lecturer_ID={LecturerId}: {Name} {LastName}, {DoB}. ");
            if (CoursesList.Count != 0)
            {
                Console.WriteLine("Enrolled courses: " + GetEnrolledCoursesNames());
            }
            else Console.WriteLine();
            Console.WriteLine();
        }
        public override void Print()
        {
            Console.WriteLine("\n*** Lecturer Info ***");
            Console.WriteLine($"Lecturer Id: {LecturerId}");
            base.Print();
            if (CoursesList.Count != 0)
            {
                Console.WriteLine("Enrolled courses:\n" + GetEnrolledCoursesFullInfo());
            }
        }
        public override void DescribeYourself()
        {
            base.DescribeYourself();
            Console.Write("I am a Lecturer. ");
            if (CoursesList.Count > 0)
            {
                Console.WriteLine($"I am working on {CoursesList.Count} course(s): {GetEnrolledCoursesNames()}");
            }
            else { Console.WriteLine("I haven't worked on any course yet."); }
        }
        public void PrintStudentsList()
        {
            Console.WriteLine($"\n*** Students List for {Name} {LastName} ***");
            if (StudentsList.Count > 0)
            {
                foreach (var item in StudentsList)
                {
                    Console.WriteLine($"{item.Key.Name} {item.Key.LastName}");
                }
            }
            else Console.WriteLine("The StudentsList is empty");
        }
    }
}
