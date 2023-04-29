using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ThreeLayerArchitecture.DAL;

namespace ThreeLayerArchitecture.Models
{
    public class UserUpdateViewModel
    {



        public UserUpdateViewModel()
        {
        }

        public UserUpdateViewModel(User user)
        {
            this.Id = user.Id;
           
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.GenderId = user.GenderId;
            this.Category = user.Category;
            this.MobileNumber = user.MobileNumber;
            this.AdharNumber = user.AdharNumber;

        }

        public int Id { get; set; }       

        [Required]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        public int? GenderId { get; set; }
        [Required]
        [RegularExpression(@"^(\+\d{1,2}\s?)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", ErrorMessage = "Mobile number is not valid")]
        [Display(Name = "Mobile")]
        public string? MobileNumber { get; set; }  
        public string? AdharNumber { get; set; }
        public string? Category { get; set; }      
    }
}
