using System.ComponentModel.DataAnnotations;

namespace MonofiaQ3WebApp26.Models
{
    //Web api ,mvc
    //server side only
    public class UniqueAttribute:ValidationAttribute
    {
        //cant ask ioc continer
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string name = value.ToString();

            Employee EmpFromReq= validationContext.ObjectInstance as Employee;

            ITIContext context = validationContext.GetRequiredService<ITIContext>();//ask Service Provider
            Employee? EmpFromDb= context.Employees
                .FirstOrDefault(e=>e.Name == name&&e.DepartmentId==EmpFromReq.DepartmentId);//unique name per departmeny

            if (EmpFromDb == null)
            {
                return ValidationResult.Success;//valiad
            }
            return new ValidationResult("Name Already Exist :(");//not valid
        }
    }
}
