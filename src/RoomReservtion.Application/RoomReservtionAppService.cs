using System;
using System.Collections.Generic;
using System.Text;
using RoomReservtion.Localization;
using Volo.Abp.Application.Services;

namespace RoomReservtion
{
    /* Inherit your application services from this class.
     */
    public abstract class RoomReservtionAppService : ApplicationService
    {
        protected RoomReservtionAppService()
        {
            LocalizationResource = typeof(RoomReservtionResource);
        }
    }
}
