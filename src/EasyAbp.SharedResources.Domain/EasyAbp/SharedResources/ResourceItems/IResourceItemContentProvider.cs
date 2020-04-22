using System.Threading.Tasks;

namespace EasyAbp.SharedResources.ResourceItems
{
    public interface IResourceItemContentConverter
    {
        Task<string> GetConvertedContentAsync(string originalContent);
    }
}