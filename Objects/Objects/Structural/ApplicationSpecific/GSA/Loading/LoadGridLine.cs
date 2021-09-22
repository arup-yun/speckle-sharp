﻿using System.Collections.Generic;
using Objects.Geometry;
using Objects.Structural.Geometry;
using Objects.Structural.Loading;
using Objects.Structural.GSA.Geometry;

namespace Objects.Structural.GSA.Loading
{
    public class LoadGridLine : LoadGrid
    {
        public Objects.Geometry.Polyline polyline { get; set; }
        public bool isProjected { get; set; }
        public List<double> values { get; set; }
        public LoadGridLine() { }

        public LoadGridLine(int nativeId, GridSurface gridSurface, Axis loadAxis, LoadDirection2D direction, Objects.Geometry.Polyline polyline, bool isProjected, List<double> values)
        {
            this.nativeId = nativeId;
            this.name = name;
            this.loadCase = loadCase;
            this.gridSurface = gridSurface;
            this.loadAxis = loadAxis;
            this.direction = direction;
            this.polyline = polyline;
            this.isProjected = isProjected;
            this.values = values;
        }
    }





}
