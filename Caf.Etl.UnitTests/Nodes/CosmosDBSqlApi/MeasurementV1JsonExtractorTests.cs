using System;
using Xunit;
using Caf.Etl.Nodes.CosmosDBSqlApi.Extract;
using Caf.Etl.Models.CosmosDBSqlApi.Core;
using System.Collections.Generic;
using System.Globalization;
using Caf.Etl.Models.CosmosDBSqlApi.Measurement;

namespace Caf.Etl.UnitTests.Nodes.CosmosDBSqlApi
{
    public class MeasurementV1JsonExtractorTests
    {
        [Fact]
        public void ToMeasurements_ValidData_ReturnsCorrectMeasurements()
        {
            // Arrange
            MeasurementJsonExtractor sut = new MeasurementJsonExtractor();
            List<MeasurementV1> expected = getValidMeasurements();

            // Act
            List<MeasurementV1> actual = sut.ToMeasurements(getJsonValidMeasurements());

            // Assert
            // TODO: Add Equals functions to Measurement class
            for(int i = 0; i < 2; i++)
            {
                Assert.Equal(expected[i].Name, actual[i].Name);
                Assert.Equal(expected[i].PhysicalQuantities[0].Value, actual[i].PhysicalQuantities[0].Value);
                Assert.Equal(expected[i].PhysicalQuantities[0].Unit, actual[i].PhysicalQuantities[0].Unit);
                Assert.Equal(expected[i].MeasurementDateTime, actual[i].MeasurementDateTime);
            }
        }

        private string getJsonValidMeasurements()
        {
            return "[ { \"name\": \"WindSpeedTsResultant\", \"measurementDateTime\": \"2017-09-06T00:00:00Z\", \"physicalQuantities\": [ { \"value\": 3.014338, \"unit\": \"m/s\", \"qualityCode\": 0, \"qcAppliedCode\": 0, \"qcResultCode\": 0, \"submissionDateTime\": \"2017-09-06T00:04:15.9797575Z\", \"sourceId\": \"CosmosDBSqlApiTransformer\" } ] }, { \"name\": \"TemperatureAirTsAvg\", \"measurementDateTime\": \"2017-09-06T00:00:00Z\", \"physicalQuantities\": [ { \"value\": 27.80702, \"unit\": \"C\", \"qualityCode\": 0, \"qcAppliedCode\": 0, \"qcResultCode\": 0, \"submissionDateTime\": \"2017-09-06T00:04:15.9797575Z\", \"sourceId\": \"DocumentDbMeasurementTransformer\" } ] }, { \"name\": \"PrecipitationTsAccum\", \"measurementDateTime\": \"2017-09-06T00:00:00Z\", \"physicalQuantities\": [ { \"value\": 0, \"unit\": \"m\", \"qualityCode\": 0, \"qcAppliedCode\": 0, \"qcResultCode\": 0, \"submissionDateTime\": \"2017-09-06T00:04:15.9797575Z\", \"sourceId\": \"DocumentDbMeasurementTransformer\" } ] }, { \"name\": \"WindDirection\", \"measurementDateTime\": \"2017-09-06T00:00:00Z\", \"physicalQuantities\": [ { \"value\": 125.9, \"unit\": \"deg\", \"qualityCode\": 0, \"qcAppliedCode\": 0, \"qcResultCode\": 0, \"submissionDateTime\": \"2017-09-06T00:04:15.9797575Z\", \"sourceId\": \"DocumentDbMeasurementTransformer\" } ] }, { \"name\": \"RelativeHumidityTsAvg\", \"measurementDateTime\": \"2017-09-06T00:00:00Z\", \"physicalQuantities\": [ { \"value\": 22.4503, \"unit\": \"%\", \"qualityCode\": 0, \"qcAppliedCode\": 0, \"qcResultCode\": 0, \"submissionDateTime\": \"2017-09-06T00:04:15.9797575Z\", \"sourceId\": \"DocumentDbMeasurementTransformer\" } ] }, { \"name\": \"BatteryVoltageTsAvg\", \"measurementDateTime\": \"2017-09-06T00:00:00Z\", \"physicalQuantities\": [ { \"value\": 13.01541, \"unit\": \"V\", \"qualityCode\": 0, \"qcAppliedCode\": 0, \"qcResultCode\": 0, \"submissionDateTime\": \"2017-09-06T00:04:15.9797575Z\", \"sourceId\": \"DocumentDbMeasurementTransformer\" } ] }, { \"name\": \"PressureAirTsAvg\", \"measurementDateTime\": \"2017-09-06T00:00:00Z\", \"physicalQuantities\": [ { \"value\": 93334.82, \"unit\": \"Pa\", \"qualityCode\": 0, \"qcAppliedCode\": 0, \"qcResultCode\": 0, \"submissionDateTime\": \"2017-09-06T00:04:15.9797575Z\", \"sourceId\": \"DocumentDbMeasurementTransformer\" } ] }, { \"name\": \"ParDensityTsAvg\", \"measurementDateTime\": \"2017-09-06T00:00:00Z\", \"physicalQuantities\": [ { \"value\": 0.0002833229, \"unit\": \"mol/(m^2 s)\", \"qualityCode\": 0, \"qcAppliedCode\": 0, \"qcResultCode\": 0, \"submissionDateTime\": \"2017-09-06T00:04:15.9797575Z\", \"sourceId\": \"DocumentDbMeasurementTransformer\" } ] }, { \"name\": \"TemperaturePanelTsAvg\", \"measurementDateTime\": \"2017-09-06T00:00:00Z\", \"physicalQuantities\": [ { \"value\": 29.87764, \"unit\": \"C\", \"qualityCode\": 0, \"qcAppliedCode\": 0, \"qcResultCode\": 0, \"submissionDateTime\": \"2017-09-06T00:04:15.9797575Z\", \"sourceId\": \"DocumentDbMeasurementTransformer\" } ] } ]";
        }

