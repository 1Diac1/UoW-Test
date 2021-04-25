using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportApplication.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }



        [Required(ErrorMessage = "Введите название книги")]
        [StringLength(50)]
        [Display(Name = "Имя")]
        public string Name { get; set; }



        [Required(ErrorMessage = "Введите цену для этой книги")]
        public decimal Price { get; set; }
    }
}
