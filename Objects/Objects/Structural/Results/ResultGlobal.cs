﻿using Speckle.Newtonsoft.Json;
using Speckle.Core.Kits;
using Speckle.Core.Models;
using System.Collections.Generic;
using Objects.Structural.Analysis;
using Objects.Structural.Loading;

namespace Objects.Structural.Results
{
  public class ResultSetGlobal : Result
  {
    [DetachProperty]
    public List<ResultGlobal> resultsGlobal { get; set; }
    public ResultSetGlobal() { }

    [SchemaInfo("ResultSetGlobal", "Creates a Speckle global result set object", "Structural", "Results")]
    public ResultSetGlobal(List<ResultGlobal> resultsGlobal)
    {
      this.resultsGlobal = resultsGlobal;
    }
  }

  public class ResultGlobal : Result
  {
    [DetachProperty]
    public Model model { get; set; } // this should be a model identifier instead
    public float? loadX { get; set; }
    public float? loadY { get; set; }
    public float? loadZ { get; set; }
    public float? loadXX { get; set; }
    public float? loadYY { get; set; }
    public float? loadZZ { get; set; }
    public float? reactionX { get; set; }
    public float? reactionY { get; set; }
    public float? reactionZ { get; set; }
    public float? reactionXX { get; set; }
    public float? reactionYY { get; set; }
    public float? reactionZZ { get; set; }
    public int? mode { get; set; }
    public float? frequency { get; set; }
    public float? loadFactor { get; set; }
    public float? modalStiffness { get; set; }
    public float? modalGeoStiffness { get; set; }
    public float? modalMass { get; set; }
    public float? effMassX { get; set; }
    public float? effMassY { get; set; }
    public float? effMassZ { get; set; }
    public float? effMassXX { get; set; }
    public float? effMassYY { get; set; }
    public float? effMassZZ { get; set; }
    public ResultGlobal() { }

    [SchemaInfo("ResultGlobal (load case)", "Creates a Speckle global result object (for load case)", "Structural", "Results")]
    public ResultGlobal(LoadCase resultCase, float loadX, float loadY, float loadZ, float loadXX, float loadYY, float loadZZ, float reactionX, float reactionY, float reactionZ, float reactionXX, float reactionYY, float reactionZZ, int? mode, float frequency, float loadFactor, float modalStiffness, float modalGeoStiffness, float modalMass, float effMassX, float effMassY, float effMassZ, float effMassXX, float effMassYY, float effMassZZ)
    {
      this.resultCase = resultCase;
      this.loadX = loadX;
      this.loadY = loadY;
      this.loadZ = loadZ;
      this.loadXX = loadXX;
      this.loadYY = loadYY;
      this.loadZZ = loadZZ;
      this.reactionX = reactionX;
      this.reactionY = reactionY;
      this.reactionZ = reactionZ;
      this.reactionXX = reactionXX;
      this.reactionYY = reactionYY;
      this.reactionZZ = reactionZZ;
      this.mode = mode;
      this.modalMass = modalMass;
      this.frequency = frequency;
      this.loadFactor = loadFactor;
      this.modalStiffness = modalStiffness;
      this.modalGeoStiffness = modalGeoStiffness;
      this.effMassX = effMassX;
      this.effMassY = effMassY;
      this.effMassZ = effMassZ;
      this.effMassXX = effMassXX;
      this.effMassYY = effMassYY;
      this.effMassZZ = effMassZZ;
    }

    [SchemaInfo("ResultGlobal (load combination)", "Creates a Speckle global result object (for load combination)", "Structural", "Results")]
    public ResultGlobal(LoadCombination resultCase, float loadX, float loadY, float loadZ, float loadXX, float loadYY, float loadZZ, float reactionX, float reactionY, float reactionZ, float reactionXX, float reactionYY, float reactionZZ, int? mode, float frequency, float loadFactor, float modalStiffness, float modalGeoStiffness, float modalMass, float effMassX, float effMassY, float effMassZ, float effMassXX, float effMassYY, float effMassZZ)
    {
      this.resultCase = resultCase;
      this.loadX = loadX;
      this.loadY = loadY;
      this.loadZ = loadZ;
      this.loadXX = loadXX;
      this.loadYY = loadYY;
      this.loadZZ = loadZZ;
      this.reactionX = reactionX;
      this.reactionY = reactionY;
      this.reactionZ = reactionZ;
      this.reactionXX = reactionXX;
      this.reactionYY = reactionYY;
      this.reactionZZ = reactionZZ;
      this.mode = mode;
      this.frequency = frequency;
      this.loadFactor = loadFactor;
      this.modalStiffness = modalStiffness;
      this.modalGeoStiffness = modalGeoStiffness;
      this.modalMass = modalMass;
      this.effMassX = effMassX;
      this.effMassY = effMassY;
      this.effMassZ = effMassZ;
      this.effMassXX = effMassXX;
      this.effMassYY = effMassYY;
      this.effMassZZ = effMassZZ;
    }
  }
}
