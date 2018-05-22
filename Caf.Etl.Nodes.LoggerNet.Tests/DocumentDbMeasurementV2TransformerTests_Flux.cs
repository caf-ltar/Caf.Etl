﻿using Caf.Etl.Nodes.LoggerNet.Transform;
using System.Collections.Generic;
using Xunit;
using Caf.Etl.Models.CosmosDBSqlApi.Measurement;
using Caf.Etl.Models.LoggerNet.TOA5;
using System;
using Caf.Etl.Models.LoggerNet.TOA5.DataTables;
using Caf.Etl.Nodes.TestUtils;
using System.Linq;

namespace Caf.Etl.Nodes.LoggerNet.Tests
{
    public class DocumentDbMeasurementV2TransformerTests_Flux
    {
        [Fact]
        public void ToMeasurement_ValidData_ReturnCorrectMeasurements()
        {
            //# Arrange
            Mappers.MapFromFluxDataTableToCafStandards map = 
                new Mappers.MapFromFluxDataTableToCafStandards();
            TOA5 toa5 = LoggerNetArranger.GetToa5FluxDerivedFromActualData();

            List<MeasurementV2> expected = LoggerNetArranger.GetMeasurementV2sDerivedFromActualData();

            DocumentDbMeasurementV2Transformer sut =
                new DocumentDbMeasurementV2Transformer(
                    map,
                    "http://files.cafltar.org/data/schema/documentDb/v2/measurement.json",
                    1800);

            //# Act
            var actual = sut.ToMeasurements(toa5);

            //# Assert
            Assert.Equal(expected.Count, actual.Count);
            Assert.True(AreMeasurementsRoughlyEqual(expected, actual));
        }

        private bool AreMeasurementsRoughlyEqual(List<MeasurementV2> firsts, List<MeasurementV2> seconds)
        {
            foreach(var first in firsts)
            {
                var second = seconds.SingleOrDefault(m => m.ID == first.ID);
                if (second == null)
                    return false;

                if (!AreMeasurementRoughlyEqual(first, second))
                    return false;
            }

            return true;
        }

        private bool AreMeasurementRoughlyEqual(MeasurementV2 first, MeasurementV2 second)
        {
            return first.AreaOfInterest == second.AreaOfInterest
                && first.Location == second.Location
                && first.PartitionKey == second.PartitionKey
                && first.PhysicalQuantities.Count == second.PhysicalQuantities.Count
                && ArePhysicalQuantityV2RoughlyEqual(first.PhysicalQuantities[0],second.PhysicalQuantities[0])
                && first.Project == second.Project
                && first.Schema == second.Schema
                && first.TimestepSec == second.TimestepSec
                && first.Type == second.Type
                && first._attachments == second._attachments
                && first._etag == second._etag
                && first._rid == second._rid
                && first._self == second._self
                && first._ts == second._ts;
                
        }


        private bool ArePhysicalQuantityV2RoughlyEqual(
            PhysicalQuantityV2 first,
            PhysicalQuantityV2 second)
        {
            return first.QCValues == second.QCValues
                && first.QualityControlId == second.QualityControlId
                && first.SourceID == second.SourceID
                && first.Unit == second.Unit
                && first.Value == second.Value;
        }
    }
}
