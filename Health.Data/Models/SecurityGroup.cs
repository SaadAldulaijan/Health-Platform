using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health.Data.Models
{
    public class SecurityGroup : BaseMode<int>
    {
        public string Name { get; set; }
    }

    public class Permission 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Parent { get; set; }
    }

    public class GroupPermission
    {
        public int SecurityGroupId { get; set; }
        public SecurityGroup SecurityGroup { get; set; }
        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
