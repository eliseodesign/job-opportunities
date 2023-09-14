using System;
using System.Collections.Generic;

namespace job_opportunities_asp_react.Models.Entities;

public partial class Country
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Applicant> ApplicantCitizenships { get; set; } = new List<Applicant>();

    public virtual ICollection<Applicant> ApplicantCountries { get; set; } = new List<Applicant>();
}
