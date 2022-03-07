﻿using Speckle.ConnectorGSA.Proxy.Results;
using Speckle.GSA.API;
using System.Collections.Generic;
using System.Linq;

namespace Speckle.ConnectorGSA.Results
{
  public class ResultsGlobalProcessor : ResultsProcessorBase<CsvGlobalAnnotated>
  {
    public override ResultGroup Group => ResultGroup.Global;

    private List<ResultType> possibleResultTypes = new List<ResultType>()
    {
      ResultType.TotalLoads,
      ResultType.TotalReactions,
      ResultType.Mode,
      ResultType.Frequency,
      ResultType.LoadFactor,
      ResultType.ModalStiffness,
      ResultType.ModalGeometricStiffness,
      ResultType.ModalMass,
      ResultType.EffectiveMass
    };

    public ResultsGlobalProcessor(string filePath, Dictionary<ResultUnitType, double> unitData, List<ResultType> resultTypes = null,
      List<string> cases = null) : base(filePath, unitData, cases)
    {
      if (resultTypes == null)
      {
        this.resultTypes = new HashSet<ResultType>(possibleResultTypes);
      }
      else
      {
        this.resultTypes = new HashSet<ResultType>(resultTypes.Intersect(possibleResultTypes));
      }
    }

    protected override bool Scale(CsvGlobalAnnotated record)
    {
      var factorsForce = GetFactors(ResultUnitType.Force);
      var factorsLength = GetFactors(ResultUnitType.Length);
      var factorsForceLength = GetFactors(ResultUnitType.Force, ResultUnitType.Length);

      var factorsForcePerLength = new List<double> { };
      factorsForcePerLength.AddRange(factorsForce);
      factorsForcePerLength.AddRange(factorsLength.Select(x => 1.0/x).ToList());

      var factorsMass = GetFactors(ResultUnitType.Mass);

      record.Fx = resultTypes.Contains(ResultType.TotalLoads) ? ApplyFactors(record.Fx, factorsForce) : null;
      record.Fy = resultTypes.Contains(ResultType.TotalLoads) ? ApplyFactors(record.Fy, factorsForce) : null;
      record.Fz = resultTypes.Contains(ResultType.TotalLoads) ? ApplyFactors(record.Fz, factorsForce) : null;
      record.Mxx = resultTypes.Contains(ResultType.TotalLoads) ? ApplyFactors(record.Mxx, factorsForceLength) : null;
      record.Myy = resultTypes.Contains(ResultType.TotalLoads) ? ApplyFactors(record.Myy, factorsForceLength) : null;
      record.Mzz = resultTypes.Contains(ResultType.TotalLoads) ? ApplyFactors(record.Mzz, factorsForceLength) : null;

      record.Fx_Reac = resultTypes.Contains(ResultType.TotalReactions) ? ApplyFactors(record.Fx_Reac, factorsForce) : null;
      record.Fy_Reac = resultTypes.Contains(ResultType.TotalReactions) ? ApplyFactors(record.Fy_Reac, factorsForce) : null;
      record.Fz_Reac = resultTypes.Contains(ResultType.TotalReactions) ? ApplyFactors(record.Fz_Reac, factorsForce) : null;
      record.Mxx_Reac = resultTypes.Contains(ResultType.TotalReactions) ? ApplyFactors(record.Mxx_Reac, factorsForceLength) : null;
      record.Myy_Reac = resultTypes.Contains(ResultType.TotalReactions) ? ApplyFactors(record.Myy_Reac, factorsForceLength) : null;
      record.Mzz_Reac = resultTypes.Contains(ResultType.TotalReactions) ? ApplyFactors(record.Mzz_Reac, factorsForceLength) : null;

      record.Mode = resultTypes.Contains(ResultType.Mode) ? record.Mode : null;

      record.Frequency = resultTypes.Contains(ResultType.Frequency) ? record.Frequency : null;

      record.LoadFactor = resultTypes.Contains(ResultType.LoadFactor) ? record.LoadFactor : null;

      record.ModalStiffness = resultTypes.Contains(ResultType.ModalStiffness) ? ApplyFactors(record.ModalStiffness, factorsForcePerLength) : null; // kN/m

      record.ModalGeometricStiffness = resultTypes.Contains(ResultType.ModalGeometricStiffness) ? ApplyFactors(record.ModalGeometricStiffness, factorsForcePerLength) : null; // kN/m

      record.ModalMass = resultTypes.Contains(ResultType.ModalMass) ? ApplyFactors(record.ModalMass, factorsMass) : null;

      record.EffectiveMassX = resultTypes.Contains(ResultType.EffectiveMass) ? ApplyFactors(record.EffectiveMassX, factorsMass) : null;
      record.EffectiveMassY = resultTypes.Contains(ResultType.EffectiveMass) ? ApplyFactors(record.EffectiveMassY, factorsMass) : null;
      record.EffectiveMassZ = resultTypes.Contains(ResultType.EffectiveMass) ? ApplyFactors(record.EffectiveMassZ, factorsMass) : null;
      record.EffectiveMassXX = resultTypes.Contains(ResultType.EffectiveMass) ? ApplyFactors(record.EffectiveMassXX, factorsMass) : null;
      record.EffectiveMassYY = resultTypes.Contains(ResultType.EffectiveMass) ? ApplyFactors(record.EffectiveMassYY, factorsMass) : null;
      record.EffectiveMassZZ = resultTypes.Contains(ResultType.EffectiveMass) ? ApplyFactors(record.EffectiveMassZZ, factorsMass) : null;

      return true;
    }
  }
}