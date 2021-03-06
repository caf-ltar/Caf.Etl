﻿using Caf.Etl.Models.LoggerNet.TOA5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caf.Etl.Nodes.LoggerNet.Core
{
    /// <summary>
    /// Maps primative types found in Meteorology CSV Tables to other values using look up tables or other means
    /// </summary>
    public interface IMapper
    {
        string GetFieldID(Metadata metadata);
        double GetLatFromStation(Metadata metadata);
        double GetLonFromStation(Metadata metadata);
        string GetMeasurementName(string dataField);
    }
}
