using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace RoomReservtion.Data
{
    /* This is used if database provider does't define
     * IRoomReservtionDbSchemaMigrator implementation.
     */
    public class NullRoomReservtionDbSchemaMigrator : IRoomReservtionDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}