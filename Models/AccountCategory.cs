using System.Text.Json.Serialization;

namespace BlueCatBackEnd.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AccountCategory
    {
        Guest = 1,
        BasicUser = 2,
        SuperUser = 3
    }
}