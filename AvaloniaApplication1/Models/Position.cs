using System;
using System.Collections.Generic;

namespace AvaloniaApplication1.Models;

public partial class Position
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<PositionMetric> PositionMetrics { get; set; } = new List<PositionMetric>();
}
