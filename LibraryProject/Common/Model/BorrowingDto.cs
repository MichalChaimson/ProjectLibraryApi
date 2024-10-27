using Repositories.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Common.Model
{
    public enum StatusTypes { Taken, Saved, Available }
    public class BorrowingDto
    {
        public int Id { get; set; }
        public DateTime DateTake { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }


    }
}
