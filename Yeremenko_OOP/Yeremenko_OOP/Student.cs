using System;

namespace Yeremenko_OOP
{
    public class Student : Person
    {
        private static int _studentCount;

        private const int MAX_ENROLLED_COURSES = 10;
        public int StudentId { get; private set; }
        public Course[] CoursesList { get; private set; }
        public Student(string name, string lastName, DateOnly dob, string city) : this(name, lastName, dob)
        {
            City = city;
        }
        public Student(string name, string lastName, DateOnly dob) : base(name, lastName, dob)
        {
            StudentId = ++_studentCount;
            CoursesList = new Course[MAX_ENROLLED_COURSES];  // the maximum number of courses for one student is assumed to be 10
        }

        public string GetEnrolledCoursesFullInfo()
        {
            string enrolledCourses="";
            if (GetEnrolledCoursesCount() != 0)
            {
                for (int i = 0; i < GetEnrolledCoursesCount(); i++)
                {
                    enrolledCourses += ($"\tCourse_ID={CoursesList[i].CourseId}: {CoursesList[i].CourseName}, Lecturer: {CoursesList[i].Lecturer.Name} {CoursesList[i].Lecturer.LastName}\n");
                }
            }
            return enrolledCourses;
        }
        public string GetEnrolledCoursesNames()
        {
            string enrolledCourses = "";
            if (GetEnrolledCoursesCount() != 0)
            {
                for (int i = 0; i < GetEnrolledCoursesCount(); i++)
                {
                    enrolledCourses += ($"{CoursesList[i].CourseName}");
                    if (i < GetEnrolledCoursesCount()-1) enrolledCourses += ", ";
                }
            }
            return enrolledCourses;
        }

        public override void Print()
        {
            Console.WriteLine("\n*** Student Info ***");
            Console.WriteLine($"Student Id: {StudentId}");
            base.Print();
            if (GetEnrolledCoursesCount() != 0)
            {
                Console.WriteLine("Enrolled courses:\n"+GetEnrolledCoursesFullInfo());
            }
        }
        public override void DescribeYourself()
        {
            base.DescribeYourself();
            Console.Write("I am a Student. ");
            if (GetEnrolledCoursesCount() > 0)
            {
                Console.WriteLine($"I am taking {GetEnrolledCoursesCount()} course(s): {GetEnrolledCoursesNames()}");
            }
            else { Console.WriteLine("I haven't enrolled in any course yet."); }
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
                    }
                }
            }
            else Console.WriteLine($"\nStudent can't be added to course {course.CourseName} as (s)he's already enrolled to the {MAX_ENROLLED_COURSES} courses");
            return condition;
        }
        public void AddStudentToCourse(Course course)
        {
            if ((IsCourseCouldBeAddedToList(course))
                &&
                (course.IsStudentCoudBeEnrolledToCourse(this)))
            {
                CoursesList[GetEnrolledCoursesCount()] = course;
                course.AddStudent(this);
                Console.WriteLine($"\nStudent {Name} {LastName} is added to course {course.CourseName}");
            }
            else
            {
                Console.WriteLine($"\nStudent {Name} {LastName} can't be added to course {course.CourseName}");
            }
        }
        public void AddCourse(Course course)
        {
            CoursesList[GetEnrolledCoursesCount()] = course;
        }
        public void RemoveStudentFromCourse(Course course) 
        {
            bool isDel1, isDel2;
            PartialRemoveStudentFromCourse(course, out isDel1);
            course.PartialRemoveStudentFromCourse(this, out isDel2);
            if (isDel1 && isDel2)
            {
                Console.WriteLine($"\nCourse {course.CourseName} is removed from student {Name} {LastName} Course List");
            }
        }
        public void PartialRemoveStudentFromCourse(Course course, out bool isDeleted)
        {
            int count = GetEnrolledCoursesCount();
            int delIndex = 0;
            isDeleted = false;  
            if (CoursesList[delIndex] is not null)
            {
                while ((CoursesList[delIndex] is not null) && (delIndex < count) && (!isDeleted))
                {
                    if (CoursesList[delIndex].CourseId == course.CourseId)
                    {
                        isDeleted = true;
                    }
                    ++delIndex;
                }
                if (isDeleted)
                {
                    for (int i = delIndex-1; i < count - 1; i++)
                    {
                        CoursesList[i] = CoursesList[i + 1];
                    }
                    this.CoursesList[count - 1] = null;
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
        }
    }
}
