﻿using CarServiceMVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarServiceMVCProject.ViewModels
{
    public class SingleCustomerCarViewModel
    {
        
            public Car GetCar { get; set; }
            public ApplicationUser GetCustomer { get; set; }
        
    }
}