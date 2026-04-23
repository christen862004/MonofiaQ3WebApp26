using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonofiaQ3WebApp26.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is Requird")]
        [MinLength(3,ErrorMessage ="NAme Must be more 2 char")]
        [MaxLength(25)]
        [Unique]
        //[StringLength(25,MinimumLength =3)]
        public string Name { get; set; }
        //[Required] //check value not equal null
        //[Range(8000,50000)]
        //[GreaterThan(CompareVal =8000)]
        //[GreaterThan(8000)]
        [Remote("CheckSalary","Employee",AdditionalFields = "DepartmentId")]
        public int Salary { get; set; }
        [RegularExpression(@"\w+\.(jpg|png)",ErrorMessage ="Image must be jpg or png")]//dsfd.jpg or hjgjh.png
        public string? ImageUrl { get; set; }
        [ForeignKey("Department")]
        //[Required]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
