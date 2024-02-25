using Volo.Abp.Modularity;

namespace MyProjectName.SaaS;

[DependsOn(
    typeof(SaaSApplicationModule),
    typeof(SaaSDomainTestModule)
    )]
public class SaaSApplicationTestModule : AbpModule
{

}
