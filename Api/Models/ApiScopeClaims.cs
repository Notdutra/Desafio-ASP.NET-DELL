using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class ApiScopeClaims
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int ScopeId { get; set; }

        public virtual ApiScopes Scope { get; set; }
    }
}
