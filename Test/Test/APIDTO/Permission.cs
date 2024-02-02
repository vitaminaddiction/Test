using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.APIDTO
{
    public class Permission
    {
        public Nullable<long> EmployeeId { get; set; }
        public string Menu { get; set; }
        public bool? CanCreate { get; set; }
        public Nullable<bool> CanRead { get; set; }
        public Nullable<bool> CanUpdate { get; set; }
        public Nullable<bool> CanDelete { get; set; }


        public Permission(long EmployeeId, string Menu, bool CanCreate, bool CanRead, bool CanUpdate, bool CanDelete)
        {
            this.EmployeeId = EmployeeId;
            this.Menu = Menu;
            this.CanCreate = CanCreate;
            this.CanRead = CanRead;
            this.CanUpdate = CanUpdate;
            this.CanDelete = CanDelete;
        }
    }
}
