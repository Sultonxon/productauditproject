

namespace ProductsProject.Services;

public class ConfigurationService: IConfigurationService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ConfigurationService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetCurrentUserId() =>
        _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
}
