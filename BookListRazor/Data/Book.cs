using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Data
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "نام کتاب را وارد کنید")]
        public string Name { get; set; }

        [Required(ErrorMessage = "نام نویسنده را وارد کنید")]
        public string Author { get; set; }

        [Required(ErrorMessage = "شماره شابک را وارد کنید")]
        public string ISBN { get; set; }
    }
}
