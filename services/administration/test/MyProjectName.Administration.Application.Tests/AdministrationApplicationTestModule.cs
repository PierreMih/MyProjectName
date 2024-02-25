using Volo.Abp.Modularity;

namespace MyProjectName.Administration;

[DependsOn(
    typeof(AdministrationApplicationModule),
    typeof(AdministrationDomainTestModule)
    )]
public class AdministrationApplicationTestModule : AbpModule
{

}
