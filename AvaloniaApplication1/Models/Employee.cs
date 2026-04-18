using System;
using System.Collections.Generic;
using System.Linq;

namespace AvaloniaApplication1.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public int PositionId { get; set; }

    public int RoleId { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<EmployeeMetric> EmployeeMetrics { get; set; } = new List<EmployeeMetric>();

    public virtual Position Position { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
    
    public decimal Weight => EmployeeMetrics?.Select(x => (decimal)x.Metric.Weight).Sum() ?? 0;
}
