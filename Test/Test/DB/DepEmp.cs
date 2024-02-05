using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Test.DB
{
    public class DepEmp
    {
        public DepartmentForDB Department { get; set; }
        public EmployeeForDB Employee { get; set; }


        public int DepID { get; set; }
        [DisplayName("부서 코드")]
        public string DepCode { get; set; }
        [DisplayName("부서명")]
        public string DepName { get; set; }
        [DisplayName("메모")]
        public string DepMemo { get; set; }


        public int EmpID { get; set; }
        public int DepID_FK { get; set; }
        [DisplayName("사원 코드")]
        public string EmpCode { get; set; }
        [DisplayName("사원명")]
        public string EmpName { get; set; }
        [DisplayName("로그인ID")]
        public string LoginID { get; set; }
        [DisplayName("비밀번호")]
        public string Password { get; set; }
        [DisplayName("직위")]
        public string Rank { get; set; }
        [DisplayName("고용형태")]
        public string State { get; set; }
        [DisplayName("휴대전화")]
        public string Phone { get; set; }
        [DisplayName("이메일")]
        public string Email { get; set; }
        [DisplayName("메신저ID")]
        public string MessengerID { get; set; }
        [DisplayName("메모")]
        public string EmpMemo { get; set; }
        [DisplayName("성별")]
        public Gender Gender { get; set; }
        [DisplayName("원본 파일 이름")]
        public string OriginalFileName { get; set; }
        public string FileName { get; set; }

        public DepEmp(int DepID, string DepCode, string DepName, string DepMemo, int EmpID, int DepID_FK, string EmpCode, string EmpName, string LoginID, string Password, string Rank, string State, string Phone, string Email, string MessengerID, string EmpMemo, Gender Gender, string OriginalFileName, string FileName)
        {
            this.DepID = DepID;
            this.DepCode = DepCode;
            this.DepName = DepName;
            this.DepMemo = DepMemo;
            this.EmpID = EmpID;
            this.DepID_FK = DepID_FK;
            this.EmpCode = EmpCode;
            this.EmpName = EmpName;
            this.LoginID = LoginID;
            this.Password = Password;
            this.Rank = Rank;
            this.State = State;
            this.Phone = Phone;
            this.Email = Email;
            this.MessengerID = MessengerID;
            this.EmpMemo = EmpMemo;
            this.Gender = Gender;
            this.OriginalFileName = OriginalFileName;
            this.FileName = FileName;
            this.Department = new DepartmentForDB(DepID, DepCode, DepName, DepMemo);
            this.Employee = new EmployeeForDB(EmpID, DepID_FK, EmpCode, EmpName, LoginID, Password, Rank, State, Phone, Email, MessengerID, EmpMemo, Gender, OriginalFileName);
        }
        
    }
}
