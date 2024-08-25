using System;
using System.Collections.Generic;

namespace ExamBank.Models;

public partial class BrandAmbassder
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public long InstituteId { get; set; }

    public long DepartmenId { get; set; }

    public long PastPaperCount { get; set; }

    public string ProfilePicUrl { get; set; } = null!;

    public bool? IsApplyForAmbassder { get; set; }

    public virtual Department Departmen { get; set; } = null!;

    public virtual Institute Institute { get; set; } = null!;

    public virtual ICollection<Paper> Papers { get; set; } = new List<Paper>();

    public virtual User User { get; set; } = null!;
}
