namespace job_opportunities_asp_react;

public class Create
{
  public int Id { get; set; }

  public int? ApplicantId { get; set; }

  public int? JobOfferId { get; set; }

  public DateTime? ApplicationDate { get; set; }

  public string? Status { get; set; }
}
