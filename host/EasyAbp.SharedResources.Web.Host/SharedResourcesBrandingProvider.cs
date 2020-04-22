using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.SharedResources
{
    [Dependency(ReplaceServices = true)]
    public class SharedResourcesBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "SharedResources";
    }
}
