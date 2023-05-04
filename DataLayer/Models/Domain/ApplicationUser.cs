using Microsoft.AspNetCore.Identity;

namespace DataLayer.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public List<Drink> CreatedDrinks { get; set; }
    }
}