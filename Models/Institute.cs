using System;
using System.Collections.Generic;

namespace ExamBank.Models;

public partial class Institute
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? CoverImageUrl { get; set; }

    public virtual ICollection<BrandAmbassder> BrandAmbassders { get; set; } = new List<BrandAmbassder>();

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
