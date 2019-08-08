using CarServiceMVCProject.Models;
using CarServiceMVCProject.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarServiceMVCProject.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "List of Customers";
            // GET: Customer
            var customers = _context.Users.ToList();
            return View(customers);

        }
        public ActionResult AddCustomerForm()
        {
            return RedirectToAction("Register","Account");
        }

        public ActionResult AddCustomer(ApplicationUser applicationUser)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                _context.Users.Add(applicationUser);
                _context.SaveChanges();
                return RedirectToAction("About", "Home");
            }

        }

        public ActionResult EditCustomerForm(string id)
        {
            var user = _context.Users.Find(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult EditCustomerForm(ApplicationUser applicationUser)
        {
            var customerindb = _context.Users.Find(applicationUser.Id);

            customerindb.FirstName = applicationUser.FirstName;
            customerindb.LastName = applicationUser.LastName;
            customerindb.Email = applicationUser.Email;
            customerindb.PhoneNumber = applicationUser.PhoneNumber;

            customerindb.PhoneNumber = customerindb.PhoneNumber;


            _context.SaveChanges();

            return RedirectToAction("About", applicationUser);

        }



        public ActionResult DeleteCustomer(ApplicationUser applicationUser)
        {
            var cust = _context.Users.Find(applicationUser.Id);
           
            _context.Users.Remove(cust);
            _context.SaveChanges();
            return RedirectToAction("About","Home");
        }
       
       
        public ActionResult ViewCars1(ApplicationUser applicationUser)
        {

            var user = _context.Users.Find(User.Identity.GetUserId());
                var viewmodel = new CustomerCarViewModel
                {
                    ApplicationUser = user,
                    Cars = _context.Cars.ToList()
                };

                return View("ViewCars",viewmodel);
        }

        public ActionResult ViewCars(ApplicationUser applicationUser)
        {
            var user = _context.Users.Find(applicationUser.Id);
            var viewmodel = new CustomerCarViewModel
            {
                ApplicationUser = user,
                Cars = _context.Cars.ToList()
            };

            return View(viewmodel);
        }

        public ActionResult AddNewCarForm(ApplicationUser applicationUser)
        {
            SingleCustomerCarViewModel viewmodel = new SingleCustomerCarViewModel
            {
                GetCustomer = applicationUser
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Addnewcar(SingleCustomerCarViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                return View("AddNewCarForm",viewmodel);
            }
            else
            {
                viewmodel.GetCar.ApplicationUserId = viewmodel.GetCustomer.Id;
                var customer = _context.Users.Find(viewmodel.GetCustomer.Id);
                var car = viewmodel.GetCar;
                _context.Cars.Add(car);
                _context.SaveChanges();
                return RedirectToAction("viewcars", "home", customer);

            }

        }

       

        public ActionResult DeleteCar(Car car)
        {
            var customer = _context.Users.Find(car.ApplicationUserId);
            var cars = _context.Cars.Find(car.Id);
            _context.Cars.Remove(cars);
            _context.SaveChanges();
            return RedirectToAction("viewcars", "home", customer);

        }
               

        public ActionResult EditCarForm(int ? id)
        {
            var car=_context.Cars.Find(id);
            return View(car);
        }

        [HttpPost]
        public ActionResult EditCar(Car car)
        {
            var carindb = _context.Cars.Find(car.Id);

            var customer = _context.Users.Find(car.ApplicationUserId);
            carindb.VIN = car.VIN;
            carindb.Model = car.Model;
            carindb.Style = car.Style;
            carindb.Company = car.Company;
            carindb.Color = car.Color;

            _context.SaveChanges();
            return RedirectToAction("ViewCars", "home", customer);
        }


        public ActionResult ViewServices(Car car)
        {
            var viewmodel = new ServiceViewModel
            {
                Car= car,
                Services = _context.Services.ToList(),
                ServiceType = _context.ServiceTypes.ToList()
            };
            return View(viewmodel);
        }

        public ActionResult AddService(ServiceViewModel serviceViewModel)
        {
            serviceViewModel.Service.CarId = serviceViewModel.Car.Id;
             serviceViewModel.Service.DateAdded =DateTime.Today;
            var car = _context.Cars.Find(serviceViewModel.Car.Id);
            _context.Services.Add(serviceViewModel.Service);
            _context.SaveChanges();
            return RedirectToAction("viewservices","Home", car);

        }

        public ActionResult DeleteService(Service service)
        {
            var car = _context.Cars.Find(service.CarId);
            var myservice = _context.Services.Find(service.Id);

            _context.Services.Remove(myservice);
            _context.SaveChanges();

            return RedirectToAction("viewservices", car);
        }
        public ActionResult Search(string search = "", string option = "")
        {
            if (search.Equals(""))
            {
                var customers = _context.Users.ToList();
                return View("About", customers);
            }
            else
            {
                if (option.Equals("Email"))
                {
                    var customers = _context.Users.Where(c => c.Email.Equals(search)).ToList();
                    var viewModel = new CustAndCustViewModel
                    {
                        Customers = customers
                    };
                    return View("About", viewModel.Customers);
                }

                else if (option.Equals("PhoneNumber"))
                {
                    //var searchMobile = Convert.ToInt64(search);
                    var customers = _context.Users.Where(c => c.PhoneNumber.Equals(search)).ToList();
                    var viewModel = new CustAndCustViewModel
                    {
                        Customers = customers
                    };
                    return View("About", viewModel.Customers);
                }

                else
                {
                    var customers = _context.Users.Where(c => c.FirstName.Equals(search)).ToList();
                    var viewModel = new CustAndCustViewModel
                    {
                        Customers = customers
                    };
                    return View("About", viewModel.Customers);
                }
            }
        }
    }


}
