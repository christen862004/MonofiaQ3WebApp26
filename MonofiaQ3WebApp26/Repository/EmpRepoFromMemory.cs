
namespace MonofiaQ3WebApp26.Repository
{
    public class EmpRepoFromMemory : IEmployeeRepository
    {
        public void Add(Employee obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        List<Employee> emps;
        public EmpRepoFromMemory()
        {
            emps = new List<Employee>() { new Employee() { Id=1,Name="ahmed"},new Employee() { Id=2,Name="Mona"}
            };
        }
        public List<Employee> GetAll()
        {
            return emps;
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Employee obj)
        {
            throw new NotImplementedException();
        }
    }
}
