using System;
using System.Collections.Generic;

namespace student_class{
    public class Student{
        public static int RollNumber = 1;
        public required string Name {get; set;}
        public readonly int StudentId;
        public int Age {get; set;}
        public int Grade {get; set;}

        public Student() { 
            StudentId = RollNumber;
            RollNumber++;
        }

        public override string ToString(){
            return $"Student Name: {Name}\nRoll Number: {StudentId}\nAge: {Age}\nGrade: {Grade}\n";
        }
    }
}