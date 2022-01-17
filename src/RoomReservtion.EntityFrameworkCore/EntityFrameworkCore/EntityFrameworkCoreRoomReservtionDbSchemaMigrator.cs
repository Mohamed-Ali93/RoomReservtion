using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RoomReservtion.Data;
using Volo.Abp.DependencyInjection;

namespace RoomReservtion.EntityFrameworkCore
{
    public class EntityFrameworkCoreRoomReservtionDbSchemaMigrator
        : IRoomReservtionDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreRoomReservtionDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the RoomReservtionDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<RoomReservtionDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
