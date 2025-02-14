﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Objects.BuiltElements.Archicad;
using Speckle.Core.Kits;

namespace Archicad.Communication.Commands
{
  sealed internal class GetWallData : ICommand<IEnumerable<Wall>>
  {

    [JsonObject(MemberSerialization.OptIn)]
    public sealed class Parameters
    {

      [JsonProperty("applicationIds")]
      private IEnumerable<string> ApplicationIds { get; }

      public Parameters(IEnumerable<string> applicationIds)
      {
        ApplicationIds = applicationIds;
      }

    }

    [JsonObject(MemberSerialization.OptIn)]
    private sealed class Result
    {

      [JsonProperty("walls")]
      public IEnumerable<Wall> Datas { get; private set; }

    }

    private IEnumerable<string> ApplicationIds { get; }

    public GetWallData(IEnumerable<string> applicationIds)
    {
      ApplicationIds = applicationIds;
    }

    public async Task<IEnumerable<Wall>> Execute()
    {
      Result result = await HttpCommandExecutor.Execute<Parameters, Result>("GetWallData", new Parameters(ApplicationIds));
      foreach (var wall in result.Datas)
        wall.units = Units.Meters;

      return result.Datas;
    }

  }
}
