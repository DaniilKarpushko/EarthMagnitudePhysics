using System.Text.Json.Serialization;

namespace PhysicMagnitude.Models.Entities;

public class Data
{
    [JsonPropertyName("result")]
    public IEnumerable<MagneticData> Datas { get; set; }
}