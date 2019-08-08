using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarServiceMVCProject.Models
{
    public class Car
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter VIN")]
        public int VIN { get; set; }

        [Required(ErrorMessage = "Please Enter Company")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Please Enter Model")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Please Enter Style")]
        public string Style { get; set; }

        [Required( ErrorMessage = "Please Enter Color")]
        public string Color { get; set; }
           
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }

    }
}
