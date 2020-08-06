using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class IdentityResources
    {
        public IdentityResources()
        {
            IdentityResourceClaims = new HashSet<IdentityResourceClaims>();
            IdentityResourceProperties = new HashSet<IdentityResourceProperties>();
        }

        public int Id { get; set; }
        public bool Enabled { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool Required { get; set; }
        public bool Emphasize { get; set; }
        public bool ShowInDiscoveryDocument { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool NonEditable { get; set; }

        public virtual ICollection<IdentityResourceClaims> IdentityResourceClaims { get; set; }
        public virtual ICollection<IdentityResourceProperties> IdentityResourceProperties { get; set; }
    }
}
