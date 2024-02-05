using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkShop.Domain.Entities
{
    public class CarWorkShop
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string? About { get; set; }

        public string? CreatedById { get; set; }
        public Microsoft.AspNetCore.Identity.IdentityUser? CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public CarWorkShopContactDetails ContactDetails { get; set; } = default!;

        public List<CarWorkShopService> Services { get; set; } = new();

        public string? EncodedName { get; private set; }

        public void EncodeName() => EncodedName = Name?.ToLower().Replace(" ","-");
    }
}
