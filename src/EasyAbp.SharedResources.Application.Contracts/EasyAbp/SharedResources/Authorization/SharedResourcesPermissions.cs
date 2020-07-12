using Volo.Abp.Reflection;

namespace EasyAbp.SharedResources.Authorization
{
    public class SharedResourcesPermissions
    {
        public const string GroupName = "EasyAbp.SharedResources";

        public class Categories
        {
            public const string Default = GroupName + ".Category";
            public const string GlobalManage = Default + ".GlobalManage";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
        }
        
        public class Resources
        {
            public const string Default = GroupName + ".Resource";
            public const string GlobalManage = Default + ".GlobalManage";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
        }
        
        public class ResourceUsers
        {
            public const string Default = GroupName + ".ResourceUser";
            public const string GlobalManage = Default + ".GlobalManage";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
        }
        
        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(SharedResourcesPermissions));
        }
    }
}