using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace week4Task2
{
    public class Student
    {
        public int Id { get; private set; }
        public String Name { get; set; }
        public int Age { get; private set; }
        public List<Course> courses = new List<Course>();

        public Student(int id, string name, int age, List<Course> courses)
        {
            Id = id;
            Name = name;
            Age = age;
            this.courses = courses;
        }
        public bool Enroll(Course course)
        {
            courses.Add(course);
            return true;
        }
        public void PrintDetails()
        {
            Console.WriteLine("Name:" + Name + "id" + Id + "age" + Age);
            Console.WriteLine("Courses:");
            foreach (var c in courses)//
            {
                Console.WriteLine($" - {c.Title}");//
            }

        }
    }
    public class Course
    {
        public int courseId { get; set; }
        public string Title { get; set; }
        public Instructor instructor { get; set; }

        public void PrintDetails()
        {
            Console.WriteLine("courseId:" + courseId + "Title" + Title);
            Console.WriteLine("Instructor Details:");//
            instructor.PrintDetails();//
        }

    }
    public class Instructor
    {
        public Instructor(int instructorId, string name, string specialization)
        {
            InstructorId = instructorId;
            Name = name;
            Specialization = specialization;
        }

        public int InstructorId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public void PrintDetails()
        {
            Console.WriteLine("InstructorId:" + InstructorId + "Name" + Name + "Specialization" + Specialization);
        }

    }
    public class StudentManager
    {
        public List<Student> students = new List<Student>();
        public List<Course> courses = new List<Course>();
        public List<Instructor> instructor = new List<Instructor>();

        public StudentManager(List<Student> students, List<Course> courses, List<Instructor> instructor)//
        {
            this.students = students;
            this.courses = courses;
            this.instructor = instructor;
        }
        public bool AddStudent(Student student)
        {
            students.Add(student);//
            return true;
        }
        public bool AddCourse(Course course)
        {
            courses.Add(course);//
            return true;
        }
        public bool AddInstructor(Instructor instructor)
        {
            this.instructor.Add(instructor);//
            return true;
        }
        public void FindStudent(int id)
        {
            bool found = false;//
            foreach (var s in students)
            {
                if (s.Id == id)//
                {
                    Console.WriteLine("Name: " + s.Name + " , Id: " + s.Id);//
                    found = true;
                    break;

                }
               

            }
            if (!found)///
            {
                Console.WriteLine("Student not found!");
            }

        }
        public void FindCourse(int courseId)
        {
            bool found = false;
            foreach (var c in courses)
            {
                if (c.courseId == courseId)//
                {
                    Console.WriteLine("courseName: " + c.Title + " , courseId: " + c.courseId + "instructor" + c.instructor.Name);//
                    found = true;
                    break;

                }
              

            }
            if (!found)
            {
                Console.WriteLine("Student not found!");
            }

        }
        public void FindInstructor(int instructorId)
        {
            bool found = false;
            foreach (var i in instructor)
            {
                if (i.InstructorId == instructorId)//
                {
                    Console.WriteLine("InstructorId: " + i.InstructorId + " , Name: " + i.Name + "Specialization" + i.Specialization);//
                    found = true;
                    break;


                }
               
            }
            if (!found)
            {
                Console.WriteLine("Student not found!");
            }

        }

        public bool EnrollStudentCourse(int id, int courseId)
        {
            foreach (var s in students)
            {
                if (s.Id == id)
                {
                    return true;
                }

            }
            foreach (var c in courses)
            {
                if (c.courseId == courseId)
                {
                    return true;
                }
            }
            return false;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Instructor instructor1 = new Instructor(1, "Ahmed Ali", "Computer Science");

            // 2- Create Courses and assign instructor
            Course course1 = new Course { courseId = 101, Title = "OOP", instructor = instructor1 };//
            Course course2 = new Course { courseId = 102, Title = "Data Structures", instructor = instructor1 };//

            // 3- Create Student
            Student student1 = new Student(1, "Nour", 20, new List<Course>());

            // 4- Enroll student in courses
            student1.Enroll(course1);
            student1.Enroll(course2);

            // 5- Print student details
            student1.PrintDetails();

            // 6- Print course details
            Console.WriteLine("\nCourse Details:");
            course1.PrintDetails();
            course2.PrintDetails();

            // 7- Print instructor details
            Console.WriteLine("\nInstructor Details:");
            instructor1.PrintDetails();


            StudentManager student = new StudentManager(new List<Student>(), new List<Course>(), new List<Instructor>());
            student.AddStudent(student1);
            student.AddCourse(course1);
            student.AddCourse(course2);
            student.AddInstructor(instructor1);
            Console.WriteLine("=====================");
            student.FindStudent(1);
            student.FindCourse(101);
            student.FindInstructor(1);
            Console.WriteLine(student.EnrollStudentCourse(2, 2));
            Console.WriteLine("=====================");
            bool cond = false;
            while (!cond)
            {
                Console.WriteLine("choose :");
                Console.WriteLine("1: Add student");
                Console.WriteLine("2: Add instructor");
                Console.WriteLine("3: Add course");
                Console.WriteLine("4: enroll student in course");
                Console.WriteLine("5: show all student");
                Console.WriteLine("6: show all courses");
                Console.WriteLine("7: showw all  instructor");
                Console.WriteLine("8: find student by id or name");
                Console.WriteLine("9: find course by id or name");
                Console.WriteLine("10: Exist");
                Console.WriteLine("enter choose");
                int choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        Console.Write("Enter student id: ");
                        int sid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter name: ");
                        string sname = Console.ReadLine();
                        Console.Write("Enter age: ");
                        int age = Convert.ToInt32(Console.ReadLine());
                        Student student2 = new Student(sid, sname, age, new List<Course>());
                        student.AddStudent(student2);//
                        Console.WriteLine("Student added successfully!");
                        break;
                    case 2:
                        Console.Write("Enter instructor id: ");
                        int iid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter name: ");
                        string iname = Console.ReadLine();
                        Console.Write("Enter specialization: ");
                        string spec = Console.ReadLine();
                        Instructor instructor2 = new Instructor(iid, iname, spec);
                        student.AddInstructor(instructor2);

                        Console.WriteLine("instructor added successfully!");
                        break;
                    case 3:
                        Console.Write("Enter instructor id: ");
                        int cid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter name: ");
                        string ctitle = Console.ReadLine();
                        Console.Write("Enter instructor id for this course: ");
                        int instId = Convert.ToInt32(Console.ReadLine());

                        Instructor inst = null;
                        foreach (var i in student.instructor) // نلف على الليست اللي موجودة أصلاً
                        {
                            if (i.InstructorId == instId)//
                            {
                                inst = i; // لقينا المدرس
                                break;
                            }
                        }

                        if (inst != null)
                        {
                            Course course3 = new Course { courseId = cid, Title = ctitle, instructor = inst };
                            student.AddCourse(course3);
                            Console.WriteLine("Course added successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Instructor not found! Please add the instructor first.");
                        }
                        break;
                    case 4:
                        Console.Write("Enter student id: ");
                        int stId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter course id: ");
                        int cId = Convert.ToInt32(Console.ReadLine());


                        bool inroll = student.EnrollStudentCourse(cId, cId);
                        if (inroll)
                        {
                            Console.WriteLine(stId + "ënroll in" + cId);
                        }
                        else
                        {
                            Console.WriteLine("not found");
                        }
                        break;
                    case 5:
                        foreach (var i in student.students)
                        {
                            Console.WriteLine($"Id: {i.Id}, Name: {i.Name}, Age: {i.Age}");//
                        }
                        break;
                    case 6:
                        foreach (var item in student.courses)
                        {
                            Console.WriteLine("courseId" + item.courseId + "title" + item.Title + "instructor" + item.instructor.Name);//

                        }
                        break;
                    case 7:
                        foreach (var item in student.instructor)
                        {
                            Console.WriteLine("InstructorId  :" + item.InstructorId + "name : " + item.Name + "instructor : " + item.Specialization);//

                        }
                        break;

                    case 8:
                        Console.WriteLine("search by id [1] by name[2]");
                        int search = Convert.ToInt32(Console.ReadLine());
                        if (search == 1)
                        {
                            Console.Write("Enter student id: ");
                            int sId = Convert.ToInt32(Console.ReadLine());
                            student.FindStudent(sId);
                        }
                        else if (search == 2)
                        {

                            Console.Write("Enter student name: ");
                            string cName = Console.ReadLine();
                            bool found = false;
                            foreach (var i in student.students)
                            {
                                if (cName == i.Name)
                                {
                                    Console.WriteLine("student name : " + i.Name + "age : " + i.Age + "id : " + i.Id);
                                    found = true;//
                                    break; //

                                }
                                if (!found)// 
                                {
                                    Console.WriteLine("not found");
                                }

                            }

                        }
                        break;
                    case 9:
                        Console.WriteLine("search by id [1] by name[2]");
                        int searchcourse = Convert.ToInt32(Console.ReadLine());
                        if (searchcourse == 1)
                        {
                            Console.Write("Enter course id: ");
                            int courseId = Convert.ToInt32(Console.ReadLine());
                            student.FindCourse(courseId);
                        }
                        else if (searchcourse == 2)
                        {
                            Console.Write("Enter course title: ");
                            string cName = Console.ReadLine();
                            bool found = false;
                            foreach (var i in student.courses)
                            {
                                if(cName == i.Title)
                                {
                                    Console.WriteLine("course title : " + i.Title + " id : " +i.courseId + " instructor : " +i.instructor.Name);//
                                    found = true;
                                    break;
                                }
                            }
                            if (!found)
                            {
                                Console.WriteLine("not found");
                            }

                        }
                        break;
                    case 10:
                        Console.WriteLine("Exiting the program...");
                        cond = true;
                        break;
                }
            }
        }
    }
}
            
        

 
