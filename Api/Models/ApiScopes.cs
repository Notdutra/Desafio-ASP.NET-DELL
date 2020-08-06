using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class ApiScopes
    {
        public ApiScopes()
        {
            ApiScopeClaims = new HashSet<ApiScopeClaims>();
            ApiScopeProperties = new HashSet<ApiScopeProperties>();
        }

        public int Id { get; set; }
        public bool Enabled { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool Required { get; set; }
        public bool Emphasize { get; set; }
        public bool ShowInDiscoveryDocument { get; set; }

        public virtual ICollection<ApiScopeClaims> ApiScopeClaims { get; set; }
        public virtual ICollection<ApiScopeProperties> ApiScopeProperties { get; set; }
    }
}
