using PhysicMagnitude.Models.Entities;

namespace PhysicMagnitude.Models.Services;

public interface IMagnitudeIntensityService
{
    Task<Data> GetData(decimal latitude, decimal longitude);
    Task<Data> GetDatasLatitude(decimal longitude = -180);
    Task<Data> GetDatasLongitude(decimal latitude = -90);
}