namespace MonofiaQ3WebApp26.Models
{
    public class StudentBL
    {
        List<Student> students;
        public StudentBL()
        {
            students = new List<Student>() { 
                new Student(){Id=1,Name="Ahme",Address="alex",ImageURl="m.png"},
                new Student(){Id=2,Name="omar",Address="alex",ImageURl="m.png"},
                new Student(){Id=3,Name="sara",Address="alex",ImageURl="2.jpg"},
                new Student(){Id=4,Name="mona",Address="alex",ImageURl="2.jpg"},
            };
        }

        public List<Student> GetAll()
        {
            return students;
        }
        public Student GetById(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

    }
}
