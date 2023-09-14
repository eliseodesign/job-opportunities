using System;
using System.Collections.Generic;

namespace job_opportunities_asp_react.Models.Entities;

public partial class FieldSector
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<JobOffer> JobOffers { get; set; } = new List<JobOffer>();
}
