using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DB
{
    public class Employee
    {
        public int id { get; set; }
        public int depId { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string loginId { get; set; }
        public string password { get; set; }
        public string rank { get; set; }
        public string state { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string messengerId { get; set; }
        public string memo { get; set; }
        public char gender { get; set; }

        public Employee()
        {

        }
        public Employee(int id, int depId, string code, string name, string loginId, string password, string rank, string state, string phone, string email, string messengerId, string memo, char gender)
        {
            this.id = id;
            this.depId = depId;
            this.code = code;
            this.name = name;
            this.loginId = loginId;
            this.password = password;
            this.rank = rank;
            this.state = state;
            this.phone = phone;
            this.email = email;
            this.messengerId = messengerId;
            this.memo = memo;
            this.gender = gender;
        }

        public Employee(int depId, string code, string name, string loginId, string password, string rank, string state, string phone, string email, string messengerId, string memo, char gender)
        {
            this.depId = depId;
            this.code = code;
            this.name = name;
            this.loginId = loginId;
            this.password = password;
            this.rank = rank;
            this.state = state;
            this.phone = phone;
            this.email = email;
            this.messengerId = messengerId;
            this.memo = memo;
            this.gender = gender;
        }

        public Employee(int depId, string code, string name, string rank, string state, string phone, string email, string messengerId, string memo, char gender)
        {
            this.depId = depId;
            this.code = code;
            this.name = name;
            this.rank = rank;
            this.state = state;
            this.phone = phone;
            this.email = email;
            this.messengerId = messengerId;
            this.memo = memo;
            this.gender = gender;
        }
    }
}
