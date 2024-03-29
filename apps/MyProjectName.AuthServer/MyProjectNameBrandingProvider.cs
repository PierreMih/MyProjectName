﻿using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace MyProjectName;

[Dependency(ReplaceServices = true)]
public class MyProjectNameBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "MyProjectName";
}
