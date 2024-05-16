using Microsoft.AspNetCore.Razor.TagHelpers;

namespace PhysicMagnitude.Models.Entities;

public class Point
{
    [HtmlAttributeName("Longitude")]
    public decimal Longitude { get; set; }
    [HtmlAttributeName("Latitude")]
    public decimal Latitude { get; set; }
}