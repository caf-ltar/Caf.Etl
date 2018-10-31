﻿using Caf.Etl.Nodes.LoggerNet.Transform;
using Caf.Etl.Nodes.LoggerNet.Mappers;
using System.Collections.Generic;
using Xunit;
using Caf.Etl.Models.CosmosDBSqlApi.Core;
using Caf.Etl.Models.LoggerNet.TOA5;
using System;
using Caf.Etl.Models.LoggerNet.TOA5.DataTables;
using Caf.Etl.Models.CosmosDBSqlApi.Measurement;

namespace Caf.Etl.UnitTests.Nodes.LoggerNet
{
    public class CosmosDBSqlApiV1TransformerTests_Meteorology
    {
        [Fact]
        public void ToMeasurement_ValidData_ReturnCorrectMeasurements()
        {
            //# Arrange
            MeasurementV1 expectedMeasurement_RH_Avg = new MeasurementV1(
                "EcTower_CookEast_RelativeHumidityTsAvg",
                "CookEast_RelativeHumidityTsAvg_2017-06-20T11:30:00.0000000Z",
                "Measurement",
                "RelativeHumidityTsAvg",
                "1.0.0",
                "CafMeteorologyEcTower",
                "", "", "", "", null,
                "CookEast",
                new LocationV1("Point", 46.78152, -117.08205),
                new DateTime(2017, 6, 20, 11, 30, 0),
                new List<PhysicalQuantityV1>() { new PhysicalQuantityV1(
                    (decimal)56.22676, "%", 0, 0, 0,
                    DateTime.MaxValue,
                    "CosmosDBSqlApiTransformer")});

            MeasurementV1 expectedMeasurement_amb_tmpr_Avg = new MeasurementV1(
                "EcTower_CookEast_TemperatureAirTsAvg",
                "CookEast_TemperatureAirTsAvg_2017-06-20T11:30:00.0000000Z",
                "Measurement",
                "TemperatureAirTsAvg",
                "1.0.0",
                "CafMeteorologyEcTower",
                "", "", "", "", null,
                "CookEast",
                new LocationV1("Point", 46.78152, -117.08205),
                new DateTime(2017, 6, 20, 11, 30, 0),
                new List<PhysicalQuantityV1>() { new PhysicalQuantityV1(
                    (decimal)4.940109, "C", 0, 0, 0,
                    DateTime.MaxValue,
                    "CosmosDBSqlApiTransformer")});

            MeasurementV1 expectedMeasurement_PAR_density_Avg = new MeasurementV1(
                "EcTower_CookEast_ParDensityTsAvg",
                "CookEast_ParDensityTsAvg_2017-06-20T11:30:00.0000000Z",
                "Measurement",
                "ParDensityTsAvg",
                "1.0.0",
                "CafMeteorologyEcTower",
                "", "", "", "", null,
                "CookEast",
                new LocationV1("Point", 46.78152, -117.08205),
                new DateTime(2017, 6, 20, 11, 30, 0),
                new List<PhysicalQuantityV1>() { new PhysicalQuantityV1(
                    (decimal)0.001956598, "mol/(m^2 s)", 0, 0, 0,
                    DateTime.MaxValue,
                    "CosmosDBSqlApiTransformer")});

            List<MeasurementV1> actualMeasurements = new List<MeasurementV1>();

            //# Act
            MapFromMeteorologyDataTableToCafStandards map = 
                new MapFromMeteorologyDataTableToCafStandards();

            CosmosDBSqlApiV1Transformer sut = 
                new CosmosDBSqlApiV1Transformer(map, "1.0.0");
            actualMeasurements = sut.ToMeasurements(GetMockMeteorology());

            //# Assert
            Assert.Equal(
                actualMeasurements
                    .Find(m => m.Name == expectedMeasurement_RH_Avg.Name)
                    .PhysicalQuantities[0].Value,
                expectedMeasurement_RH_Avg.PhysicalQuantities[0].Value);
            Assert.Equal(
                actualMeasurements
                    .Find(m => m.Name == expectedMeasurement_RH_Avg.Name)
                    .PhysicalQuantities[0].Unit,
                expectedMeasurement_RH_Avg.PhysicalQuantities[0].Unit);
            Assert.Equal(
                actualMeasurements
                    .Find(m => m.Name == expectedMeasurement_amb_tmpr_Avg.Name)
                    .PhysicalQuantities[0].Value,
                expectedMeasurement_amb_tmpr_Avg.PhysicalQuantities[0].Value);
            Assert.Equal(
                actualMeasurements
                    .Find(m => m.Name == expectedMeasurement_amb_tmpr_Avg.Name)
                    .PhysicalQuantities[0].Unit,
                expectedMeasurement_amb_tmpr_Avg.PhysicalQuantities[0].Unit);
            Assert.Equal(
                actualMeasurements
                    .Find(m => m.Name == expectedMeasurement_PAR_density_Avg.Name)
                    .PhysicalQuantities[0].Value,
                expectedMeasurement_PAR_density_Avg.PhysicalQuantities[0].Value);
            Assert.Equal(
                actualMeasurements
                    .Find(m => m.Name == expectedMeasurement_PAR_density_Avg.Name)
                    .ID,
                expectedMeasurement_PAR_density_Avg.ID);
            Assert.Equal(
                actualMeasurements
                    .Find(m => m.Name == expectedMeasurement_PAR_density_Avg.Name)
                    .FieldID,
                expectedMeasurement_PAR_density_Avg.FieldID);
            Assert.Equal(
                actualMeasurements
                    .Find(m => m.Name == expectedMeasurement_PAR_density_Avg.Name)
                    .Location.Coordinates[0],
                expectedMeasurement_PAR_density_Avg.Location.Coordinates[0]);
            Assert.Equal(
                actualMeasurements
                    .Find(m => m.Name == expectedMeasurement_PAR_density_Avg.Name)
                    .MetadataID,
                expectedMeasurement_PAR_density_Avg.MetadataID);
            Assert.Equal(
                actualMeasurements
                    .Find(m => m.Name == expectedMeasurement_PAR_density_Avg.Name)
                    .SchemaVersion,
                expectedMeasurement_PAR_density_Avg.SchemaVersion);
        }