        private List<MeasurementV1> getValidMeasurements()
        {
            List<MeasurementV1> results = new List<MeasurementV1>()
            {
                new MeasurementV1(
                    "", "", "", "WindSpeedTsResultant", "", "", "", "", "", "", null, "", null, DateTime.ParseExact("2017-09-06T00:00:00Z", "yyyy-MM-dd'T'HH:mm:ss'Z'", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal), new List<PhysicalQuantityV1>()
                    {
                        new PhysicalQuantityV1(3.014338m, "m/s", 0, 0, 0, DateTime.Parse("2017-09-06T00:04:15.9797575Z"), "CosmosDBSqlApiTransformer")
                    }),
                new MeasurementV1(
                    "", "", "", "TemperatureAirTsAvg", "", "", "", "", "", "", null, "", null, DateTime.ParseExact("2017-09-06T00:00:00Z", "yyyy-MM-dd'T'HH:mm:ss'Z'", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal), new List<PhysicalQuantityV1>()
                    {
                        new PhysicalQuantityV1(27.80702m, "C", 0, 0, 0, DateTime.Parse("2017-09-06T00:04:15.9797575Z"), "CosmosDBSqlApiTransformer")
                    }),

                new MeasurementV1(
                    "", "", "", "PrecipitationTsAccum", "", "", "", "", "", "", null, "", null, DateTime.ParseExact("2017-09-06T00:00:00Z", "yyyy-MM-dd'T'HH:mm:ss'Z'", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal), new List<PhysicalQuantityV1>()
                    {
                        new PhysicalQuantityV1(0m, "m", 0, 0, 0, DateTime.Parse("2017-09-06T00:04:15.9797575Z"), "CosmosDBSqlApiTransformer")
                    }),
                new MeasurementV1(
                    "", "", "", "WindDirection", "", "", "", "", "", "", null, "", null, DateTime.ParseExact("2017-09-06T00:00:00Z", "yyyy-MM-dd'T'HH:mm:ss'Z'", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal), new List<PhysicalQuantityV1>()
                    {
                        new PhysicalQuantityV1(125.9m, "deg", 0, 0, 0, DateTime.Parse("2017-09-06T00:04:15.9797575Z"), "CosmosDBSqlApiTransformer")
                    }),
                new MeasurementV1(
                    "", "", "", "RelativeHumidityTsAvg", "", "", "", "", "", "", null, "", null, DateTime.ParseExact("2017-09-06T00:00:00Z", "yyyy-MM-dd'T'HH:mm:ss'Z'", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal), new List<PhysicalQuantityV1>()
                    {
                        new PhysicalQuantityV1(22.4503m, "%", 0, 0, 0, DateTime.Parse("2017-09-06T00:04:15.9797575Z"), "CosmosDBSqlApiTransformer")
                    }),
                new MeasurementV1(
                    "", "", "", "BatteryVoltageTsAvg", "", "", "", "", "", "", null, "", null, DateTime.ParseExact("2017-09-06T00:00:00Z", "yyyy-MM-dd'T'HH:mm:ss'Z'", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal), new List<PhysicalQuantityV1>()
                    {
                        new PhysicalQuantityV1(13.01541m, "V", 0, 0, 0, DateTime.Parse("2017-09-06T00:04:15.9797575Z"), "CosmosDBSqlApiTransformer")
                    }),
                new MeasurementV1(
                    "", "", "", "PressureAirTsAvg", "", "", "", "", "", "", null, "", null, DateTime.ParseExact("2017-09-06T00:00:00Z", "yyyy-MM-dd'T'HH:mm:ss'Z'", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal), new List<PhysicalQuantityV1>()
                    {
                        new PhysicalQuantityV1(93334.82m, "Pa", 0, 0, 0, DateTime.Parse("2017-09-06T00:04:15.9797575Z"), "CosmosDBSqlApiTransformer")
                    }),
                new MeasurementV1(
                    "", "", "", "ParDensityTsAvg", "", "", "", "", "", "", null, "", null, DateTime.ParseExact("2017-09-06T00:00:00Z", "yyyy-MM-dd'T'HH:mm:ss'Z'", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal), new List<PhysicalQuantityV1>()
                    {
                        new PhysicalQuantityV1(0.0002833229m, "mol/(m^2 s)", 0, 0, 0, DateTime.Parse("2017-09-06T00:04:15.9797575Z"), "CosmosDBSqlApiTransformer")
                    }),
                new MeasurementV1(
                    "", "", "", "TemperaturePanelTsAvg", "", "", "", "", "", "", null, "", null, DateTime.ParseExact("2017-09-06T00:00:00Z", "yyyy-MM-dd'T'HH:mm:ss'Z'", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal), new List<PhysicalQuantityV1>()
                    {
                        new PhysicalQuantityV1(29.87764m, "C", 0, 0, 0, DateTime.Parse("2017-09-06T00:04:15.9797575Z"), "CosmosDBSqlApiTransformer")
                    })
            };

            return results;
        }
    }
}
