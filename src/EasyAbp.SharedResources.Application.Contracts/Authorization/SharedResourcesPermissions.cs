using Volo.Abp.Reflection;

namespace EasyAbp.SharedResources.Authorization
{
    public class SharedResourcesPermissions
    {
        public const string GroupName = "SharedResources";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(SharedResourcesPermissions));
        }
    }
}