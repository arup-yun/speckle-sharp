﻿using Speckle.Newtonsoft.Json;
using Speckle.Core.Kits;
using Speckle.Core.Models;
using System.Collections.Generic;
using Objects.Geometry;
using Objects.Structural.Results;

namespace Objects.Structural.Geometry
{
    public class Node : Base
    {
        //public int nativeId { get; set; } //equivalent to num record in GWA keyword, can be used as a unique identifier for other software
        public string name { get; set; }
        public Point basePoint { get; set; }
        public Plane constraintAxis { get; set; } // can be detachable? ex. a user-specified axis
        public Restraint restraint { get; set; } // can be detachable? ex. reuse pinned support condition
        public Node() { }

        [SchemaInfo("Node", "Creates a Speckle structural node", "Structural", "Geometry")]
        public Node([SchemaMainParam] Point basePoint, 
            string name = null,
            [SchemaParamInfo("If null, restraint condition defaults to free/fully released")]  Restraint restraint = null, 
            [SchemaParamInfo("If null, axis defaults to world xy (z axis defines the vertical direction, positive direction is up)")] Plane constraintAxis = null)
        {
            this.basePoint = basePoint;
            this.name = name;
            this.restraint = restraint == null ? new Restraint("RRRRRR") : restraint;
            this.constraintAxis = constraintAxis == null ? new Plane(new Point(0, 0, 0), new Vector(0, 0, 1), new Vector(1, 0, 0), new Vector(0, 1, 0)) : constraintAxis;
        }
    }
}