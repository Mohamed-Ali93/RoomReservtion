using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace RoomReservtion
{
    [Dependency(ReplaceServices = true)]
    public class RoomReservtionBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "RoomReservtion";
    }
}
