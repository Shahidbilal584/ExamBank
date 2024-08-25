using System;
using System.Collections.Generic;

namespace ExamBank.Models;

public partial class Year
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Paper> Papers { get; set; } = new List<Paper>();
}
