using System;
using System.Collections.Generic;

namespace job_opportunities_asp_react.Models.Entities;

public partial class Application
{
    public int Id { get; set; }

    public int? ApplicantId { get; set; }

    public int? JobOfferId { get; set; }

    public DateTime? ApplicationDate { get; set; }

    public string? Status { get; set; }

    public virtual Applicant? Applicant { get; set; }

    public virtual JobOffer? JobOffer { get; set; }
}
