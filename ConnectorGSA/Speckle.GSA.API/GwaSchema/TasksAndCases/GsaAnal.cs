﻿namespace Speckle.GSA.API.GwaSchema
{
  public class GsaAnal : GsaRecord
  {
    public string Name { get => name; set { name = value; } }
    public int? LoadCase;
    public string Desc;

    public GsaAnal()
    {
      Version = 1;
    }
  }
}
