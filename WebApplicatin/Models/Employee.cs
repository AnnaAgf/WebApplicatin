using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplicatin.Models
{
    public class EmployeeView
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Не может быть пустым")]
        [Display(Name = "Имя")]
        [StringLength(maximumLength:20, MinimumLength =1, ErrorMessage = "От 1-20 символов в имени")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Не может быть пустым")]
        [Display(Name = "Фамилия")]
        public string SurName { get; set; }

        [Display(Name = "Степень навыков")]
        public string Skill { get; set; }

        [Required]
        [Display(Name = "Страна")]
        public string Country { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Не может быть пустым")]
        [Display(Name = "Возраст")]
        public int Age { get; set; }

        [Display(Name = "Рост")]
        public int Height { get; set; }
    }
}
