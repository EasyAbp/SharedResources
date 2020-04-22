using EasyAbp.SharedResources.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace EasyAbp.SharedResources.Authorization
{
    public class SharedResourcesPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            //var moduleGroup = context.AddGroup(SharedResourcesPermissions.GroupName, L("Permission:SharedResources"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<SharedResourcesResource>(name);
        }
    }
}