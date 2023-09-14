using System;
using System.Collections.Generic;

namespace job_opportunities_asp_react.Models.Entities;

public partial class Applicant
{
    public int Id { get; set; }

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? SecondEmailAddress { get; set; }

    public bool? RestartAccount { get; set; }

    public bool? ConfirmAccount { get; set; }

    public string? Token { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? AditionalName { get; set; }

    public string Address1 { get; set; } = null!;

    public string? Address2 { get; set; }

    public string? Pobox { get; set; }

    public string? PostalCode { get; set; }

    public int? CountryId { get; set; }

    public int? CitizenshipId { get; set; }

    public string? City { get; set; }

    public int? GenderId { get; set; }

    public int? MaritalStatusId { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Ssn { get; set; }

    public string? PrivatePhone { get; set; }

    public string? MobilePhone { get; set; }

    public string? WorkPhone { get; set; }

    public int? EducationLevel { get; set; }

    public int? Subject { get; set; }

    public int? Degree { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual Country? Citizenship { get; set; }

    public virtual Country? Country { get; set; }

    public virtual EducationDegree? DegreeNavigation { get; set; }

    public virtual EducationLevel? EducationLevelNavigation { get; set; }

    public virtual Gender? Gender { get; set; }

    public virtual MaritalStatus? MaritalStatus { get; set; }

    public virtual EducationSubject? SubjectNavigation { get; set; }
}
