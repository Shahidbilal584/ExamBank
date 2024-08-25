using System;
using System.Collections.Generic;

namespace ExamBank.Models;

public partial class Paper
{
    public long Id { get; set; }

    public long? SubjectId { get; set; }

    public long? CategoryId { get; set; }

    public long? SeasionId { get; set; }

    public long? AmbassadorId { get; set; }

    public long? YearId { get; set; }

    public long? UserId { get; set; }

    public string? PaperUrl { get; set; }

    public virtual BrandAmbassder? Ambassador { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Session? Seasion { get; set; }

    public virtual Subject? Subject { get; set; }

    public virtual Year? Year { get; set; }
}
