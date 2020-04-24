using EasyAbp.SharedResources.CategoryOwners;
using EasyAbp.SharedResources.ResourceUsers;
using EasyAbp.SharedResources.ResourceItems;
using EasyAbp.SharedResources.Resources;
using EasyAbp.SharedResources.Categories;
using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace EasyAbp.SharedResources.EntityFrameworkCore
{
    public static class SharedResourcesDbContextModelCreatingExtensions
    {
        public static void ConfigureSharedResources(
            this ModelBuilder builder,
            Action<SharedResourcesModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new SharedResourcesModelBuilderConfigurationOptions(
                SharedResourcesDbProperties.DbTablePrefix,
                SharedResourcesDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            /* Configure all entities here. Example:

            builder.Entity<Question>(b =>
            {
                //Configure table & schema name
                b.ToTable(options.TablePrefix + "Questions", options.Schema);
            
                b.ConfigureByConvention();
            
                //Properties
                b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);
                
                //Relations
                b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

                //Indexes
                b.HasIndex(q => q.CreationTime);
            });
            */

            builder.Entity<Category>(b =>
            {
                b.ToTable(options.TablePrefix + "Categories", options.Schema);
                b.ConfigureByConvention(); 
                /* Configure more properties here */
            });

            builder.Entity<Resource>(b =>
            {
                b.ToTable(options.TablePrefix + "Resources", options.Schema);
                b.ConfigureByConvention(); 
                /* Configure more properties here */
            });

            builder.Entity<ResourceItem>(b =>
            {
                b.ToTable(options.TablePrefix + "ResourceItems", options.Schema);
                b.ConfigureByConvention(); 
                /* Configure more properties here */
            });

            builder.Entity<ResourceUser>(b =>
            {
                b.ToTable(options.TablePrefix + "ResourceUsers", options.Schema);
                b.ConfigureByConvention(); 
                /* Configure more properties here */
            });

            builder.Entity<ResourceItemContent>(b =>
            {
                b.ToTable(options.TablePrefix + "ResourceItemContents", options.Schema);
                b.ConfigureByConvention(); 
                /* Configure more properties here */
                b.HasKey(x => x.ResourceItemId);
            });

            builder.Entity<CategoryOwner>(b =>
            {
                b.ToTable(options.TablePrefix + "CategoryOwners", options.Schema);
                b.ConfigureByConvention(); 
                /* Configure more properties here */
            });
        }
    }
}
