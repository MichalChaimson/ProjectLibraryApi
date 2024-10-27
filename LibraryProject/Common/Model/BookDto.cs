using Repositories.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Repositories.Enums;

namespace Common.Model
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public CategoryType category { get; set; }
        public GenreType genre { get; set; }
        public StatusTypes Status { get; set; }
        public int AuthorId { get; set; }
       public string ImagePath { get; set; }
       public string Description { get; set; }
        public virtual ICollection<ResponseDto> responses { get; set; }

    }
}
