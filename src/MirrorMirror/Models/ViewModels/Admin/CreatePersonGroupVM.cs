using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MirrorMirror.Models.ViewModels.Admin
{
    public class CreatePersonGroupVM
    {
        [Display(Name = "Persongroup ID")]
        [Required(ErrorMessage = "Enter your desired persongroup ID")]
        public string PersonGroupID { get; set; }

        [Display(Name = "Persongroup name")]
        [Required(ErrorMessage = "Enter your desired persongroup name")]
        public string PersonGroupName { get; set; }
    }
}
