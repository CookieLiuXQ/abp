﻿using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.Users;
using Volo.Abp.VirtualFileSystem;

namespace Volo.Abp.Identity
{
    [DependsOn(
        typeof(AbpIdentityDomainSharedModule),
        typeof(AbpUsersAbstractionModule),
        typeof(AbpAuthorizationModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpPermissionManagementApplicationContractsModule)
        )]
    public class AbpIdentityApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<PermissionOptions>(options =>
            {
                options.DefinitionProviders.Add<IdentityPermissionDefinitionProvider>();
            });

            Configure<VirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpIdentityApplicationContractsModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<IdentityResource>()
                    .AddVirtualJson("/Volo/Abp/Identity/Localization/ApplicationContracts");
            });
        }
    }
}