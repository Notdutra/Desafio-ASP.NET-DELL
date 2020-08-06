using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class ApiScopeProperties
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public int ScopeId { get; set; }

        public virtual ApiScopes Scope { get; set; }
    }
}
