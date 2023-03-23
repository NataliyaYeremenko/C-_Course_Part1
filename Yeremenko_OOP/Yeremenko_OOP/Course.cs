using System;
using System.Xml.Linq;

namespace Yeremenko_OOP
{
    public class Course
    {
        private static int _coursesCount;
        public int CourseId { get; private set; }
        public string CourseName { get; set; }
        public Lecturer Lecturer { get; set; }
        public int CourseDuration { get; set; }
        public int MaxCapacityForCourse { get; private set; }
        public Student[] StudentsList { get; private set; }
        public Course(string courseName, Lecturer lecturer, int courseDuration, int maxCapacityForCourse)
        {
            if (lecturer.IsCourseCouldBeAddedToList(this))
            {
                CourseId = ++_coursesCount;
                CourseName = courseName;
                Lecturer = lecturer;
                CourseDuration = courseDuration;
                MaxCapacityForCourse = maxCapacityForCourse;
                StudentsList = new Student[MaxCapacityForCourse];
                lecturer.AddCourse(this);
            }
            //else Console.WriteLine($"\nCourse can't be created with lecturer {lecturer.Name} {lecturer.LastName}");

        }
        public int GetRealStudentsCountForCourse()
        {
            int count = 0;
            foreach (var st in StudentsList)
            {
                if (st!=null) { count++; }
            }
            return count;
        }
        public bool IsStudentCoudBeEnrolledToCourse(Student student)
        {
            bool condition = true;
            if (GetRealStudentsCountForCourse() != MaxCapacityForCourse)
            {
                for (int i = 0; i < GetRealStudentsCountForCourse(); i++)
                {
                    if (StudentsList[i].StudentId == student.StudentId)
                    {
                        condition = false;
                    }
                }
            }
            else Console.WriteLine($"\nStudent can't be added to course {CourseName} as course is reached its maximum capacity = {MaxCapacityForCourse}");
            return condition;
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
                $"Real students number for course: {GetRealStudentsCountForCourse()}");
            if (GetRealStudentsCountForCourse() != 0)
            {
                Console.WriteLine("Enrolled students:");
                for (int i = 0; i < GetRealStudentsCountForCourse(); i++)
                {
                    Console.WriteLine($"\tStudent_ID={StudentsList[i].StudentId}: {StudentsList[i].Name} {StudentsList[i].LastName}");
                }
            }
        }
        public void AddStudent(Student student)
        {
            StudentsList[GetRealStudentsCountForCourse()] = student;
        }
        public void AddStudentToCourse(Student student)
        {
            if ((IsStudentCoudBeEnrolledToCourse(student))
                &&
                (student.IsCourseCouldBeAddedToList(this)))
            {
                StudentsList[GetRealStudentsCountForCourse()] = student;
                student.AddCourse(this);
                Console.WriteLine($"\nStudent {student.Name} {student.LastName} is added to course {CourseName}");
            }
            else
            {
                Console.WriteLine($"\nStudent {student.Name} {student.LastName} can't be added to course {CourseName}");
            }
        }
        public void RemoveStudentFromCourse(Student student)
        {
            bool isDel1, isDel2;
            PartialRemoveStudentFromCourse(student, out isDel1);
            student.PartialRemoveStudentFromCourse(this, out isDel2);
            if ( isDel1 && isDel2 ) 
            { 
                Console.WriteLine($"\nStudent {student.Name} {student.LastName} is removed from course {CourseName}");
            }
        }
        public void PartialRemoveStudentFromCourse(Student student, out bool isDeleted)
        {
            int count = GetRealStudentsCountForCourse();
            int delIndex = 0;
            isDeleted = false;
            if (StudentsList[delIndex] is not null)
            {
                while ((StudentsList[delIndex] is not null) && (delIndex < count) && (!isDeleted))
                {
                    if (StudentsList[delIndex].StudentId == student.StudentId)
                    {
                        isDeleted = true;
                    }
                    ++delIndex;
                }
                if (isDeleted)
                {
                    for (int i = delIndex-1; i < count - 1; i++)
                    {
                        StudentsList[i] = StudentsList[i + 1];
                    }
                    this.StudentsList[count - 1] = null;
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
        }
    }
}
