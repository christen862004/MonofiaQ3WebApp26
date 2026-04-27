
namespace MonofiaQ3WebApp26.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        ITIContext context;
        public EmployeeRepository(ITIContext context)
        {
            this.context = context;// new ITIContext();
        }
        //CRUD :Create - Get -Update - Delete
        public void Add(Employee obj)
        {
           context.Employees.Add(obj);
        }

        public void Delete(int id)
        {
            Employee emp = GetById(id);
            context.Employees.Remove(emp);
        }

        public List<Employee> GetAll()
        {
            return context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return context.Employees.FirstOrDefault(e => e.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Employee obj)
        {
            Employee empFromDb=GetById(obj.Id);
            empFromDb.Name = obj.Name;
            empFromDb.Salary = obj.Salary;
            empFromDb.ImageUrl = obj.ImageUrl;
            empFromDb.DepartmentId = obj.DepartmentId;
            
        }
    }
}
