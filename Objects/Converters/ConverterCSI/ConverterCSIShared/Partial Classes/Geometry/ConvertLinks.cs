﻿using System;
using System.Collections.Generic;
using Objects.Geometry;
using Objects.Structural.Geometry;
using Objects.Structural.Analysis;
using Speckle.Core.Models;
using Objects.Structural.CSI.Geometry;
using Objects.Structural.CSI.Properties;
using System.Linq;
using CSiAPIv1;

namespace Objects.Converter.CSI
{
  public partial class ConverterCSI
  {
    public void LinkToNative(CSIElement1D link)
    {

      PointToNative((CSINode)link.end1Node);
      PointToNative((CSINode)link.end2Node);
      string linkName = null;
      int numberProps = 0;
      string[] listProp = null;
      Model.PropLink.GetNameList(ref numberProps, ref listProp);
      if (listProp.Contains(link.property.name))
      {
        Model.LinkObj.AddByPoint(link.end1Node.name, link.end2Node.name, ref linkName, PropName: link.property.name);
      }
      else
      {
        LinkPropertyToNative((CSILinkProperty)link.property);
        Model.LinkObj.AddByPoint(link.end1Node.name, link.end2Node.name, ref linkName, PropName: link.property.name);
      }

      return;

    }
    public CSIElement1D LinkToSpeckle(string name)
    {
      string units = ModelUnits();

      var speckleStructLink = new CSIElement1D();
      speckleStructLink.type = ElementType1D.Link;
      speckleStructLink.memberType = MemberType.Generic1D;
      speckleStructLink.name = name;
      string pointI, pointJ;
      pointI = pointJ = null;
      _ = Model.LinkObj.GetPoints(name, ref pointI, ref pointJ);
      var pointINode = PointToSpeckle(pointI);
      var pointJNode = PointToSpeckle(pointJ);
      speckleStructLink.end1Node = pointINode;
      speckleStructLink.end2Node = pointJNode;
      var speckleLine = new Line();
      if (units != null)
      {
        speckleLine = new Line(pointINode.basePoint, pointJNode.basePoint, units);
      }
      else
      {
        speckleLine = new Line(pointINode.basePoint, pointJNode.basePoint);
      }
      speckleStructLink.baseLine = speckleLine;

      double localAxis = 0;
      bool advanced = false;
      Model.LinkObj.GetLocalAxes(name, ref localAxis, ref advanced);
      speckleStructLink.orientationAngle = localAxis;
      string linkProp = null;
      Model.LinkObj.GetProperty(name, ref linkProp);
      speckleStructLink.property = LinkPropertyToSpeckle(linkProp);

      var GUID = "";
      Model.LinkObj.GetGUID(name, ref GUID);
      speckleStructLink.applicationId = GUID;
      List<Base> elements = SpeckleModel.elements;
      List<string> application_Id = elements.Select(o => o.applicationId).ToList();
      if (!application_Id.Contains(speckleStructLink.applicationId))
      {
        SpeckleModel.elements.Add(speckleStructLink);
      }


      return speckleStructLink;
    }
  }
}