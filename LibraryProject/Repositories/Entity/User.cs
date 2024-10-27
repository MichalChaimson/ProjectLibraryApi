using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Repositories.Entity
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int countRequests { get; set; } = 0;

        // רשימת ספרים שהשאיל
        public List<Book> books { get; set; }
        //[ForeignKey("Borrowing")]
        //public List<int> borrowingsId { get; set; }
        public virtual ICollection<Borrowing> borrowings { get; set; }
      //  public virtual ICollection<Borrowing> res { get; set; }
        
    }
}
