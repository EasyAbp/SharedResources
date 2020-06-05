using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.SharedResources.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using EasyAbp.SharedResources.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using EasyAbp.SharedResources.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using EasyAbp.SharedResources.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using EasyAbp.SharedResources.Localization;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.UI.Navigation;

namespace EasyAbp.SharedResources.Web
{
    public class SharedResourcesMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenu(context);
            }
        }

        private async Task ConfigureMainMenu(MenuConfigurationContext context)
        {
            var l = context.GetLocalizer<SharedResourcesResource>();            //Add main menu items.

            var sharedResourcesMenuItem = new ApplicationMenuItem("SharedResources", l["Menu:SharedResources"]);

            if (await context.IsGrantedAsync(SharedResourcesPermissions.Categories.Default))
            {
                sharedResourcesMenuItem.AddItem(
                    new ApplicationMenuItem("Category", l["Menu:Category"], "/SharedResources/Categories/Category")
                );
            }
            
            if (!sharedResourcesMenuItem.Items.IsNullOrEmpty())
            {
                context.Menu.Items.Add(sharedResourcesMenuItem);
            }
        }
    }
}
