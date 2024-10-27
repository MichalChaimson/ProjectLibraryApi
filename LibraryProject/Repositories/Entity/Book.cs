using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Repositories.Enums;

namespace Repositories.Entity
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public CategoryType category { get; set; }
        public GenreType genre { get; set; }
        public StatusTypes Status { get; set; }
       public string ImagePath { get; set; }
        public string description { get; set; }


        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public virtual Author author { get; set; }

        //[ForeignKey("Response")]
        //public List<int> ResponseId { get; set; }
        public virtual ICollection<Responsee> responses { get; set; }

        //[ForeignKey("Borrowing")]
        //public List<int> BorrowingId { get; set; }
        public virtual ICollection<Borrowing> borrowings { get; set; }

        //[ForeignKey("Request")]
        //public List<int> RequestId { get; set; }
        public virtual ICollection<Requeste> requests { get; set; }
    }
}
