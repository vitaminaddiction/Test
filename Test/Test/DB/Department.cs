using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DB
{
    class Department
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string memo { get; set; }

        public Department(string code, string name, string memo)
        {
            this.code = code;
            this.name = name;
            this.memo = memo;
        }

        public Department(int id, string code, string name , string memo)
        {
            this.id = id;
            this.code = code;
            this.name = name;
            this.memo = memo;
        }


        public override string ToString()
        {
            return $"Department : {{ id : {id}, code : {code}, name : {name}, memo : {memo} }}";
        }
    }
}
