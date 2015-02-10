using System;
using System.Collections.Generic;
using System.Linq;
using LINQRefresher_v3.Enums;
using LINQRefresher_v3.Models;

namespace LINQRefresher_v3.ExtensionMethods
{
    public static class ExtensionMethods
    {
        /*
         * Using the method names and comments below, implement each extension method.
         * You will receive a grade based on how your implementation functions
         * during a series of automated tests. You may implement the methods
         * using any combination of comprehension, extension, or desugarized
         * syntax.
         */

        /// <summary>
        /// Returns a collection of students based on the indicated Gender
        /// </summary>
        /// <param name="students">The original collection of students</param>
        /// <param name="sex">The Gender value requested</param>
        /// <returns>The collection of Students with the same gender as the parameter</returns>
        public static IEnumerable<Student> GetStudentsByGender(this IEnumerable<Student> students, Gender sex)
        {
            return students.Where(x => x.Sex.Equals(sex));
        }

        /// <summary>
        /// Returns a collection of students where the ages fall between the inclusive min and max values
        /// </summary>
        /// <param name="students">The original collection of students</param>
        /// <param name="minYearsOld">Inclusive minimum age</param>
        /// <param name="maxYearsOld">Inclusive maximum age</param>
        /// <returns>The collection of Students that match the criteria</returns>
        public static IEnumerable<Student> GetStudentsByAgeRange(this IEnumerable<Student> students, int minYearsOld, int maxYearsOld)
        {
            return students.Where(x => x.Age >= minYearsOld && x.Age <= maxYearsOld);
        }

        /// <summary>
        /// Gets the Students with a GPA below 2.0
        /// </summary>
        /// <param name="students">The original collection of students</param>
        /// <returns>The collection of students not currently passing</returns>
        public static IEnumerable<Student> GetTheFailingStudents(this IEnumerable<Student> students)
        {
            return students.Where(x => x.GPA < 2.0);
        }

        /// <summary>
        /// Reports the number of students in each ClassLevel designation
        /// </summary>
        /// <param name="students">The original collection of students</param>
        /// <returns>A Dictionary where the key is the ClassLevel and the value is the number of students in that level</returns>
        public static Dictionary<ClassLevel, int> StudentsPerClassLevel(this IEnumerable<Student> students)
        {
            return students.GroupBy(n => n.Level).ToDictionary(x => x.Key, x => x.Count());
        }

        /// <summary>
        /// Determines which MaritalStatus has the highest average GPA
        /// </summary>
        /// <param name="students">The original collection of students</param>
        /// <returns>The MaritalStatus value with the highest average GPA</returns>
        public static MaritalStatus MaritalStatusWithHighestAverageGPA(this IEnumerable<Student> students)
        {
            var m = from student in students
                    group student by student.Relationship into relationships
                    let a = relationships.Average(x => x.GPA)
                    select new
                    {
                        R = relationships.Key,
                        A = a
                    };
            return m.Select(x => x.R).FirstOrDefault();              
        }

        /// <summary>
        /// Creates a collection containing the top students in each ClassLevel designation.
        /// </summary>
        /// <param name="students">The original collection of students</param>
        /// <param name="count">The number of top students per ClassLevel being requested</param>
        /// <returns>The collection of the top students</returns>
        public static IEnumerable<Student> TopOfTheClass(this IEnumerable<Student> students, int count)
        {
            //return from student in students
            //        group student by student.Level into levels
            //        select levels.OrderBy(x => x.GPA).Take(count);

            return students.GroupBy(x => x.Level).SelectMany(y => y.OrderBy(z => z.GPA).Take(count));
                   
        }

        /// <summary>
        /// Determines which students are still not legal adults. NOTE: this query should work every year that it is run.
        /// </summary>
        /// <param name="students">The original collection of students</param>
        /// <returns>The collection of students that are under the age of 18</returns>
        public static IEnumerable<Student> UnderageStudents(this IEnumerable<Student> students)
        {
            return students.Where(x => x.Age < 18);
        }

        /// <summary>
        /// Takes in a collection of Person objects and returns a collection of those that are Student objects
        /// </summary>
        /// <param name="people">The original collection of Person objects</param>
        /// <returns>The collection of Person objects that are actually Students</returns>
        public static IEnumerable<Student> FindTheStudents(this IEnumerable<Person> people)
        {
            return people.OfType<Student>();
        }

