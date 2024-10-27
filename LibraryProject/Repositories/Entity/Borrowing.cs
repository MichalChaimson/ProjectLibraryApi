using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Entity
{
    public class Borrowing
    {
        public int Id { get; set; }
        public DateTime DateTake { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
         public virtual User user { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
         public virtual Book book { get; set; }
    }
}
