using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Entity
{
    public class Responsee
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        virtual public User user { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
        virtual public Book book { get; set; }
    }

}