        /// <summary>
        /// Determines the percantage of Person objects that are Students
        /// </summary>
        /// <param name="people">The original collection of people</param>
        /// <returns>The percentage of Person objects that are also Students expressed as a float less than or equal to 1.0</returns>
        public static float CurrentPercentageOfPeopleInSchool(this IEnumerable<Person> people)
        {
            return (float) (((float)people.OfType<Student>().Count()) / (float)(people.Count()));
        }

        /// <summary>
        /// Analyses a collection of Person objects and reports how many people are born under each sign of the zodiac
        /// </summary>
        /// <param name="people">The original collection or Person objects</param>
        /// <returns>A Dictionary where the key is the sign and the value is the number of people born under it</returns>
        public static Dictionary<ZodiacSign, int> NumberOfPeopleByBirthSign(this IEnumerable<Person> people)
        {
            return people.GroupBy(x => x.BirthSign()).ToDictionary(x => x.Key, x => x.Count());
        }

        //HELPER METHOD - You do not need to use LINQ for this.
        /// <summary>
        /// Derives the Zodiac sign for an instance of Person based on its Birthdate property
        /// </summary>
        /// <param name="p">The target Person object whose Zodian sign will be derived</param>
        /// <returns>The ZodiacSign enum value for the target Person object</returns>
        public static ZodiacSign BirthSign(this Person p)
        {
            ZodiacSign retVal = default(ZodiacSign);
            int inDay = p.Birthdate.Day;
            int inMonth = p.Birthdate.Month;

            if (inMonth == 1 && inDay < 21)
            {
                retVal = ZodiacSign.Capricorn;
            }
            else if (inMonth == 1 && inDay >= 21)
            {
                retVal = ZodiacSign.Aquarius;
            }
            else if (inMonth == 2 && inDay < 20)
            {
                retVal = ZodiacSign.Aquarius;
            }
            else if (inMonth == 2 && inDay >= 20)
            {
                retVal = ZodiacSign.Pisces;
            }
            else if (inMonth == 3 && inDay < 21)
            {
                retVal = ZodiacSign.Pisces;
            }
            else if (inMonth == 3 && inDay >= 21)
            {
                retVal = ZodiacSign.Aries;
            }
            else if (inMonth == 4 && inDay < 21)
            {
                retVal = ZodiacSign.Aries;
            }
            else if (inMonth == 4 && inDay >= 21)
            {
                retVal = ZodiacSign.Taurus;
            }
            else if (inMonth == 5 && inDay < 22)
            {
                retVal = ZodiacSign.Taurus;
            }
            else if (inMonth == 5 && inDay >= 22)
            {
                retVal = ZodiacSign.Gemini;
            }
            else if (inMonth == 6 && inDay < 22)
            {
                retVal = ZodiacSign.Gemini;
            }
            else if (inMonth == 6 && inDay >= 22)
            {
                retVal = ZodiacSign.Cancer;
            }
            else if (inMonth == 7 && inDay < 23)
            {
                retVal = ZodiacSign.Cancer;
            }
            else if (inMonth == 7 && inDay >= 23)
            {
                retVal = ZodiacSign.Leo;
            }
            else if (inMonth == 8 && inDay < 23)
            {
                retVal = ZodiacSign.Leo;
            }
            else if (inMonth == 8 && inDay >= 23)
            {
                retVal = ZodiacSign.Virgo;
            }
            else if (inMonth == 9 && inDay < 24)
            {
                retVal = ZodiacSign.Virgo;
            }
            else if (inMonth == 9 && inDay >= 24)
            {
                retVal = ZodiacSign.Libra;
            }
            else if (inMonth == 10 && inDay < 24)
            {
                retVal = ZodiacSign.Libra;
            }
            else if (inMonth == 10 && inDay >= 24)
            {
                retVal = ZodiacSign.Scorpio;
            }
            else if (inMonth == 11 & inDay < 23)
            {
                retVal = ZodiacSign.Scorpio;
            }
            else if (inMonth == 11 & inDay >= 23)
            {
                retVal = ZodiacSign.Saggitarius;
            }
            else if (inMonth == 12 && inDay < 22)
            {
                retVal = ZodiacSign.Saggitarius;
            }
            else if (inMonth == 12 && inDay >= 22)
            {
                retVal = ZodiacSign.Capricorn;
            }

            return retVal;
        }
    }
}
