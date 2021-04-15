using EasyAbp.SharedResources.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace EasyAbp.SharedResources.Authorization
{
    public class SharedResourcesPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var moduleGroup = context.AddGroup(SharedResourcesPermissions.GroupName, L("Permission:SharedResources"));
            
            var categories = moduleGroup.AddPermission(SharedResourcesPermissions.Categories.Default, L("Permission:Category"));
            categories.AddChild(SharedResourcesPermissions.Categories.GlobalManage, L("Permission:GlobalManage"));
            categories.AddChild(SharedResourcesPermissions.Categories.Create, L("Permission:Create"));
            categories.AddChild(SharedResourcesPermissions.Categories.Update, L("Permission:Update"));
            categories.AddChild(SharedResourcesPermissions.Categories.Delete, L("Permission:Delete"));
            
            var resources = moduleGroup.AddPermission(SharedResourcesPermissions.Resources.Default, L("Permission:Resource"));
            resources.AddChild(SharedResourcesPermissions.Resources.GlobalManage, L("Permission:GlobalManage"));
            resources.AddChild(SharedResourcesPermissions.Resources.Create, L("Permission:Create"));
            resources.AddChild(SharedResourcesPermissions.Resources.Update, L("Permission:Update"));
            resources.AddChild(SharedResourcesPermissions.Resources.Delete, L("Permission:Delete"));
            
            var resourceUsers = moduleGroup.AddPermission(SharedResourcesPermissions.ResourceUsers.Default, L("Permission:ResourceUser"));
            resourceUsers.AddChild(SharedResourcesPermissions.ResourceUsers.GlobalManage, L("Permission:GlobalManage"));
            resourceUsers.AddChild(SharedResourcesPermissions.ResourceUsers.Create, L("Permission:Create"));
            resourceUsers.AddChild(SharedResourcesPermissions.ResourceUsers.Update, L("Permission:Update"));
            resourceUsers.AddChild(SharedResourcesPermissions.ResourceUsers.Delete, L("Permission:Delete"));
            resourceUsers.AddChild(SharedResourcesPermissions.ResourceUsers.GetExtraProperties, L("Permission:GetExtraProperties"));
            resourceUsers.AddChild(SharedResourcesPermissions.ResourceUsers.UpdateExtraProperties, L("Permission:UpdateExtraProperties"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<SharedResourcesResource>(name);
        }
    }
}