using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolEF
{
    class Program
    {
        static void Main(string[] args)
        {
            // Database accessor. This opens the database automatically
            var school = new SchoolEntities();

            // This accesses the ClassMaster table
            // Class Roster
            foreach (var classMaster in school.ClassMasters)
            {
                Console.WriteLine("ClassId: {0}\nClassName: {1}\nClassDescription: {2}\nClassPrice: {3}\n",
                    classMaster.ClassId, classMaster.ClassName, classMaster.ClassDescription, classMaster.ClassPrice);

                foreach (var user in classMaster.Users)
                {
                    Console.WriteLine(user.UserName);
                }
            }

            Console.WriteLine("----");

            // Student Classlist
            foreach (var user in school.Users)
            {
                Console.WriteLine(user.UserName);
                //foreach (var classMaster in user.ClassMasters)
                //{
                //    Console.WriteLine($"{classMaster.ClassId} - {classMaster.ClassName}");
                //}

                // OR

                var classes = school.RetrieveClassesForStudent(user.UserId);
                foreach (var item in classes) // classes is {userId, classId}
                {
                    var classMaster = school.ClassMasters.First(t => t.ClassId == item.ClassId);
                    Console.WriteLine($"{classMaster.ClassId} - {classMaster.ClassName}");

                }

            }

            Console.Write("Done.");
            Console.ReadLine();
        }
    }
}
