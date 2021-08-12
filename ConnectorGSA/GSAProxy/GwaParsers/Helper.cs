﻿using Speckle.GSA.API;
using Speckle.GSA.API.GwaSchema;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Speckle.ConnectorGSA.Proxy.GwaParsers
{
  public static class Helper
  {
    public static string FormatApplicationId(string keyword, IEnumerable<int> indices, int parentIndex = 0)
    {
      return ("gsa/" + keyword + "-" + string.Join("-", indices) + ((parentIndex > 0) ? "_" + parentIndex : ""));
    }

    public static string FormatApplicationId(GwaKeyword keyword, int index)
    {
      return ("gsa/" + keyword.GetStringValue() + "-" + index);
    }

    public static GwaKeyword GetKeyword<U>()
    {
      return (GwaKeyword)typeof(U).GetAttribute<GsaType>("Keyword");
    }

    public static GwaKeyword GetGwaKeyword(Type t)
    {
      return (GwaKeyword)t.GetAttribute<GsaType>("Keyword");
    }

    public static bool IsAnalysisLayer(Type t)
    {
      return (bool)t.GetAttribute<GsaType>("AnalysisLayer");
    }

    public static bool IsDesignLayer(Type t)
    {
      return (bool)t.GetAttribute<GsaType>("DesignLayer");
    }

    public static GwaKeyword[] GetReferencedKeywords(Type t)
    {
      return (GwaKeyword[])t.GetAttribute<GsaType>("ReferencedKeywords");
    }

    public static GwaSetCommandType GetGwaSetCommandType<T>()
    {
      return (GwaSetCommandType)typeof(T).GetAttribute<GsaType>("SetCommandType");
    }

    public static bool IsSelfContained(Type t)
    {
      return (bool)t.GetAttribute<GsaType>("SelfContained");
    }

    //https://stackoverflow.com/questions/457676/check-if-a-class-is-derived-from-a-generic-class
    public static bool IsSubclassOfRawGeneric(Type generic, Type toCheck)
    {
      while (toCheck != null && toCheck != typeof(object))
      {
        var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
        if (generic == cur)
        {
          return true;
        }
        toCheck = toCheck.BaseType;
      }
      return false;
    }

    //https://stackoverflow.com/questions/457676/check-if-a-class-is-derived-from-a-generic-class
    public static bool InheritsOrImplements(this Type child, Type parent)
    {
      parent = ResolveGenericTypeDefinition(parent);

      var currentChild = child.IsGenericType
                             ? child.GetGenericTypeDefinition()
                             : child;

      while (currentChild != typeof(object))
      {
        if (parent == currentChild || HasAnyInterfaces(parent, currentChild))
          return true;

        currentChild = currentChild.BaseType != null
                       && currentChild.BaseType.IsGenericType
                           ? currentChild.BaseType.GetGenericTypeDefinition()
                           : currentChild.BaseType;

        if (currentChild == null)
          return false;
      }
      return false;
    }

    private static bool HasAnyInterfaces(Type parent, Type child)
    {
      return child.GetInterfaces()
          .Any(childInterface =>
          {
            var currentInterface = childInterface.IsGenericType
              ? childInterface.GetGenericTypeDefinition()
              : childInterface;

            return currentInterface == parent;
          });
    }

    private static Type ResolveGenericTypeDefinition(Type parent)
    {
      var shouldUseGenericType = true;
      if (parent.IsGenericType && parent.GetGenericTypeDefinition() != parent)
        shouldUseGenericType = false;

      if (parent.IsGenericType && shouldUseGenericType)
        parent = parent.GetGenericTypeDefinition();
      return parent;
    }
  }
}
