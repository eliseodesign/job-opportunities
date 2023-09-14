using System;
using System.Collections.Generic;

namespace job_opportunities_asp_react.Models.Entities;

public partial class JobOffer
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public decimal? Salary { get; set; }

    public string? Location { get; set; }

    public int? EmployerId { get; set; }

    public string? Status { get; set; }

    public DateTime? AvailabilityDate { get; set; }

    public int? WorkExperienceYears { get; set; }

    public string? CurrentPosition { get; set; }

    public string? CurrentEmployer { get; set; }

    public int? FieldSectorId { get; set; }

    public string? RelevantWorkExperience { get; set; }

    public string? AvailableReferences { get; set; }

    public string? HowDidYouHear { get; set; }

    public bool? Internal { get; set; }

    public string? CoverLetter { get; set; }

    public byte[]? Cv { get; set; }

    public string? ExternalLinks { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual Employer? Employer { get; set; }

    public virtual FieldSector? FieldSector { get; set; }
}
