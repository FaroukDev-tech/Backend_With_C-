using System;
using student_class;
using student_list_class;

class Program
{
    static void Main(string[] args)
    {
        StudentList<Student> studentList = new ();

        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\nStudent Management System");
            Console.WriteLine("1. Add New Student");
            Console.WriteLine("2. Update Student Record");
            Console.WriteLine("3. Delete Student Record");
            Console.WriteLine("4. Search for Student");
            Console.WriteLine("5. Display All Students");
            Console.WriteLine("6. Serialize Student Data");
            Console.WriteLine("7. Deserialize Student Data");
            Console.WriteLine("8. Exit");

            Console.Write("\nEnter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Student Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Student Age: ");
                    int age = int.Parse(Console.ReadLine());
                    Console.Write("Enter Student Grade: ");
                    int grade = int.Parse(Console.ReadLine());

                    Student newStudent = new() { Name = name, Age = age, Grade = grade };
                    studentList.Add(newStudent);
                    Console.WriteLine("Student added successfully.");
                    break;

                case "2":
                    Console.Write("Enter Student Name: ");
                    string student_name = Console.ReadLine();
                    Console.Write("Enter Field To Be Updated (name or age): ");
                    string field = Console.ReadLine();
                    Console.Write("Enter new value: ");
                    string val = Console.ReadLine();
                    studentList.UpdateStudentInfo(student_name, field, val);
                    Console.WriteLine("Student info updated successfully.");
                    break;

                case "3":
                    Console.Write("Enter name or student id to be removed from records: ");
                    string term = Console.ReadLine();
                    studentList.DeleteStudent(term);
                    Console.WriteLine("Student record deleted successfully.");
                    break;

                case "4":
                    Console.Write("Enter search term (name or student id): ");
                    string searchTerm = Console.ReadLine();
                    List<Student> searchResults = studentList.Search(searchTerm);
                    if (searchResults.Count > 0)
                    {
                        Console.WriteLine("Search Results:");
                        foreach (var student in searchResults)
                        {
                            Console.WriteLine(student);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No matching students found.");
                    }
                    break;

                case "5":
                    studentList.DisplayStudents();
                    break;

                case "6":
                    Console.Write("Enter file path to save student data (e.g., student.json): ");
                    string serializeFilePath = Console.ReadLine();
                    studentList.Serialize(serializeFilePath);
                    Console.WriteLine("Serializing of file finished");
                    break;

                case "7":
                    Console.Write("Enter file path to load student data from (e.g., student.json): ");
                    string deserializeFilePath = Console.ReadLine();
                    studentList.Deserialize(deserializeFilePath);
                    Console.WriteLine("Deserializing of file finished");
                    break;

                case "8":
                    isRunning = false;
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
