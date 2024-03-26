using System;

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Globalization;
namespace Hmo.NewFolder2
{
    public class DateConverter : JsonConverter<DateOnly>
    {

        private string _dateFormat = "yyyy-MM-dd";
        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateOnly.ParseExact(reader.GetString(), _dateFormat, CultureInfo.InvariantCulture);


        }
        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
           writer.WriteStringValue(value.ToString(_dateFormat));
        }
    }
}
