﻿using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Areas.Admin.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "Lütfen rol ismini giriniz.")]
        public string Name { get; set; }
    }
}
