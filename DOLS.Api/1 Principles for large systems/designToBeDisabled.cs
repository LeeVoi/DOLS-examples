using System;
using Microsoft.AspNetCore.Mvc;

namespace DOLS.Api._1_Principles_for_large_systems;

// This class demonstrates a simple API controller that checks if a feature flag is enabled.


[ApiController] 
[Route("api/[controller]")] 
public class FeatureController : ControllerBase
{
    private readonly IFeatureService _featureService; // Abstraction for checking feature‐flag status

    public FeatureController(IFeatureService featureService)
    {
        _featureService = featureService; 
    }

    [HttpGet]
    public async Task<IActionResult> GetFeatureFlagAsync(
        [FromQuery] string featureName 
    )
    {
        // Ask the service if the named feature is enabled
        bool isEnabled = await _featureService.GetFeatureFlagAsync(featureName);

        // If enabled, return 200 OK with "true"; else return 404 Not Found with a message
        return isEnabled
            ? Ok(isEnabled)
            : NotFound($"Feature '{featureName}' is not enabled.");
    }
}

