﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Entity
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }

        //[ForeignKey("Book")]
        //public List<int> BookId { get; set; }
         public virtual  ICollection<Book> books { get; set; }
    }
}
