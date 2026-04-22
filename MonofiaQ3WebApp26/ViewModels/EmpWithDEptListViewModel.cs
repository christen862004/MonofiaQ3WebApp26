using System.ComponentModel.DataAnnotations;

namespace MonofiaQ3WebApp26.ViewModels
{
    public class EmpWithDEptListViewModel
    {
        public int Id { get; set; }
        [Display(Name ="Employee Name")]//piroity =1
        [DataType(DataType.EmailAddress)] //(type="passwor"
        public string EmpName { get; set; } //Periority = 2 (string =text ,int= number ,bool =check)
        public int NetSalary { get; set; }
        public string? ImageUrl { get; set; }
        public int DepartmentId { get; set; }

        public List<Department> DeptList { get; set; }
    }
}
