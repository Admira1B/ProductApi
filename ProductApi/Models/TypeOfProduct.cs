using System.Text.Json.Serialization;

namespace ProductApi.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TypeOfProduct
    {
        Food = 1,
        Drink,
        HouseholdGood,
    }
}
