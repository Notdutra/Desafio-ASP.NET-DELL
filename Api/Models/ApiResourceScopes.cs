using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class ApiResourceScopes
    {
        public int Id { get; set; }
        public string Scope { get; set; }
        public int ApiResourceId { get; set; }

        public virtual ApiResources ApiResource { get; set; }
    }
}
