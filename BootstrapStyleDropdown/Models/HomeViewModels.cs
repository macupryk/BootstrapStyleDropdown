using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BootstrapStyleDropdown.Models
{
    public class DropdownViewModel
    {
        [Display(Name = "Choose country")]
        public int? SelectedCountryId { get; set; }
    }
}
