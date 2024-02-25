using MyProjectName.Administration;
using MyProjectName.Administration.EntityFrameworkCore;
using MyProjectName.IdentityService;
using MyProjectName.IdentityService.EntityFrameworkCore;
using MyProjectName.Microservice.Shared;
using MyProjectName.SaaS;
using MyProjectName.SaaS.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace MyProjectName.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AdministrationEntityFrameworkCoreModule),
    typeof(AdministrationApplicationContractsModule),
    typeof(IdentityServiceEntityFrameworkCoreModule),
    typeof(IdentityServiceApplicationContractsModule),
    typeof(SaaSEntityFrameworkCoreModule),
    typeof(SaaSApplicationContractsModule)
)]
public class MyProjectNameDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        //Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}