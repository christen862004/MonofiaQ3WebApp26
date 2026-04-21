

namespace MonofiaQ3WebApp26.ViewModels
{
    public class EmpWithDEptListViewModel
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public int NetSalary { get; set; }
        public string? ImageUrl { get; set; }
        public int DepartmentId { get; set; }

        public List<Department> DeptList { get; set; }
    }
}
