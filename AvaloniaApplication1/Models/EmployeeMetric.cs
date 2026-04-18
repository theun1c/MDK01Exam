using System;
using System.Collections.Generic;

namespace AvaloniaApplication1.Models;

public partial class EmployeeMetric
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public int MetricId { get; set; }

    public DateOnly AchievedAt { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Metric Metric { get; set; } = null!;
}
