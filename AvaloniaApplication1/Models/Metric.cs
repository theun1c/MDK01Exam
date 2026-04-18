using System;
using System.Collections.Generic;

namespace AvaloniaApplication1.Models;

public partial class Metric
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Weight { get; set; }

    public bool IsCommon { get; set; }

    public virtual ICollection<EmployeeMetric> EmployeeMetrics { get; set; } = new List<EmployeeMetric>();

    public virtual ICollection<PositionMetric> PositionMetrics { get; set; } = new List<PositionMetric>();
}