        private TOA5 GetMockMeteorology()
        {
            TOA5 met = new TOA5();

            met.Observations = new List<IObservation>();
            met.Observations.Add(new  Meteorology()
            {
                TIMESTAMP = new System.DateTime(2017, 6, 20, 11, 30, 00),
                RECORD = 15,
                amb_tmpr_Avg = 4.940109,
                rslt_wnd_spd = 4.940109,
                wnd_dir_compass = 259.7,
                RH_Avg = 56.22676,
                Precipitation_Tot = 0,
                amb_press_Avg = 93.25672,
                PAR_density_Avg = 1956.598,
                batt_volt_Avg = 13.63667,
                panel_tmpr_Avg = 25.22728,
                std_wnd_dir = 14.26,
                VPD_air = 1.244421,
                Rn_meas_Avg = 643.2509
            });

            met.Metadata = new Metadata()
            {
                FileFormat = "TOA5",
                StationName = "LTAR_CookEast",
                DataLoggerType = "CR3000",
                SerialNumber = 6503,
                OperatingSystemVersion = "CR3000.Std.31",
                DataloggerProgramName = "CPU:DEFAULT.CR3",
                DataloggerProgramSignature = 13636,
                TableName = "LTAR_Met",

                Variables = new List<Variable>()
                {
                    new Variable()
                    {
                        FieldName = "TIMESTAMP",
                        Units = "TS",
                        Processing = ""
                    },
                    new Variable()
                    {
                        FieldName = "RECORD",
                        Units = "",
                        Processing = ""
                    },
                    new Variable()
                    {
                        FieldName = "amb_tmpr_Avg",
                        Units = "C",
                        Processing = "Avg"
                    },
                    new Variable()
                    {
                        FieldName = "rslt_wnd_spd",
                        Units = "m/s",
                        Processing = "Smp"
                    },
                    new Variable()
                    {
                        FieldName = "wnd_dir_compass",
                        Units = "degrees",
                        Processing = "Smp"
                    },
                    new Variable()
                    {
                        FieldName = "RH_Avg",
                        Units = "%",
                        Processing = "Avg"
                    },
                    new Variable()
                    {
                        FieldName = "Precipitation_Tot",
                        Units = "mm",
                        Processing = "Tot"
                    },
                    new Variable()
                    {
                        FieldName = "amb_press_Avg",
                        Units = "kPa",
                        Processing = "Avg"
                    },
                    new Variable()
                    {
                        FieldName = "PAR_density_Avg",
                        Units = "umol/(s m^2)",
                        Processing = "Avg"
                    },
                    new Variable()
                    {
                        FieldName = "batt_volt_Avg",
                        Units = "V",
                        Processing = "Avg"
                    },
                    new Variable()
                    {
                        FieldName = "panel_tmpr_Avg",
                        Units = "C",
                        Processing = "Avg"
                    },
                    new Variable()
                    {
                        FieldName = "std_wnd_dir",
                        Units = "degrees",
                        Processing = "Smp"
                    },
                    new Variable()
                    {
                        FieldName = "VPD_air",
                        Units = "kpa",
                        Processing = "Smp"
                    },
                    new Variable()
                    {
                        FieldName = "Rn_meas_Avg",
                        Units = "W/m^2",
                        Processing = "Avg"
                    }
                }
            };

            return met;
        }
    }
}
