﻿using Microsoft.Extensions.Logging.Abstractions;
using OgcApi.Net.Options;
using OgcApi.Net.Options.Features;
using OgcApi.Net.PostGis;
using OgcApi.PostGis.Tests.Utils;
using System;
using System.Collections.Generic;

namespace OgcApi.PostGis.Tests
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
                        Id ="Polygons",
                        Features = new CollectionFeaturesOptions
                        {
                            Crs = new List<Uri>
                            {
                                new("http://www.opengis.net/def/crs/OGC/1.3/CRS84"),
                                new("http://www.opengis.net/def/crs/EPSG/0/3857")
                            },
                            StorageCrs = new Uri("http://www.opengis.net/def/crs/EPSG/0/3857"),
                            Storage = new SqlFeaturesSourceOptions
                            {
                                Type= "PostGis",
                                ConnectionString = DatabaseUtils.GetConnectionString(),
                                Schema = "public",
                                Table = "polygons",
                                IdentifierColumn = "id",
                                GeometryColumn = "geom",
                                GeometryDataType = "geometry",
                                GeometrySrid = 3857,
                                DateTimeColumn = "date",
                                Properties = new List<string>
                                {
                                    "name",
                                    "num",
                                    "s",
                                    "date"
                                }
                            }
                        }
                    },
                    new()
                    {
                        Id ="LineStrings",
                        Features = new CollectionFeaturesOptions
                        {
                            Crs = new List<Uri>
                            {
                                new("http://www.opengis.net/def/crs/OGC/1.3/CRS84"),
                                new("http://www.opengis.net/def/crs/EPSG/0/3857")
                            },
                            StorageCrs = new Uri("http://www.opengis.net/def/crs/EPSG/0/3857"),
                            Storage = new SqlFeaturesSourceOptions
                            {
                                Type= "PostGis",
                                ConnectionString = DatabaseUtils.GetConnectionString(),
                                Schema = "public",
                                Table = "linestrings",
                                IdentifierColumn = "id",
                                GeometryColumn = "geom",
                                GeometryDataType = "geometry",
                                GeometrySrid = 3857,
                                Properties = new List<string>
                                {
                                    "name"
                                }
                            }
                        }
                    },
                    new()
                    {
                        Id ="Points",
                        Features = new CollectionFeaturesOptions
                        {
                            Crs = new List<Uri>
                            {
                                new("http://www.opengis.net/def/crs/OGC/1.3/CRS84"),
                                new("http://www.opengis.net/def/crs/EPSG/0/3857")
                            },
                            StorageCrs = new Uri("http://www.opengis.net/def/crs/EPSG/0/3857"),
                            Storage = new SqlFeaturesSourceOptions
                            {
                                Type= "PostGis",
                                ConnectionString = DatabaseUtils.GetConnectionString(),
                                Schema = "public",
                                Table = "points",
                                IdentifierColumn = "id",
                                GeometryColumn = "geom",
                                GeometryDataType = "geometry",
                                GeometrySrid = 3857,
                                Properties = new List<string>
                                {
                                    "name"
                                }
                            }
                        }
                    },
                    new()
                    {
                        Id ="Empty",
                        Features = new CollectionFeaturesOptions
                        {
                            Crs = new List<Uri>
                            {
                                new("http://www.opengis.net/def/crs/OGC/1.3/CRS84"),
                                new("http://www.opengis.net/def/crs/EPSG/0/3857")
                            },
                            StorageCrs = new Uri("http://www.opengis.net/def/crs/EPSG/0/3857"),
                            Storage = new SqlFeaturesSourceOptions
                            {
                                Type= "PostGis",
                                ConnectionString = DatabaseUtils.GetConnectionString(),
                                Schema = "public",
                                Table = "empty_table",
                                IdentifierColumn = "id",
                                GeometryColumn = "geom",
                                GeometryDataType = "geometry",
                                GeometrySrid = 3857,
                                Properties = new List<string>
                                {
                                    "name"
                                }
                            }
                        }
                    },
                    new()
                    {
                        Id = "PolygonsForInsert",
                        Features = new CollectionFeaturesOptions
                        {
                            Crs = new List<Uri>
                            {
                                new("http://www.opengis.net/def/crs/OGC/1.3/CRS84"),
                                new("http://www.opengis.net/def/crs/EPSG/0/3857")
                            },
                            StorageCrs = new Uri("http://www.opengis.net/def/crs/EPSG/0/3857"),
                            Storage = new SqlFeaturesSourceOptions
                            {
                                Type= "PostGis",
                                ConnectionString = DatabaseUtils.GetConnectionString(),
                                Schema = "public",
                                Table = "polygons_for_insert",
                                IdentifierColumn = "id",
                                GeometryColumn = "geom",
                                GeometryDataType = "geometry",
                                GeometrySrid = 3857,
                                DateTimeColumn = "date",
                                Properties = new List<string>
                                {
                                    "name",
                                    "num",
                                    "s",
                                    "date"
                                }
                            }
                        }
                    }
                }
            };
        }
        private static CollectionsOptions GetOptionsWithUnknownTable()
        {
            return new CollectionsOptions
            {
                Items = new List<CollectionOptions>
                {
                    new()
                    {
                        Id ="Test",
                        Features = new CollectionFeaturesOptions
                        {
                             Crs = new List<Uri>
                             {
                                new("http://www.opengis.net/def/crs/OGC/1.3/CRS84"),
                                new("http://www.opengis.net/def/crs/EPSG/0/3857")
                            },
                            StorageCrs = new Uri("http://www.opengis.net/def/crs/EPSG/0/3857"),
                            Storage = new SqlFeaturesSourceOptions
                            {
                                Type= "PostGis",
                                ConnectionString = DatabaseUtils.GetConnectionString(),
                                Schema = "public",
                                Table = "test",
                                IdentifierColumn = "id",
                                GeometryColumn = "geom",
                                GeometryDataType = "geometry",
                                GeometrySrid = 3857
                            }

                        }

                    }
                }
            };
        }

        private static CollectionsOptions GetOptionsWithApiKey()
        {
            return new CollectionsOptions
            {
                Items = new List<CollectionOptions>
                {
                    new()
                    {
                        Id = "PointsWithApiKey",
                        Features = new CollectionFeaturesOptions
                        {
                             Crs = new List<Uri>
                             {
                                new("http://www.opengis.net/def/crs/OGC/1.3/CRS84"),
                                new("http://www.opengis.net/def/crs/EPSG/0/3857")
                            },
                            StorageCrs = new Uri("http://www.opengis.net/def/crs/EPSG/0/3857"),
                            Storage = new SqlFeaturesSourceOptions
                            {
                                Type= "PostGis",
                                ConnectionString = DatabaseUtils.GetConnectionString(),
                                Schema = "public",
                                Table = "points_with_api_key",
                                IdentifierColumn = "id",
                                GeometryColumn = "geom",
                                GeometryDataType = "geometry",
                                GeometrySrid = 3857,
                                Properties = new List<string>
                                {
                                    "name"
                                },
                                ApiKeyPredicateForGet = "key = @ApiKey"
                            }
                        }
                    }
                }
            };
        }

        public static PostGisProvider GetDefaultProvider()
        {
            var options = GetDefaultOptions();
            var provider = new PostGisProvider(new NullLogger<PostGisProvider>())
            {
                CollectionsOptions = options
            };
            return provider;
        }

        public static PostGisProvider GetProviderWithErrors()
        {
            var options = GetOptionsWithUnknownTable();
            var provider = new PostGisProvider(new NullLogger<PostGisProvider>())
            {
                CollectionsOptions = options
            };
            return provider;
        }

        public static PostGisProvider GetProviderWithApiKey()
        {
            var options = GetOptionsWithApiKey();
            var provider = new PostGisProvider(new NullLogger<PostGisProvider>())
            {
                CollectionsOptions = options
            };
            return provider;
        }
    }
}