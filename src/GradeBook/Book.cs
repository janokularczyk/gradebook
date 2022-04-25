namespace GradeBook
{
    public abstract class Book : NamedObject
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract void AddGrade(double grade);
    }
}
