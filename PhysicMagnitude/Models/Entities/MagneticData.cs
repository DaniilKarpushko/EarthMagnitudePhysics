using System.Text.Json.Serialization;

namespace PhysicMagnitude.Models.Entities;

public class MagneticData
{
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }
    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }
    [JsonPropertyName("totalintensity")]
    public double Totalintensity { get; set; }
}