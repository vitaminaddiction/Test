using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.APIDTO
{
    public class Department
    {
        [DisplayName("ID")]
        public long Id { get; set; }
        [DisplayName("공장 ID")]
        public long FactoryId { get; set; }
        [DisplayName("공장 코드")]
        public string FactoryCode { get; set; }
        [DisplayName("공장명")]
        public string FactoryName { get; set; }
        [DisplayName("부서 코드")]
        public string Code { get; set; }
        [DisplayName("부서명")]
        public string Name { get; set; }
        [DisplayName("부서 메모")]
        public string Memo { get; set; }
        [DisplayName("상위 부서 ID")]
        public Nullable<long> UpperDepartmentId { get; set; }
        [DisplayName("상위 부서 코드")]
        public string UpperDepartmentCode { get; set; }
        [DisplayName("상위 부서명")]
        public string UpperDepartmentName { get; set; }
    }
}
