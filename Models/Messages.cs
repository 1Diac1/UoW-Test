using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportApplication.Models
{
    public class Messages
    {
        [Key]
        public int Id { get; set; }



        [Required(ErrorMessage = "Введите текст")]
        [StringLength(50)]
        [Display(Name = "Текст")]
        public string Text { get; set; }



        [Required(ErrorMessage = "Введите Email")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }



        [Required(ErrorMessage = "Введите номер телефона")]
        [Phone]
        [Display(Name = "Номер телефона")]
        public string Phone { get; set; }



        [Required(ErrorMessage = "Выберите дату")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

    }
}
