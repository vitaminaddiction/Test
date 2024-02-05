using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DB
{
    public enum Gender
    {
        male, female
    }

    
    public class EmployeeForDB
    {
        public int ID { get; set; }
        public int DepID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string LoginID { get; set; }
        public string Password { get; set; }
        public string Rank { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string MessengerID { get; set; }
        public string Memo { get; set; }
        public Gender Gender { get; set; }
        public string OriginalFileName { get; set; }
        public string FileName { get; set; }

        public EmployeeForDB()
        {

        }

        public EmployeeForDB(int id, int depId, string code, string name, string loginId, string password, string rank, string state, string phone, string email, string messengerId, string memo, Gender gender)
        {
            this.ID = id;
            this.DepID = depId;
            this.Code = code;
            this.Name = name;
            this.LoginID = loginId;
            this.Password = password;
            this.Rank = rank;
            this.State = state;
            this.Phone = phone;
            this.Email = email;
            this.MessengerID = messengerId;
            this.Memo = memo;
            this.Gender = gender;
        }

        public EmployeeForDB(int id, int depId, string code, string name, string loginId, string password, string rank, string state, string phone, string email, string messengerId, string memo, Gender gender, string OriginalFileName)
        {
            this.ID = id;
            this.DepID = depId;
            this.Code = code;
            this.Name = name;
            this.LoginID = loginId;
            this.Password = password;
            this.Rank = rank;
            this.State = state;
            this.Phone = phone;
            this.Email = email;
            this.MessengerID = messengerId;
            this.Memo = memo;
            this.Gender = gender;
            this.OriginalFileName = OriginalFileName;
        }

        public EmployeeForDB(int depId, string code, string name, string loginId, string password, string rank, string state, string phone, string email, string messengerId, string memo, Gender gender)
        {
            this.DepID = depId;
            this.Code = code;
            this.Name = name;
            this.LoginID = loginId;
            this.Password = password;
            this.Rank = rank;
            this.State = state;
            this.Phone = phone;
            this.Email = email;
            this.MessengerID = messengerId;
            this.Memo = memo;
            this.Gender = gender;
        }

        public EmployeeForDB(int depId, string code, string name, string loginId, string password, string rank, string state, string phone, string email, string messengerId, string memo, Gender gender, string OriginalFileName)
        {
            this.DepID = depId;
            this.Code = code;
            this.Name = name;
            this.LoginID = loginId;
            this.Password = password;
            this.Rank = rank;
            this.State = state;
            this.Phone = phone;
            this.Email = email;
            this.MessengerID = messengerId;
            this.Memo = memo;
            this.Gender = gender;
            this.OriginalFileName = OriginalFileName;
        }

        public EmployeeForDB(int depId, string code, string name, string rank, string state, string phone, string email, string messengerId, string memo, Gender gender, string OriginalFileName, string FileName)
        {
            this.DepID = depId;
            this.Code = code;
            this.Name = name;
            this.Rank = rank;
            this.State = state;
            this.Phone = phone;
            this.Email = email;
            this.MessengerID = messengerId;
            this.Memo = memo;
            this.Gender = gender;
            this.OriginalFileName = OriginalFileName;
            this.FileName = FileName;
        }
    }
}
