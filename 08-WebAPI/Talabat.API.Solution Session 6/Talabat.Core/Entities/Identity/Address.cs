using System.Text.Json.Serialization;

namespace Talabat.Core.Entities.Identity
{
    public class Address : BaseEntity
    {
        public string FirstName { get; set; }  // first name of the person that will Take the Order from the Delivery, will have default value
        public string LastName { get; set; }   // last name of the person that will Take the Order from the Delivery, will have default value
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        // [JsonIgnore]
        public string ApplicationUserId { get; set; } // Foreign Key

        // [JsonIgnore]
        public ApplicationUser User { get; set; }     // navigational property [ONE]
    }
}