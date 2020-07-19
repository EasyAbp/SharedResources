﻿using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.Authorization;

namespace EasyAbp.SharedResources
{
    [DependsOn(
        typeof(SharedResourcesDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class SharedResourcesApplicationContractsModule : AbpModule
    {

    }
}
