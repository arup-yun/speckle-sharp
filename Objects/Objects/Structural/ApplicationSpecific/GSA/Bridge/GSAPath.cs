﻿using Speckle.Core.Models;
using Speckle.Core.Kits;

namespace Objects.Structural.GSA.Bridge
{
  public class GSAPath : Base
  {
    public int? nativeId { get; set; }
    public string name { get; set; }
    public PathType type { get; set; }
    public int group { get; set; }

    [DetachProperty]
    public GSAAlignment alignment { get; set; }
    public double left { get; set; } //left / centre offset
    public double right { get; set; } //right offset / gauge
    public double factor { get; set; } //left factor
    public int numMarkedLanes { get; set; }
    public GSAPath() { }

    [SchemaInfo("GSAPath", "Creates a Speckle structural path for GSA (a path defines traffic lines along a bridge relative to an alignments, for influence analysis)", "GSA", "Bridge")]
    public GSAPath(PathType type, int group, GSAAlignment alignment, double left, double right, double factor, int numMarkedLanes, string name = null, int? nativeId = null)
    {
      this.nativeId = nativeId;
      this.name = name;
      this.type = type;
      this.group = group;
      this.alignment = alignment;
      this.left = left;
      this.right = right;
      this.factor = factor;
      this.numMarkedLanes = numMarkedLanes;
    }
  }
  public enum PathType
  {
    NotSet = 0,
    LANE,
    FOOTWAY,
    TRACK,
    VEHICLE,
    CWAY_1WAY,
    CWAY_2WAY
  }

}
