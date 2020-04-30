namespace EasyAbp.SharedResources.Resources
{
    public class ResourceAuthorizationQueryModel
    {
        public Resource Resource { get; set; }
        
        public bool IsAuthorized { get; set; }
    }
}