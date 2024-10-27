using Repositories.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? countRequests { get; set; }
       public virtual  ICollection<BorrowingDto> borrowings { get; set; }
       public virtual  ICollection<RequestDto> requests { get; set; }

    }
}
