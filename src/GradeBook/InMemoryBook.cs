using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(char letter) 
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;

                case 'C':
                    AddGrade(70);
                    break;

                default:
                    AddGrade(0);
                    break;
            }
        }

        public override void AddGrade(double grade) 
        {
            if(grade <= 100 && grade > 0) 
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this,  new EventArgs());
                }
            }
            else 
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            foreach(double grade in grades) 
            {
                result.Add(grade);
            }

            return result;
        }

        private List<double> grades;

        public string Name
        {
            get; 
            set;
        }

        public const string CATEGORY = "Science";
    }
}
