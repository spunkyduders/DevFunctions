namespace DevFunctionsLib
{
    public class Student
    {

        public Student(string name, int marksAvg)
        {
            this.Name = name;   
            this.MarksAvg = marksAvg;   
        }
        public string Name { get; set; }
        public int MarksAvg { get; set; }
        public override string ToString() => $"Name:{Name} Marks:{MarksAvg}";

    }
}