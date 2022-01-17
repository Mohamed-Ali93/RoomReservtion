﻿using RoomReservtion.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace RoomReservtion.Permissions
{
    public class RoomReservtionPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(RoomReservtionPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(RoomReservtionPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<RoomReservtionResource>(name);
        }
    }
}
