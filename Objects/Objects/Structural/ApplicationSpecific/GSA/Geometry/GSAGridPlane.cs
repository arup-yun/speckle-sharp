﻿using Speckle.Newtonsoft.Json;
using Speckle.Core.Kits;
using Speckle.Core.Models;
using Objects.Geometry;
using Objects.Structural.Properties;
using Objects.Structural.Geometry;

namespace Objects.Structural.GSA.Geometry
{
  public class GSAGridPlane : Storey
  {
    public int? nativeId { get; set; }
    public Axis axis { get; set; }
    public double? toleranceBelow { get; set; }
    public double? toleranceAbove { get; set; }
    public GSAGridPlane() { }

    [SchemaInfo("GSAGridPlane", "Creates a Speckle structural grid plane for GSA", "GSA", "Geometry")]
    public GSAGridPlane(Axis axis, double elevation = 0, string name = null, int? nativeId = null)
    {
      this.nativeId = nativeId;
      this.name = name;
      this.axis = axis;
      this.elevation = elevation; // the height of the grid plane above the origin (of the specified axis)
    }
  }
}
