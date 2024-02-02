using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.APIDTO
{
    public class Employee
    {
        [DisplayName("ID")]
        public long Id { get; set; }
        [DisplayName("공장 ID")]
        public long FactoryId { get; set; }
        [DisplayName("공장 명")]
        public string FactoryName { get; set; }
        [DisplayName("부서 ID")]
        public long DepartmentId { get; set; }
        [DisplayName("부서 코드")]
        public string DepartmentCode { get; set; }
        [DisplayName("부서명")]
        public string DepartmentName { get; set; }
        [DisplayName("부서 메모")]
        public string DepartmentMemo { get; set; }
        [DisplayName("사원 코드")]
        public string Code { get; set; }
        [DisplayName("사원명")]
        public string Name { get; set; }
        [DisplayName("직위")]
        public string Position { get; set; }
        [DisplayName("고용 형태")]
        public string ContractType { get; set; }
        [DisplayName("사원 메모")]
        public string Memo { get; set; }
        [DisplayName("로그인 여부")]
        public bool UseLogin { get; set; }
        [DisplayName("로그인 ID")]
        public string LoginId { get; set; }
        [DisplayName("비밀번호")]
        public string LoginPassword { get; set; }
        [DisplayName("로그인 태그")]
        public string LoginTag { get; set; }
        [DisplayName("전화번호")]
        public string PhoneNumber { get; set; }
        [DisplayName("이메일")]
        public string Email { get; set; }
        [DisplayName("메신저 ID")]
        public string MessengerId { get; set; }
        [DisplayName("관리자 여부")]
        public bool IsAdmin { get; set; }
        [DisplayName("다중 소속")]
        public bool HasMultifactory { get; set; }
        public List<Permission> Permission = new List<Permission>();
    }
}
