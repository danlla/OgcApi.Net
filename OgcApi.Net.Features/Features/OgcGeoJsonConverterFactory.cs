﻿using NetTopologySuite.IO.Converters;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OgcApi.Net.Features.Features
{
    public class OgcGeoJsonConverterFactory : GeoJsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(OgcFeatureCollection) || base.CanConvert(typeToConvert);
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            if (typeToConvert == typeof(OgcFeatureCollection))
                return new OgcFeatureCollectionConverter();
            if (typeToConvert == typeof(OgcFeature))
                return new OgcFeatureConverter();

            return base.CreateConverter(typeToConvert, options);
        }
    }
}
