using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MirrorMirror.Models.ViewModels.Admin
{
    public class CreateFaceApiKeyVM
    {
        [Display(Name = "Cognitive services face api key")]
        [Required(ErrorMessage = "Enter your cognitive services face api key.")]
        public string ApiKey { get; set; }
    }
}
