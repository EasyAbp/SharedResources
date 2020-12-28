using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace EasyAbp.SharedResources
{
    [Dependency(ReplaceServices = true)]
    public class SharedResourcesBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "SharedResources";
    }
}
