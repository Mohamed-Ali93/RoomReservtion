using RoomReservtion.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace RoomReservtion.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class RoomReservtionController : AbpController
    {
        protected RoomReservtionController()
        {
            LocalizationResource = typeof(RoomReservtionResource);
        }
    }
}