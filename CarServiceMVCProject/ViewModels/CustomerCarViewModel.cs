using CarServiceMVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarServiceMVCProject.ViewModels
{
    public class CustomerCarViewModel
    {
        
       
            public ApplicationUser ApplicationUser { get; set; }
            public IEnumerable<Car> Cars { get; set; }
        
    }
}