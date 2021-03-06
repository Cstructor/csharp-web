using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HelloWorld.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Please enter your name")] 
        public string Name { get; set; }

        public string Phone { get; set; }
        public bool? WillAttend { get; set; }
        public string Email { get; set; }

        public SelectListItem[] SelectItems { get; set; }
    }
}