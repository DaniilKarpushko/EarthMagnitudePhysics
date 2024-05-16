using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PhysicMagnitude.Models;
using PhysicMagnitude.Models.Entities;
using PhysicMagnitude.Models.Services;

namespace PhysicMagnitude.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMagnitudeIntensityService _magnitudeIntensityService;

    public HomeController(ILogger<HomeController> logger, IMagnitudeIntensityService magnitudeIntensityService)
    {
        _logger = logger;
        _magnitudeIntensityService = magnitudeIntensityService;
    }
    
    public async Task<IActionResult> Result(Point point)
    {
        var researchData = await _magnitudeIntensityService.GetData(point.Latitude, point.Longitude);
        ViewBag.data = researchData.Datas.First();
        return View();
    }
    
    public async Task<IActionResult> Charts(Point point)
    {
        var researchDataLatitude = await _magnitudeIntensityService.GetDatasLatitude(point.Longitude);
        ViewBag.latitudes1 = researchDataLatitude.Datas.Select(x => x.Latitude);
        ViewBag.longitude = point.Longitude;
        ViewBag.intensities1 = researchDataLatitude.Datas.Select(x => x.Totalintensity);
        
        var researchDataLongitude = await _magnitudeIntensityService.GetDatasLongitude(point.Latitude);
        ViewBag.latitude = point.Latitude;
        ViewBag.longitudes2 = researchDataLongitude.Datas.Select(x => x.Longitude);
        ViewBag.intensities2 = researchDataLongitude.Datas.Select(x => x.Totalintensity);
        return View();
    }
    
    public IActionResult Home()
    {
        return View();
    }
}