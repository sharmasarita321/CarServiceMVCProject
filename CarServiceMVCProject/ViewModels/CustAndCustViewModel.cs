using CarServiceMVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarServiceMVCProject.ViewModels
{
    public class CustAndCustViewModel
    {
       
            public ApplicationUser ApplicationUser { get; set; }
            public IEnumerable<ApplicationUser> Customers { get; set; }
            public int? CheckInteger { get; set; }
        
    }
}