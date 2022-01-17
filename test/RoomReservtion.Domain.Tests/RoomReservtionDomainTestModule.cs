using RoomReservtion.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace RoomReservtion
{
    [DependsOn(
        typeof(RoomReservtionEntityFrameworkCoreTestModule)
        )]
    public class RoomReservtionDomainTestModule : AbpModule
    {

    }
}