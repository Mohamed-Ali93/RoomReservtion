using System.Threading.Tasks;

namespace RoomReservtion.Data
{
    public interface IRoomReservtionDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
