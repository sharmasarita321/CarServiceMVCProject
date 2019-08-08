using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarServiceMVCProject.Models
{
    public class ServiceType
    {
         public int Id { get; set; }

        [Required (ErrorMessage = "Please enter Service Name")]
        public string ServiceName { get; set; }
        
    }
}