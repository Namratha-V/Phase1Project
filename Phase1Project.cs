using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Practice
{
    class Teacherdata
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sub { get; set; }
        public string Section { get; set; }
    }

    class Code
    {
        static string fpath = @"C:\Users\11033259\Desktop\fresher_training\Teacher_records.txt";
        static List<Teacherdata> teachers = new List<Teacherdata>();
        static void Main(string[] args)
        {
            Console.WriteLine("~~~~~~~~~~~~~~ Rainbow School  **WELCOME** ~~~~~~~~~~~~~~\n");


            Console.WriteLine("Choose the required option");
            Console.WriteLine("1.Display all the teacher records\n2.Add teacher to the record \n3.Delete teacher record\n4.Update teacher record\n5.Get Teacher record using ID\n6.Exit\n");
            //                int Key = System.Convert.ToInt32(Console.ReadLine());
            int Key = System.Convert.ToInt32(Console.ReadLine());

            switch (Key)
            {
                //DISPLAY ALLL THE TEACHER RECORDS
                case 1:
                    Display_Records();
                    break;

                //ADD TEACHER TO THE RECORD
                case 2:
                    // Id should be unique always and we have to handle that.
                    Add_Teacher();
                    break;

                //DELETE TEACHER FROM THE RECORD
                case 3:
                    Delete_Teacher();
                    break;

                //UPDATE TEACHER RECORD
                case 4:
                    Update_Teacher();
                    break;

                //GET TEACHER DETAILS BY ID
                case 5:
                    Get_teacher_details_by_ID();
                    break;


                //break;

                default:
                    Console.WriteLine("Invalid input!!");
                    break;

            }
        }

        static public void Display_Records()
        {

            List<string> lines = File.ReadAllLines(fpath).ToList();
            foreach (var line in lines)
            {
                string[] entries = line.Split(',');
                //Reading from the file ,Splitting up by ',' and storing in the entries array
                Teacherdata newTeacher = new Teacherdata();
                try
                {
                    if (entries.Length == 4)
                    {
                        newTeacher.Id = Convert.ToInt32(entries[0]); ;
                        newTeacher.Name = entries[1];
                        newTeacher.Sub = entries[2];
                        newTeacher.Section = entries[3];
                        teachers.Add(newTeacher);

                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.WriteLine($"ID: {newTeacher.Id}, Name: {newTeacher.Name}, Class: {newTeacher.Sub}, Section: {newTeacher.Section}");
                    }
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine("Input text on file is not valid" + ex);
                }
            }
        }

        static public void Add_Teacher()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("ADD TEACHER DETAILS");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Enter Teacher ID: ");
            int tid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Teacher Name");
            string tname = Console.ReadLine();
            Console.WriteLine("Enter the Subject");
            string tsub = Console.ReadLine();
            Console.WriteLine("Enter the Section");
            string tsec = Console.ReadLine();

            teachers.Add(new Teacherdata { Id = tid, Name = tname, Sub = tsub, Section = tsec });
            List<string> output = new List<string>();
            foreach (var item in teachers)
            {
                output.Add($"{item.Id},{item.Name},{item.Sub},{item.Section}");
            }
            Console.WriteLine("**********************************************************");
            Console.WriteLine("Teacher added successfully");
            Console.WriteLine("**********************************************************");
            File.AppendAllLines(fpath, output);



        }

        static public void Delete_Teacher()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("DELETE TEACHER RECORD");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Enter the Teacher ID to delete from the record");
            string tdelete = Console.ReadLine();
            string tremove = Console.ReadLine();
            try
            {
                List<string> files = new List<string>(System.IO.File.ReadAllLines(fpath));
                List<string> newfile = new List<string>();
                foreach (var item in files)
                {
                    if (item.StartsWith(tremove))
                    {
                        //DO NOTHING 
                    }
                    else
                    {
                        newfile.Add(item);
                        File.WriteAllLines(fpath, newfile.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occurred" + ex.Message);
            }
            Console.WriteLine("***************************************************");
            Console.WriteLine("Deleted teacher data successfully");
            Console.WriteLine("***************************************************");
        }

        static public void Update_Teacher()
        {

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("UPDATE TEACHER RECORD");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Enter the Teacher ID to update the record");
            string tupdate = Console.ReadLine();
            List<string> update = new List<string>(System.IO.File.ReadAllLines(fpath));
            List<string> updated = new List<string>();
            foreach (var item in update)
            {
                if (item.StartsWith(tupdate))
                {
                    Teacherdata entry = new Teacherdata();
                    Console.WriteLine("Enter Teacher details to update");
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("Enter Teacher Name");
                    string name = Console.ReadLine();
                    Console.WriteLine($"Enter the Subject");
                    string sub = Console.ReadLine();
                    Console.WriteLine($"Enter the Section");
                    string sec = Console.ReadLine();
                    teachers.Add(new Teacherdata { Id = Convert.ToInt32(tupdate), Name = name, Sub = sub, Section = sec });
                    foreach (var items in teachers)
                    {
                        updated.Add($"{items.Id},{items.Name},{items.Sub},{items.Section}");
                    }
                    File.WriteAllLines(fpath, updated.ToArray());
                }
                else
                {
                    updated.Add(item);
                    File.WriteAllLines(fpath, updated.ToArray());
                }



            }
        }


        static public void Get_teacher_details_by_ID()
        {

            Console.WriteLine("Enter The ID of the Teacher to obtain the data");
            string tdata = Console.ReadLine();
            List<string> file = new List<string>(System.IO.File.ReadAllLines(fpath));
            foreach (var item in file)
            {
                if (item.StartsWith(tdata))
                {
                    string[] entries = item.Split(',');
                    Teacherdata entry = new Teacherdata();
                    entry.Id = Convert.ToInt32(entries[0]);
                    entry.Name = entries[1];
                    entry.Sub = entries[2];
                    entry.Section = entries[3];
                    Console.WriteLine($"ID: {entry.Id}, Name: {entry.Name}, Class: {entry.Sub}, Section: {entry.Section}\n");

                }
            }

        }

    }
}