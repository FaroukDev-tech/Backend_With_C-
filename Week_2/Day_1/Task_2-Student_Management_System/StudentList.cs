using System;
using System.Text.Json;
using student_class;

namespace student_list_class
{
    public class StudentList<T> where T : Student
    {
        private List<T> students = [];

        public void Add(T student)
        {
            students.Add(student);
        }

        public List<T> Search(string term, string key = "")
        {
            IEnumerable<Student> query =
                from student in students
                where student.Name == term || student.StudentId.ToString() == term
                select student;

            List<T> results = [];
            foreach (T student in query.Cast<T>())
                results.Add(student);

            if (key == "name"){
                results.Sort(delegate(T obj1, T obj2) {return obj1.Name.CompareTo(obj2.Name);});
            } else if (key=="age"){
                results.Sort(delegate(T obj1, T obj2) {return obj1.Age.CompareTo(obj2.Age);});
            }
            return results;
        }

        public void UpdateStudentInfo(string name, string field, string term){
            field.ToLower();
            foreach(T student in students){
                if (student.Name==name){
                    if (field=="name"){
                        student.Name = term;
                    } else if (field=="age"){
                        student.Age = Convert.ToInt32(term);
                    } else if (field=="grade"){
                        student.Grade = Convert.ToInt32(term);
                    }
                    break;
                }
            }
        }

        public void DeleteStudent(string term){
            List<T> deleteObjs = Search(term);

            foreach(T student in deleteObjs){
                students.Remove(student);
            }
        }

        public void DisplayStudents()
        {
            Console.WriteLine("\nInformation of All Students in Database\n-------------------------------------\n");

            foreach (T student in students)
            {
                Console.WriteLine(student);
            }
        }

        public void Serialize(string file)
        {
            string jsonData = JsonSerializer.Serialize(students);
            File.WriteAllText(file, jsonData);
        }

        public void Deserialize(string file)
        {
            try
            {
                string? jsonString = File.ReadAllText(file);
                if (jsonString != null)
                {
                    students = JsonSerializer.Deserialize<List<T>>(jsonString);
                }
                else
                {
                    Console.WriteLine("File is empty.");
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"No file named {file} was found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred! Operation unsuccessful" + ex.Message);
            }
        }
    }
}