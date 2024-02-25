using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace MyProjectName.Projects.EntityFrameworkCore;

[ConnectionStringName(ProjectsDbProperties.ConnectionStringName)]
public interface IProjectsDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}