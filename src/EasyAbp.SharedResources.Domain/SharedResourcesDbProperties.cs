namespace EasyAbp.SharedResources
{
    public static class SharedResourcesDbProperties
    {
        public static string DbTablePrefix { get; set; } = "SharedResources";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "SharedResources";
    }
}
