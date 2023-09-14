using System;
using System.Collections.Generic;

namespace job_opportunities_asp_react.Models.Entities;

public partial class Employer
{
    public int Id { get; set; }

    public string? CompanyName { get; set; }

    public string? ContactPerson { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Website { get; set; }

    public virtual ICollection<JobOffer> JobOffers { get; set; } = new List<JobOffer>();
}
