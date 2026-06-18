using System;
using System.Collections.Generic;
using System.Text;

namespace HelpdeskReports.Models;

internal class Worker
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
