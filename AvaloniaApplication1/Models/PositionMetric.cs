using System;
using System.Collections.Generic;

namespace AvaloniaApplication1.Models;

public partial class PositionMetric
{
    public int Id { get; set; }

    public int PositionId { get; set; }

    public int MetricId { get; set; }

    public virtual Metric Metric { get; set; } = null!;

    public virtual Position Position { get; set; } = null!;
}
