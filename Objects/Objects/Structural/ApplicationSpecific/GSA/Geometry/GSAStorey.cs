﻿using Objects.Structural.Geometry;
using Speckle.Core.Models;
using Speckle.Core.Kits;

namespace Objects.Structural.GSA.Geometry
{
  public class GSAStorey : Storey
  {
    public int? nativeId { get; set; }
    public Axis axis { get; set; }
    public double toleranceBelow { get; set; }
    public double toleranceAbove { get; set; }
    public GSAStorey() { }

    [SchemaInfo("GSAStorey", "Creates a Speckle structural storey (to describe floor levels/storeys in the structural model) for GSA", "GSA", "Geometry")]
    public GSAStorey(Axis axis, double elevation, double toleranceBelow, double toleranceAbove, string name = null, int? nativeId = null)
    {
      this.nativeId = nativeId;
      this.name = name;
      this.axis = axis;
      this.elevation = elevation;
      this.toleranceBelow = toleranceBelow;
      this.toleranceAbove = toleranceAbove;
    }
  }



}
