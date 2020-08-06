using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class IdentityResourceClaims
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int IdentityResourceId { get; set; }

        public virtual IdentityResources IdentityResource { get; set; }
    }
}
