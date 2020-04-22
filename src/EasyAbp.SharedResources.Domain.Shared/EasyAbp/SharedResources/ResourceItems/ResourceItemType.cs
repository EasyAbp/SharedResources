using System;

namespace EasyAbp.SharedResources.ResourceItems
{
    [Flags]
    public enum ResourceItemType
    {
        Article = 1,
        Video = 2,
        Audio = 4,
        Picture = 8,
        File = 16
    }
}