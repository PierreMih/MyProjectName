using MyProjectName.Administration.EntityFrameworkCore;
using MyProjectName.Hosting.Shared;
using Volo.Abp.Modularity;

namespace MyProjectName.Microservice.Shared;

[DependsOn(
    typeof(MyProjectNameHostingModule),
    typeof(AdministrationEntityFrameworkCoreModule)
)]
public class MyProjectNameMicroserviceModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
    }
}