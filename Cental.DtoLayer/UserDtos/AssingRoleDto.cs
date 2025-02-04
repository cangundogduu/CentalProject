using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.UserDtos
{
    public class AssingRoleDto
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool RoleExist { get; set; }
    }
}
