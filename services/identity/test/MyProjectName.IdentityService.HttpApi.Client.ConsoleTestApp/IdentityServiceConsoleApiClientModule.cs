﻿using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace MyProjectName.IdentityService;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(IdentityServiceHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class IdentityServiceConsoleApiClientModule : AbpModule
{

}
