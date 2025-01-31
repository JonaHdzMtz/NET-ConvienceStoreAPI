using System;
using System.Collections.Generic;

namespace ConvinenceStore.Models;

public partial class User
{
    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public long IdUser { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
