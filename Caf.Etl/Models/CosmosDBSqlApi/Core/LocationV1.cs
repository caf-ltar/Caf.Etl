﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Caf.Etl.Models.CosmosDBSqlApi.Core
{
    /// <summary></summary>
    /// <todo>Consider using a proper GeoJSON library: https://github.com/GeoJSON-Net/GeoJSON.Net</todo>
    public class LocationV1
    {
        /// <summary>
        /// Type maps type
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; private set; }

        /// <summary>
        /// Coordinates maps coordinates
        /// </summary>
        /// <returns>
        /// List of two doubles; Latitude, Longitude
        /// </returns>
        [JsonProperty("coordinates")]
        public List<double> Coordinates { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        [JsonConstructor]
        public LocationV1(
            string type,
            double latitude,
            double longitude)
        {
            Type = type;
            Coordinates = new List<double>()
            {
                latitude,
                longitude
            };
        }
    }
}
