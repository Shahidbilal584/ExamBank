using System;
using System.Collections.Generic;

namespace ExamBank.Models;

public partial class Department
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? CoverImageUrl { get; set; }

    public long NumberOfSubject { get; set; }

    public long? InstitueId { get; set; }

    public virtual ICollection<BrandAmbassder> BrandAmbassders { get; set; } = new List<BrandAmbassder>();

    public virtual Institute? Institue { get; set; }

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
