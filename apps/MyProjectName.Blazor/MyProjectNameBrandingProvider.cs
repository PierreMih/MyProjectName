using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace MyProjectName.Blazor;

[Dependency(ReplaceServices = true)]
public class MyProjectNameBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "MyProjectName";
}
