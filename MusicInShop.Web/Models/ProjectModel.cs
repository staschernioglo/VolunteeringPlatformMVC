using MusicInShop.BusinessLogic.DataTransfer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicInShop.Web.Models
{
    public class ProjectModel : NavbarModel
    {
        [Required]
        [Display(Name = "Название *")]
        public string Name { get; set; }
        [Display(Name = "Категория *")]
        public string Category { get; set; }
        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Дата")]
        [DataType(DataType.Date)]
        public string Date { get; set; }
        [Display(Name = "Город")]
        public string Town { get; set; }
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        [Display(Name = "Необходимое количество волонтёров")]
        public int RequiredNumberOfVolunteers { get; set; }
        [Display(Name = "Фото")]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        public IEnumerable<ProjectDTO> Projects { get; set; }
    }
}