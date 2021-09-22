﻿namespace Speckle.GSA.API.GwaSchema
{
  public class GsaLoadCase : GsaRecord
  {
    public StructuralLoadCaseType CaseType;
    public string Title;

    public GsaLoadCase() : base()
    {
      //Defaults
      Version = 2;
    }

  }
}