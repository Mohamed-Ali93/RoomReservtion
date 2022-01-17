using RoomReservtion.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace RoomReservtion.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(RoomReservtionEntityFrameworkCoreModule),
        typeof(RoomReservtionApplicationContractsModule)
        )]
    public class RoomReservtionDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
