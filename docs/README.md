# SharedResources

[![ABP version](https://img.shields.io/badge/dynamic/xml?style=flat-square&color=yellow&label=abp&query=%2F%2FProject%2FPropertyGroup%2FAbpVersion&url=https%3A%2F%2Fraw.githubusercontent.com%2FEasyAbp%2FSharedResources%2Fmaster%2FDirectory.Build.props)](https://abp.io)
[![NuGet](https://img.shields.io/nuget/v/EasyAbp.SharedResources.Domain.Shared.svg?style=flat-square)](https://www.nuget.org/packages/EasyAbp.SharedResources.Domain.Shared)
[![NuGet Download](https://img.shields.io/nuget/dt/EasyAbp.SharedResources.Domain.Shared.svg?style=flat-square)](https://www.nuget.org/packages/EasyAbp.SharedResources.Domain.Shared)
[![Discord online](https://badgen.net/discord/online-members/S6QaezrCRq?label=Discord)](https://discord.gg/S6QaezrCRq)
[![GitHub stars](https://img.shields.io/github/stars/EasyAbp/SharedResources?style=social)](https://www.github.com/EasyAbp/SharedResources)

An abp application module that allows users to share resources with each other.

## Online Demo

We have launched an online demo for this module: [https://sharedres.samples.easyabp.io](https://sharedres.samples.easyabp.io)

## Installation

1. Install the following NuGet packages. ([see how](https://github.com/EasyAbp/EasyAbpGuide/blob/master/docs/How-To.md#add-nuget-packages))

    * EasyAbp.SharedResources.Application
    * EasyAbp.SharedResources.Application.Contracts
    * EasyAbp.SharedResources.Domain
    * EasyAbp.SharedResources.Domain.Shared
    * EasyAbp.SharedResources.EntityFrameworkCore
    * EasyAbp.SharedResources.HttpApi
    * EasyAbp.SharedResources.HttpApi.Client
    * (Optional) EasyAbp.SharedResources.MongoDB
    * (Optional) EasyAbp.SharedResources.Web

1. Add `DependsOn(typeof(SharedResourcesXxxModule))` attribute to configure the module dependencies. ([see how](https://github.com/EasyAbp/EasyAbpGuide/blob/master/docs/How-To.md#add-module-dependencies))

1. Add `builder.ConfigureSharedResources();` to the `OnModelCreating()` method in **MyProjectMigrationsDbContext.cs**.

1. Add EF Core migrations and update your database. See: [ABP document](https://docs.abp.io/en/abp/latest/Tutorials/Part-1?UI=MVC&DB=EF#add-database-migration).

## Usage

1. Add permissions to the roles you want.

1. Create a category.

1. Create a resource in the category.

1. Create a resource item in the resource.

1. Set authorized users of the resource so they can access it.

![Categories](/docs/images/Categories.png)
![CreateCategory](/docs/images/CreateCategory.png)
![Resources](/docs/images/Resources.png)
![CreateResource](/docs/images/CreateResource.png)
![ResourceItems](/docs/images/ResourceItems.png)
![CreateResourceItem](/docs/images/CreateResourceItem.png)

## Application Scenario

### Video Sharing Sites

* Enable users to create their own categories and resources.
* Enable users to decide who has access to resources.

### Free Download Sites

* Add categories with the `Set as a common category` configuration.
* Add resource items with the `Public resource item` configuration.

### Paid Knowledge Market

* Add categories with the `Set as a common category` configuration.
* Set the free part of resource items to `Public resource item`.
* Use [EShop](https://github.com/EasyAbp/EShop) module to sell your courses, when a user buys a course, give him access to related resources.

## Roadmap

- [ ] Explorer.
- [ ] Pages for admin to manage users' categories and resources.
- [ ] Unit tests.
