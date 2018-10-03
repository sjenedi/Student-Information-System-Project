using System;
using System.IO;

/**
 * @author Sami Jenedi
 * class Program create a student information
 * management system and this program provides
 * a simple interface for maintenance of student information.
 */

namespace SISProject
{
    class SISDriver
    {
        
        private Student[] students;
        private const int MAX_STUDENTS = 100;
        private int numStudents=0;

    public SISDriver()
    {
            StreamReader InFile = new StreamReader("students.txt");
            while (InFile.ReadLine()!=null)
                numStudents ++;

            InFile.Close();

            students=new Student[MAX_STUDENTS];

    }

    /**
    * ReadData opens the file from the source code folder in the project.
    * @param outFile input file. */
    public void ReadData(string outFile)
    {
            string[] Myarray = File.ReadAllLines(outFile);
           
         for (int i = 0; i < Myarray.Length; i++)
			{
			     string[] data= Myarray[i].Split(',');
           students[i] = new Student(data[0], data[1],data[2],
           Convert.ToDecimal(data[3]),Convert.ToDouble(data[4]));
			}
    }

    /**
    * StoreData opens project source files.
    * @param outFile stores an opened output file stream. */
    public void StoreData(string outFile)
        {
            for (int i = 0; i < numStudents; i++)
            {
                students[i].Store(outFile);
            }
        }

    /**
   * LookUp Performs a linear search.
   * @param StudentId represents a student id. */
    public int LookUp(string StudentId)
        {
            for (int i = 0; i < numStudents; i++)
            {
                if (students[i].StudentId==StudentId)
                {
                    return i;
                }
            }
            return -1;
    }

    /**
    * Run Runs the program.*/   
    public void Run()
        {
            string id;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1) Display student record");
                Console.WriteLine("2) Change GPA");
                Console.WriteLine("3) Make payment");
                Console.WriteLine("4) Exit");

                Console.WriteLine();
                Console.Write("Your Choice: ");              
                int key = Convert.ToInt32(Console.ReadLine());            
                switch (key)
                {
                    case 4:
                        Console.WriteLine("Good-bye");
                        Environment.Exit(0);
                        break;
                    case 1:           
                        Console.Write("Student ID: ");
                        id = Console.ReadLine();
                        ReadData("students.txt");
                        if (LookUp(id)==-1)
                        {
                            Console.WriteLine("Student not found.");
                        }
                        else
                        {
                            Console.WriteLine(students[LookUp(id)].ToString());
                        }
                       Console.WriteLine("Press a key to continue... ");
                       Console.ReadLine();
                       break;

                   case 2:
                        Console.Write("Student ID: ");
                        id = Console.ReadLine();
                        ReadData("students.txt");
                        if (LookUp(id)==-1)
                        {
                            Console.WriteLine("Student not found.");
                            Console.WriteLine("Press a key to continue... ");
                            Console.ReadLine();
                        }
                        else
                        {
                           Console.WriteLine("Current GPA: {0}"
                              ,students[LookUp(id)].Gpa);
                           Console.Write("New GPA: ");
                           string newgpa =Console.ReadLine();
                           students[LookUp(id)].Gpa = Convert.ToDouble(newgpa);
                           File.Delete("students.txt");
                            for (int i = 0; i < numStudents; i++)
                            {
                                students[i].Store("students.txt");
                            }
                        }
                           Console.WriteLine("Press a key to continue... ");
                           Console.ReadLine();
                           break;
                    case 3:
                            Console.Write("Student ID: ");
                            id = Console.ReadLine();
                            ReadData("students.txt");
                            if (LookUp(id) == -1)
                            {
                                Console.WriteLine("Student not found.");
                            }
                            else
                            {
                                Console.WriteLine("Current Balance: $ {0}"
                                  , students[LookUp(id)].TuitionBalance);
                                Console.Write("Payment: $ ");
                                string payment = Console.ReadLine();
                                students[LookUp(id)].MakePayment
                                (Convert.ToDecimal(payment));
                                File.Delete("students.txt");
                                for (int i = 0; i < numStudents; i++)
                                {
                                    students[i].Store("students.txt");
                                }
                            }
                               Console.WriteLine("Press a key to continue...");
                               Console.ReadLine();
                        break;

                    default:
                        Console.WriteLine("Try Again.");
                        Console.WriteLine("Press a key to continue...");
                        Console.ReadLine();
                        break;
                }
            }
       }
    }
}
