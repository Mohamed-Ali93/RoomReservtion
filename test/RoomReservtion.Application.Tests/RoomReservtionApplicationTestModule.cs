using Volo.Abp.Modularity;

namespace RoomReservtion
{
    [DependsOn(
        typeof(RoomReservtionApplicationModule),
        typeof(RoomReservtionDomainTestModule)
        )]
    public class RoomReservtionApplicationTestModule : AbpModule
    {

    }
}