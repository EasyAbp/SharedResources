using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.SharedResources.Authorization;
using EasyAbp.SharedResources.Localization;
using Volo.Abp.UI.Navigation;

namespace EasyAbp.SharedResources.Web.Menus
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

            var sharedResourcesMenuItem = new ApplicationMenuItem(SharedResourcesMenus.Prefix,
                l["Menu:SharedResources"], icon: "fa fa-share-alt-square");

            if (await context.IsGrantedAsync(SharedResourcesPermissions.Categories.Default))
            {
                sharedResourcesMenuItem.AddItem(
                    new ApplicationMenuItem(SharedResourcesMenus.Category, l["Menu:Category"], "/SharedResources/Categories/Category")
                );
            }
            
            if (!sharedResourcesMenuItem.Items.IsNullOrEmpty())
            {
                context.Menu.GetAdministration().Items.Add(sharedResourcesMenuItem);
            }
        }
    }
}
