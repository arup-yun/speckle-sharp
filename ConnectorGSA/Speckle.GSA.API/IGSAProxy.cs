﻿using Speckle.GSA.API.CsvSchema;
using Speckle.GSA.API.GwaSchema;
using System;
using System.Collections.Generic;

namespace Speckle.GSA.API
{
  public interface IGSAProxy
  {
    bool NewFile(bool showWindow = true, object gsaInstance = null);
    bool OpenFile(string path, bool showWindow = true, object gsaInstance = null);
    bool GetGwaData(bool nodeApplicationIdFilter, out List<GsaRecord> records, IProgress<int> incrementProgress = null);

    string GenerateApplicationId(Type schemaType, int gsaIndex);

    List<List<Type>> TxTypeDependencyGenerations { get; }


    //Offered by GSA itself
    List<int> ConvertGSAList(string list, GSAEntity entityType);
    int NodeAt(double x, double y, double z, double coincidenceTol);

    char GwaDelimiter { get; }

    //METHODS
    void CalibrateNodeAt();
    bool PrepareResults(IEnumerable<ResultType> resultTypes, int numBeamPoints = 3);
    bool LoadResults(ResultGroup group, out int numErrorRows, List<string> cases = null, List<int> elemIds = null);
    //bool GetResultHierarchy(ResultGroup group, int index, out Dictionary<string, Dictionary<string, object>> valueHierarchy, int dimension = 1);
    bool GetResultRecords(ResultGroup group, int index, out List<CsvRecord> records);
    bool GetResultRecords(ResultGroup group, int index, string loadCase, out List<CsvRecord> records);
    bool ClearResults(ResultGroup group);
    bool SaveAs(string filePath);
    bool Clear();

    void Close();
  }
}