namespace HelpdeskWebAPI.Models;

public class Report
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime ReportDate { get; set; } = DateTime.Now;
    public int PriorityId { get; set; }
    public int StateId { get; set; }
    public int CategoryId { get; set; }
    public int WorkerId_ReportedBy { get; set; }
    public int? WorkerId_ModeratedBy { get; set; }
}
