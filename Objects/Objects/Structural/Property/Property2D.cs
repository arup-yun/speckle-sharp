﻿using Speckle.Newtonsoft.Json;
using Speckle.Core.Kits;
using Speckle.Core.Models;
using System.Collections.Generic;
using Objects.Structural.Geometry;
using Objects.Structural.Materials;

namespace Objects.Structural.Properties
{
  public class Property2D : Property
  {
    public PropertyType2D type { get; set; }
    public double thickness { get; set; } //also thickness type? ex. waffle vs constant
    
    [DetachProperty]
    public Material material { get; set; }
    public Axis orientationAxis { get; set; }
    public ReferenceSurface refSurface { get; set; } = ReferenceSurface.Middle; //system plane
    public double zOffset { get; set; } //relative to reference surface
    public string units { get; set; }
    public Property2D() { }

    [SchemaInfo("Property2D (by name)", "Creates a Speckle structural 2D element property", "Structural", "Properties")]
    public Property2D(string name)
    {
      this.name = name;
    }

    [SchemaInfo("Property2D", "Creates a Speckle structural 2D element property", "Structural", "Properties")]
    public Property2D(string name, Material material, PropertyType2D type, double thickness, ReferenceSurface referenceSurface = ReferenceSurface.Middle)
    {
      this.name = name;
      this.material = material;
      this.type = type;
      this.thickness = thickness;
      this.refSurface = referenceSurface;
    }
  }
}
