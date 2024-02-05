using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Test.DB
{
    public class DepartmentForDB
    {
        public int ID { get; set; }
        [DisplayName("부서 코드")]
        public string Code { get; set; }
        [DisplayName("부서명")]
        public string Name { get; set; }
        [DisplayName("메모")]
        public string Memo { get; set; }

        public DepartmentForDB(string code, string name, string memo)
        {
            this.Code = code;
            this.Name = name;
            this.Memo = memo;
        }

        public DepartmentForDB(int id, string code, string name , string memo)
        {
            this.ID = id;
            this.Code = code;
            this.Name = name;
            this.Memo = memo;
        }

        public override string ToString()
        {
            return $"Department : {{ id : {ID}, code : {Code}, name : {Name}, memo : {Memo} }}";
        }
    }
}
