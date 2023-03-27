using System;
using System.Collections.Generic;

namespace Yeremenko_OOP_HW7
{
    public class Course
    {
        private static int _coursesCount;
        public int CourseId { get; private set; }
        public string CourseName { get; set; }
        public Lecturer Lecturer { get; set; }
        public int CourseDuration { get; set; }
        public int MaxCapacityForCourse { get; private set; }
        public List<Student> StudentsList { get; private set; }
        public Course(string courseName, Lecturer lecturer, int courseDuration, int maxCapacityForCourse)
        {
            if (lecturer.IsCourseCouldBeAddedToList(this))
            {
                CourseId = ++_coursesCount;
                CourseName = courseName;
                Lecturer = lecturer;
                CourseDuration = courseDuration;
                MaxCapacityForCourse = maxCapacityForCourse;
                StudentsList = new List<Student>();
                lecturer.AddCourse(this);
            }
            else return;
        }
        public void Print()
        {
            Console.WriteLine("\n*** Course Info ***");
            Console.WriteLine(
                $"Course Id: {CourseId}\n" +
                $"Course Name: {CourseName}\n" +
                $"Lecturer: {Lecturer.Name} {Lecturer.LastName}\n" +
                $"Course Duration: {CourseDuration} year(s)\n" +
                $"Max capacity for course: {MaxCapacityForCourse}\n" +
                $"Real students number for course: {StudentsList.Count}");
            if (StudentsList.Count != 0)
            {
                Console.WriteLine("Enrolled students:");
                for (int i = 0; i < StudentsList.Count; i++)
                {
                    Console.WriteLine($"\tStudent_ID={StudentsList[i].StudentId}: {StudentsList[i].Name} {StudentsList[i].LastName}");
                }
            }
        }
        public int GetEnrolledStudentsCount() { return  StudentsList.Count; }
        public bool IsStudentCoudBeEnrolledToCourse(Student student)
        {
            bool condition = true;
            if (StudentsList.Count != MaxCapacityForCourse)
            {
                if (StudentsList.Contains(student)) condition = false;
            }
            else Console.WriteLine($"\nStudent can't be added to course {CourseName} as course is reached its maximum capacity = {MaxCapacityForCourse}");
            return condition;
        }
        public bool IsStudentCouldBeRemovedFromList(Student student)
        {
            bool isDeleted = false;
            if (StudentsList.Count != 0)
            {
                if (StudentsList.Contains(student))
                {
                    isDeleted = true;
                }
                else
                {
                    Console.WriteLine($"\nThere is no {student.Name} {student.LastName} in the course '{CourseName}' list");
                }
            }
            else
            {
                Console.WriteLine($"\nThe student's list for course '{CourseName}' is empty");
            }
            return isDeleted;
        }
        public void AssignNewLecturerToCourse(Lecturer lecturer)
        {
            if (lecturer.IsCourseCouldBeAddedToList(this))
            {
                Console.WriteLine($"The new lecturer {lecturer.Name} {lecturer.LastName} is asigned instead of previous lecturer {this.Lecturer.Name} {this.Lecturer.LastName}");
                Lecturer.RemoveCourse(this);
                Lecturer = lecturer;
                lecturer.AddCourse(this);
            }
            else Console.WriteLine($"The new lecturer {lecturer.Name} {lecturer.LastName} couldn't be asigned (as (s)he's already worked with the {lecturer.MaxEnrollerCoursesCount} courses) instead of previous lecturer {this.Lecturer.Name} {this.Lecturer.LastName}");
        }
        public void AddStudentToCourse(Student student)
        {
            if ((IsStudentCoudBeEnrolledToCourse(student))
                &&
                (student.IsCourseCouldBeAddedToList(this)))
            {
                StudentsList.Add(student);
                student.CoursesList.Add(this);
                if ((Lecturer.StudentsList.Count != 0) && (Lecturer.StudentsList.ContainsKey(student))) Lecturer.StudentsList[student].Add(CourseId);
                else Lecturer.StudentsList.Add(student, new List<int> { CourseId });
                Console.WriteLine($"\nStudent {student.Name} {student.LastName} is added to course {CourseName} and course is added to his(her) Courses List");
            }
            else
            {
                Console.WriteLine($"\nStudent {student.Name} {student.LastName} can't be added to course {CourseName}");
            }
        }
        public void RemoveStudentFromCourse(Student student)
        {
            if (student.IsCourseCouldBeRemovedFromList(this) && IsStudentCouldBeRemovedFromList(student))
            {
                StudentsList.Remove(student);   
                student.CoursesList.Remove(this);
                Lecturer.StudentsList[student].Remove(CourseId);
                if (Lecturer.StudentsList[student].Count==0) Lecturer.StudentsList.Remove(student);
                Console.WriteLine($"\nStudent {student.Name} {student.LastName} is removed from course {CourseName}");
            }
        }
    }
}
