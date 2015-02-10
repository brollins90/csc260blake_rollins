using LINQRefresher_v3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQRefresher_v3.ExtensionMethods;

namespace LINQRefresher
{
    class Program
    {
        static void Main(string[] args)
        {


            GetStudentsByGenderTest();
            GetStudentsByAgeRangeTest();
            GetTheFailingStudentsTest();
            StudentsPerClassLevelTest();
            MaritalStatusWithHighestAverageGPATest();
            TopOfTheClassTest();
            UnderageStudentsTest();
            FindTheStudentsTest();
            CurrentPercentageOfPeopleInSchoolTest();
            NumberOfPeopleByBirthSignTest();
        }


        public static void GetStudentsByGenderTest()
        {
            Console.Write("GetStudentsByGender");

            List<Student> students = new List<Student>();
            students.Add(new Student()
            {
                Birthdate = new DateTime(1990, 1, 1),
                GPA = 3.5f,
                Level = LINQRefresher_v3.Enums.ClassLevel.Freshman,
                Name = "One",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Male,
                StudentId = 7
            });
            students.Add(new Student()
            {
                Birthdate = new DateTime(1995, 1, 1),
                GPA = 3.5f,
                Level = LINQRefresher_v3.Enums.ClassLevel.Freshman,
                Name = "two",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Male,
                StudentId = 9
            });
            students.Add(new Student()
            {
                Birthdate = new DateTime(2000, 1, 1),
                GPA = 1.5f,
                Level = LINQRefresher_v3.Enums.ClassLevel.Freshman,
                Name = "three",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
                StudentId = 47
            });
            students.Add(new Student()
            {
                Birthdate = new DateTime(2005, 1, 1),
                GPA = 2.0f,
                Level = LINQRefresher_v3.Enums.ClassLevel.Freshman,
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
                StudentId = 96
            });

            var males = students.GetStudentsByGender(LINQRefresher_v3.Enums.Gender.Male);
            var females = students.GetStudentsByGender(LINQRefresher_v3.Enums.Gender.Female);

            //if (expected.Equals(actual))
            if (males.Count() == 2 && females.Count() == 2)
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(" Pass");
                Console.ForegroundColor = color;
            }
            else
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Fail");// (e:{0} a:{1}", expected, actual);
                Console.ForegroundColor = color;
            }
        }


        public static void GetStudentsByAgeRangeTest()
        {
            Console.Write("GetStudentsByAgeRange");

            List<Student> students = new List<Student>();
            students.Add(new Student()
            {
                Birthdate = new DateTime(1990, 1, 1),
                GPA = 3.5f,
                Level = LINQRefresher_v3.Enums.ClassLevel.Freshman,
                Name = "One",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Male,
                StudentId = 7
            });
            students.Add(new Student()
            {
                Birthdate = new DateTime(1995, 1, 1),
                GPA = 3.5f,
                Level = LINQRefresher_v3.Enums.ClassLevel.Freshman,
                Name = "two",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Male,
                StudentId = 9
            });
            students.Add(new Student()
            {
                Birthdate = new DateTime(2000, 1, 1),
                GPA = 1.5f,
                Level = LINQRefresher_v3.Enums.ClassLevel.Freshman,
                Name = "three",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
                StudentId = 47
            });
            students.Add(new Student()
            {
                Birthdate = new DateTime(2005, 1, 1),
                GPA = 2.0f,
                Level = LINQRefresher_v3.Enums.ClassLevel.Freshman,
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
                StudentId = 96
            });

            var one = students.GetStudentsByAgeRange(1, 11);
            var two = students.GetStudentsByAgeRange(11, 30);

            //if (expected.Equals(actual))
            if (one.Count() == 1 && two.Count() == 3)
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(" Pass");
                Console.ForegroundColor = color;
            }
            else
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Fail");// (e:{0} a:{1}", expected, actual);
                Console.ForegroundColor = color;
            }
        }


        public static void GetTheFailingStudentsTest()
        {
            Console.Write("GetTheFailingStudents");

            List<Student> students = new List<Student>();
            students.Add(new Student()
            {
                Birthdate = new DateTime(1990, 1, 1),
                GPA = 3.5f,
                Level = LINQRefresher_v3.Enums.ClassLevel.Freshman,
                Name = "One",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Male,
                StudentId = 7
            });
            students.Add(new Student()
            {
                Birthdate = new DateTime(1995, 1, 1),
                GPA = 3.5f,
                Level = LINQRefresher_v3.Enums.ClassLevel.Freshman,
                Name = "two",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Male,
                StudentId = 9
            });
            students.Add(new Student()
            {
                Birthdate = new DateTime(2000, 1, 1),
                GPA = 1.5f,
                Level = LINQRefresher_v3.Enums.ClassLevel.Freshman,
                Name = "three",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
                StudentId = 47
            });
            students.Add(new Student()
            {
                Birthdate = new DateTime(2005, 1, 1),
                GPA = 2.0f,
                Level = LINQRefresher_v3.Enums.ClassLevel.Freshman,
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
                StudentId = 96
            });

            var one = students.GetTheFailingStudents();

            //if (expected.Equals(actual))
            if (one.Count() == 1)
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(" Pass");
                Console.ForegroundColor = color;
            }
            else
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Fail");// (e:{0} a:{1}", expected, actual);
                Console.ForegroundColor = color;
            }
        }


        public static void StudentsPerClassLevelTest()
        {
            Console.Write("StudentsPerClassLevel");

            List<Student> students = new List<Student>();
            students.Add(new Student()
            {
                Birthdate = new DateTime(1990, 1, 1),
                GPA = 3.5f,
                Level = LINQRefresher_v3.Enums.ClassLevel.Freshman,
                Name = "One",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Male,
                StudentId = 7
            });
            students.Add(new Student()
            {
                Birthdate = new DateTime(1995, 1, 1),
                GPA = 3.5f,
                Level = LINQRefresher_v3.Enums.ClassLevel.Freshman,
                Name = "two",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Male,
                StudentId = 9
            });
            students.Add(new Student()
            {
                Birthdate = new DateTime(2000, 1, 1),
                GPA = 1.5f,
                Level = LINQRefresher_v3.Enums.ClassLevel.Freshman,
                Name = "three",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
                StudentId = 47
            });
            students.Add(new Student()
            {
                Birthdate = new DateTime(2005, 1, 1),
                GPA = 2.0f,
                Level = LINQRefresher_v3.Enums.ClassLevel.Freshman,
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
                StudentId = 96
            });

            var one = students.StudentsPerClassLevel();

            //if (expected.Equals(actual))
            if (one.Count() == 1)
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(" Pass");
                Console.ForegroundColor = color;
            }
            else
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Fail");// (e:{0} a:{1}", expected, actual);
                Console.ForegroundColor = color;
            }
        }


        public static void MaritalStatusWithHighestAverageGPATest()
        {
            Console.Write("MaritalStatusWithHighestAverageGPA");

            List<Student> students = new List<Student>();
            students.Add(new Student()
            {
                Birthdate = new DateTime(1990, 1, 1),
                GPA = 3.5f,
                Level = LINQRefresher_v3.Enums.ClassLevel.Freshman,
                Name = "One",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Male,
                StudentId = 7
            });
            students.Add(new Student()
            {
                Birthdate = new DateTime(1995, 1, 1),
                GPA = 3.5f,
                Level = LINQRefresher_v3.Enums.ClassLevel.Freshman,
                Name = "two",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Male,
                StudentId = 9
            });
            students.Add(new Student()
            {
                Birthdate = new DateTime(2000, 1, 1),
                GPA = 1.5f,
                Level = LINQRefresher_v3.Enums.ClassLevel.Freshman,
                Name = "three",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
                StudentId = 47
            });
            students.Add(new Student()
            {
                Birthdate = new DateTime(2005, 1, 1),
                GPA = 2.0f,
                Level = LINQRefresher_v3.Enums.ClassLevel.Freshman,
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
                StudentId = 96
            });

            var one = students.MaritalStatusWithHighestAverageGPA();

            //if (expected.Equals(actual))
            if (one.Equals(LINQRefresher_v3.Enums.MaritalStatus.Divorced))
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(" Pass");
                Console.ForegroundColor = color;
            }
            else
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Fail");// (e:{0} a:{1}", expected, actual);
                Console.ForegroundColor = color;
            }
        }


        public static void TopOfTheClassTest()
        {
            Console.Write("TopOfTheClass");

            List<Student> students = new List<Student>();
            students.Add(new Student()
            {
                Birthdate = new DateTime(1990, 1, 1),
                GPA = 3.5f,
                Level = LINQRefresher_v3.Enums.ClassLevel.Freshman,
                Name = "One",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Male,
                StudentId = 7
            });
            students.Add(new Student()
            {
                Birthdate = new DateTime(1995, 1, 1),
                GPA = 3.5f,
                Level = LINQRefresher_v3.Enums.ClassLevel.Freshman,
                Name = "two",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Male,
                StudentId = 9
            });
            students.Add(new Student()
            {
                Birthdate = new DateTime(2000, 1, 1),
                GPA = 1.5f,
                Level = LINQRefresher_v3.Enums.ClassLevel.Freshman,
                Name = "three",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
                StudentId = 47
            });
            students.Add(new Student()
            {
                Birthdate = new DateTime(2005, 1, 1),
                GPA = 2.0f,
                Level = LINQRefresher_v3.Enums.ClassLevel.Junior,
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
                StudentId = 96
            });

            var one = students.TopOfTheClass(2);

            //if (expected.Equals(actual))
            if (one.Count().Equals(3))
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(" Pass");
                Console.ForegroundColor = color;
            }
            else
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Fail");// (e:{0} a:{1}", expected, actual);
                Console.ForegroundColor = color;
            }
        }


        public static void UnderageStudentsTest()
        {
            Console.Write("UnderageStudents");

            List<Student> students = new List<Student>();

            var one = students.UnderageStudents();

            //if (expected.Equals(actual))
            if (one.Equals(LINQRefresher_v3.Enums.MaritalStatus.Divorced))
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(" Pass");
                Console.ForegroundColor = color;
            }
            else
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Fail");// (e:{0} a:{1}", expected, actual);
                Console.ForegroundColor = color;
            }
        }


        public static void FindTheStudentsTest()
        {
            Console.Write("FindTheStudents");

            List<Person> people = new List<Person>();
            people.Add(new Person()
            {
                Birthdate = new DateTime(2005, 1, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });
            people.Add(new Person()
            {
                Birthdate = new DateTime(2005, 2, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });
            people.Add(new Person()
            {
                Birthdate = new DateTime(2005, 3, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });
            people.Add(new Person()
            {
                Birthdate = new DateTime(2005, 4, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });
            people.Add(new Person()
            {
                Birthdate = new DateTime(2005, 5, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });
            people.Add(new Person()
            {
                Birthdate = new DateTime(2005, 6, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });
            people.Add(new Person()
            {
                Birthdate = new DateTime(2005, 7, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });
            people.Add(new Person()
            {
                Birthdate = new DateTime(2005, 8, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });
            people.Add(new Person()
            {
                Birthdate = new DateTime(2005, 9, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });
            people.Add(new Student()
            {
                Birthdate = new DateTime(2005, 10, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });
            people.Add(new Student()
            {
                Birthdate = new DateTime(2005, 11, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });
            people.Add(new Student()
            {
                Birthdate = new DateTime(2005, 12, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });

            var one = people.FindTheStudents();

            //if (expected.Equals(actual))
            if (one.Count().Equals(3))
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(" Pass");
                Console.ForegroundColor = color;
            }
            else
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Fail");// (e:{0} a:{1}", expected, actual);
                Console.ForegroundColor = color;
            }
        }


        public static void CurrentPercentageOfPeopleInSchoolTest()
        {
            Console.Write("CurrentPercentageOfPeopleInSchool");

            List<Person> people = new List<Person>();
            people.Add(new Person()
            {
                Birthdate = new DateTime(2005, 1, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });
            people.Add(new Person()
            {
                Birthdate = new DateTime(2005, 2, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });
            people.Add(new Person()
            {
                Birthdate = new DateTime(2005, 3, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });
            people.Add(new Person()
            {
                Birthdate = new DateTime(2005, 4, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });
            people.Add(new Person()
            {
                Birthdate = new DateTime(2005, 5, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });
            people.Add(new Person()
            {
                Birthdate = new DateTime(2005, 6, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });
            people.Add(new Person()
            {
                Birthdate = new DateTime(2005, 7, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });
            people.Add(new Person()
            {
                Birthdate = new DateTime(2005, 8, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });
            people.Add(new Person()
            {
                Birthdate = new DateTime(2005, 9, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });
            people.Add(new Student()
            {
                Birthdate = new DateTime(2005, 10, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });
            people.Add(new Student()
            {
                Birthdate = new DateTime(2005, 11, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });
            people.Add(new Student()
            {
                Birthdate = new DateTime(2005, 12, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });

            var one = people.CurrentPercentageOfPeopleInSchool();

            //if (expected.Equals(actual))
            if (one.Equals(.25f))
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(" Pass");
                Console.ForegroundColor = color;
            }
            else
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Fail");// (e:{0} a:{1}", expected, actual);
                Console.ForegroundColor = color;
            }
        }


        public static void NumberOfPeopleByBirthSignTest()
        {
            Console.Write("NumberOfPeopleByBirthSign");

            List<Person> people = new List<Person>();
            people.Add(new Person()
            {
                Birthdate = new DateTime(2005, 1, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });
            people.Add(new Person()
            {
                Birthdate = new DateTime(2005, 2, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });
            people.Add(new Person()
            {
                Birthdate = new DateTime(2005, 3, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });
            people.Add(new Person()
            {
                Birthdate = new DateTime(2005, 4, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });
            people.Add(new Person()
            {
                Birthdate = new DateTime(2005, 5, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });
            people.Add(new Person()
            {
                Birthdate = new DateTime(2005, 6, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });
            people.Add(new Person()
            {
                Birthdate = new DateTime(2005, 7, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });
            people.Add(new Person()
            {
                Birthdate = new DateTime(2005, 8, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });
            people.Add(new Person()
            {
                Birthdate = new DateTime(2005, 9, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });
            people.Add(new Person()
            {
                Birthdate = new DateTime(2005, 10, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });
            people.Add(new Person()
            {
                Birthdate = new DateTime(2005, 11, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });
            people.Add(new Person()
            {
                Birthdate = new DateTime(2005, 12, 1),
                Name = "four",
                Relationship = LINQRefresher_v3.Enums.MaritalStatus.Divorced,
                Sex = LINQRefresher_v3.Enums.Gender.Female,
            });

            var one = people.NumberOfPeopleByBirthSign();

            //if (expected.Equals(actual))
            if (one[LINQRefresher_v3.Enums.ZodiacSign.Aries].Equals(1) && one.Count == 12)
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(" Pass");
                Console.ForegroundColor = color;
            }
            else
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Fail");// (e:{0} a:{1}", expected, actual);
                Console.ForegroundColor = color;
            }
        }
    }
}
