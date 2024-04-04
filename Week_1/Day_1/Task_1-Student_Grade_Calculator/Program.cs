// TASK 1 - STUDENT GRADE CALCULATOR
// DATE: 03/04/24

using System;
using System.Collections.Generic;
using System.Threading;

namespace Task_1{
    public class GradeCalculator{
        public static void Main(string[] args){
            Console.WriteLine("------------------------------");
            Console.WriteLine("Welcome To The Grade Calc App");
            Console.WriteLine("------------------------------");
            Console.WriteLine();

            string UserName = ReadString("Please enter your full name: ");
            int NumberOfSubjects = ReadNumber("Please enter number of subjects taken: ");
            Dictionary<string, int> UserRecords = [];
            double TotalMarks = 0;

            for (int i=1; i<=NumberOfSubjects; i++){
                string subjectName = "";
                int subjectGrade = 0;

                do {
                    subjectName = ReadString($"Enter subject #{i}: ");
                    subjectGrade = ReadNumber($"Enter marks(grade) for subject #{i} - {subjectName}: ");

                    if (UserRecords.ContainsKey(subjectName))
                        Console.WriteLine("Subject already exists in database, please provide new info");
                } while (UserRecords.ContainsKey(subjectName));

                UserRecords[subjectName] = subjectGrade;
                TotalMarks += subjectGrade;
            }
            
            Console.WriteLine();
            Console.WriteLine($"Please wait while we process and evaluate your performance...\n");
            Thread.Sleep(2000);
            Console.WriteLine($"Name of student: {UserName}");
            Console.WriteLine("---------------------------------------");
            
            foreach (string key in UserRecords.Keys){
                Thread.Sleep(1000);
                Console.WriteLine(string.Format("Subject: {0,-20} Grade: {1, -10}", key, UserRecords[key]));
            }
            Console.WriteLine();
            Console.WriteLine($"Calculated Average Grade: {TotalMarks/NumberOfSubjects}");
            Console.Beep();
        }

        public static int ReadNumber(string msg){
            int res = 0;
            string val = "";

            do{
                Console.Write(msg);
                val = Console.ReadLine();
            } while (!int.TryParse(val, out res));

            return res;
        }

        public static string ReadString(string msg){
            string res = "";

            do{
                Console.Write(msg);
                res = Console.ReadLine();
            } while (res=="");

            return res;
        }
    }
}