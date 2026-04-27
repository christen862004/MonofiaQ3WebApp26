
namespace MonofiaQ3WebApp26.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        ITIContext context;
        public DepartmentRepository(ITIContext context)
        {
            this.context = context;
                ;// new ITIContext();
        }
        //CRUD

        //odd
        public void Add(Department obj)
        {
            context.Department.Add(obj);
        }

        public void Delete(int id)
        {
            Department dept=GetById(id);
            context.Department.Remove(dept);
        }

        public List<Department> GetAll()
        {
            return context.Department.ToList();
        }

        public Department GetById(int id)
        {
            return context.Department.FirstOrDefault(d => d.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Department obj)
        {
            //context.Update(obj);
            Department dep=GetById(obj.Id);
            dep.Name=obj.Name;
            dep.ManagerName=obj.ManagerName;
        }
     
    }
}
