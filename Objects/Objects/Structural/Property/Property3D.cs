﻿using Speckle.Newtonsoft.Json;
using Speckle.Core.Kits;
using Speckle.Core.Models;
using System.Collections.Generic;
using Objects.Structural.Geometry;
using Objects.Structural.Materials;

namespace Objects.Structural.Properties
{
    public class Property3D : Property
    {
        public PropertyType3D type { get; set; }
        public Material material { get; set; }
        public Axis orientationAxis { get; set; }

        public Property3D() { }

        [SchemaInfo("Property3D (by name)", "Creates a Speckle structural 3D element property", "Structural", "Properties")]
        public Property3D(string name)
        {
            this.name = name;
        }

        [SchemaInfo("Property3D", "Creates a Speckle structural 3D element property", "Structural", "Properties")]
        public Property3D(string name, PropertyType3D type , Material material)
        {
            this.name = name;
            this.type = type;
            this.material = material;
        }
    }
}
