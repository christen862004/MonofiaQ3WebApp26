namespace MonofiaQ3WebApp26.ViewModels
{
    public class EmpNAmeWithDeptListTempMsgColorViewModel
    {
        //Some Model Property + Hide Table Structure
        public string EmpName { get; set; }
        public int  EmpId { get; set; }
        //Extra info
        public string Message { get; set; }
        public string Color { get; set; }
        public int Temp { get; set; }
        //Merge Another Model

        public List<string> DeptList { get; set; } = new List<string>();
    }
}
