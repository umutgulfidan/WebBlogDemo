using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Areas.Admin.Models
{
    public class RoleUpdateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Bir rol ismi girmelisiniz")]
        public string Name { get; set; }
    }
}
