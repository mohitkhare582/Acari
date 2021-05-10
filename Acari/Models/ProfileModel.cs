using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;

namespace Acari.Models
{
    public class ProfileModel
    {
        [Required]
        [Url(ErrorMessage = "Url not proper.")]
        public string URL { get; set; }

    }
}


