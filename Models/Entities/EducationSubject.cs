using System;
using System.Collections.Generic;

namespace job_opportunities_asp_react.Models.Entities;

public partial class EducationSubject
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Applicant> Applicants { get; set; } = new List<Applicant>();
}
