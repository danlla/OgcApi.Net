﻿using Microsoft.Extensions.Logging.Abstractions;
using OgcApi.Net.MbTiles;
using OgcApi.Net.Options;
using System;
using System.Collections.Generic;
using System.IO;

namespace OgcApi.MbTiles.Tests
{
    public static class TestProviders
    {
        private static CollectionsOptions GetDefaultOptions()
        {
            return new CollectionsOptions
            {
                Items = new List<CollectionOptions>
                {
                    new()
                    {
                        Title = "data",
                        Id =  "data",
                        Tiles = new()
                        {
                            TileMatrixSet = new Uri("http://www.opengis.net/def/tilematrixset/OGC/1.0/WorldMercatorWGS84Quad"),
                            Crs = new Uri("http://www.opengis.net/def/crs/EPSG/0/3395"),
                            Storage = new MbTilesSourceOptions()
                            {
                                Type = "MbTiles",
                                ConnectionString = "Data Source=" + Path.Combine("Data", "data.mbtiles")
                            }
                        }
                    }
                }
            };
        }

        private static CollectionsOptions GetOptionsWithUnknownDataFile()
        {
            return new CollectionsOptions
            {
                Items = new List<CollectionOptions>
                {
                    new()
                    {
                        Title = "data",
                        Id =  "data",
                        Tiles = new()
                        {
                            TileMatrixSet = new Uri("http://www.opengis.net/def/tilematrixset/OGC/1.0/WorldMercatorWGS84Quad"),
                            Crs = new Uri("http://www.opengis.net/def/crs/EPSG/0/3395"),
                            Storage = new MbTilesSourceOptions()
                            {
                                Type = "MbTiles",
                                ConnectionString = "Data Source=" + Path.Combine("Data", "test.mbtiles")
                            }
                        }
                    }
                }
            };
        }

        public static MbTilesProvider GetDefaultProvider()
        {
            return new MbTilesProvider(new NullLogger<MbTilesProvider>()) { CollectionsOptions = GetDefaultOptions() };
        }

        public static MbTilesProvider GetProviderWithErrors()
        {
            return new MbTilesProvider(new NullLogger<MbTilesProvider>()) { CollectionsOptions = GetOptionsWithUnknownDataFile() };
        }
    }
}
