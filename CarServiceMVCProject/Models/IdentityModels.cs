using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CarServiceMVCProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter First Name")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name should be of minimum 3 characters maximum 20 characters")]
        [RegularExpression(@"^([A-Za-z]+)", ErrorMessage = "Enter valid first name")]
        public string FirstName { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter lastname")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "lastname should be of minimum 3 characters maximum 20 characters")]
        [RegularExpression(@"^([A-Za-z]+)", ErrorMessage = "Enter valid last name")]
        public string LastName { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Please enter name")]
        ////[RegularExpression(@"^\+[0-9]{2}\s+[0-9]{2}[0-9]{8}$", ErrorMessage = "Please Enter the phone-number")]

        //public override string PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please Provide Valid Email")]

        public override string Email { get => base.Email; set => base.Email = value; }



        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet <ServiceType> ServiceTypes { get; set; }
        public DbSet<Service> Services { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}