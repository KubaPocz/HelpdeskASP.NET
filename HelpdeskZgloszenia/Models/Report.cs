namespace HelpdeskReports.Models;

internal class Report
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ReportedBy { get; set; } = string.Empty;
    public string ModeratedBy { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public DateTime ReportDate { get; set; }
}
