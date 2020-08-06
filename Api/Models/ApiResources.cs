using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class ApiResources
    {
        public ApiResources()
        {
            ApiResourceClaims = new HashSet<ApiResourceClaims>();
            ApiResourceProperties = new HashSet<ApiResourceProperties>();
            ApiResourceScopes = new HashSet<ApiResourceScopes>();
            ApiResourceSecrets = new HashSet<ApiResourceSecrets>();
        }

        public int Id { get; set; }
        public bool Enabled { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string AllowedAccessTokenSigningAlgorithms { get; set; }
        public bool ShowInDiscoveryDocument { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? LastAccessed { get; set; }
        public bool NonEditable { get; set; }

        public virtual ICollection<ApiResourceClaims> ApiResourceClaims { get; set; }
        public virtual ICollection<ApiResourceProperties> ApiResourceProperties { get; set; }
        public virtual ICollection<ApiResourceScopes> ApiResourceScopes { get; set; }
        public virtual ICollection<ApiResourceSecrets> ApiResourceSecrets { get; set; }
    }
}
