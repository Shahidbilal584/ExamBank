using System;
using System.Collections.Generic;

namespace ExamBank.Models;

public partial class Subject
{
    public long Id { get; set; }

    public long? DepartmentId { get; set; }

    public long? InstituteId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public long? NumberOfPaper { get; set; }

    public virtual Department? Department { get; set; }

    public virtual Institute? Institute { get; set; }

    public virtual ICollection<Paper> Papers { get; set; } = new List<Paper>();
}
