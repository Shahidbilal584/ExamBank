using System;
using System.Collections.Generic;

namespace ExamBank.Models;

public partial class User
{
    public long Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string RefreshToken { get; set; } = null!;

    public virtual ICollection<BrandAmbassder> BrandAmbassders { get; set; } = new List<BrandAmbassder>();
}
