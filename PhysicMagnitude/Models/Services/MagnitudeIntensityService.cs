using System.Globalization;
using System.Net;
using System.Text.Json;
using PhysicMagnitude.Models.Entities;

namespace PhysicMagnitude.Models.Services;

public class MagnitudeIntensityService : IMagnitudeIntensityService
{
    private HttpClient _client;
    private readonly string _url = "https://www.ngdc.noaa.gov/geomag-web/calculators/calculateIgrfwmm?model=WMM&key=EAU2y&resultFormat=json";
    private readonly string _url_datas = "https://www.ngdc.noaa.gov/geomag-web/calculators/calculateIgrfgrid?lat1=-90.0&lat2=90.0&lon1=-180.0&lon2=-180.0&latStepSize=0.1&lonStepSize=0.1&magneticComponent=f&key=gFE5W&resultFormat=json";
    
    public MagnitudeIntensityService(HttpClient client)
    {
        _client = client;
    }
    
    public async Task<Data> GetData(decimal latitude, decimal longitude)
    {
        await using Stream stream =
            await _client.GetStreamAsync(_url + $"&lat1={latitude.ToString(CultureInfo.InvariantCulture)}&lon1={longitude.ToString(CultureInfo.InvariantCulture)}");
        return await JsonSerializer.DeserializeAsync<Data>(stream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public async Task<Data> GetDatasLatitude(decimal longitude = -180)
    {
        await using Stream stream =
            await _client.GetStreamAsync($"https://www.ngdc.noaa.gov/geomag-web/calculators/calculateIgrfgrid?lat1=-90.0&lat2=90.0&lon1={longitude.ToString(CultureInfo.InvariantCulture)}&lon2={longitude.ToString(CultureInfo.InvariantCulture)}&latStepSize=0.1&lonStepSize=0.1&magneticComponent=f&key=gFE5W&resultFormat=json");
        return await JsonSerializer.DeserializeAsync<Data>(stream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public async Task<Data> GetDatasLongitude(decimal latitude = -90)
    {
        await using Stream stream =
            await _client.GetStreamAsync($"https://www.ngdc.noaa.gov/geomag-web/calculators/calculateIgrfgrid?lat1={latitude}&lat2={latitude}&lon1=-180.0&lon2=180.0&latStepSize=0.1&lonStepSize=0.1&magneticComponent=f&key=gFE5W&resultFormat=json");
        return await JsonSerializer.DeserializeAsync<Data>(stream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
}