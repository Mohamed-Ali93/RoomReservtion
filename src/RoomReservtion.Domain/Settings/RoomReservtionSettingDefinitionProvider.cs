using Volo.Abp.Settings;

namespace RoomReservtion.Settings
{
    public class RoomReservtionSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(RoomReservtionSettings.MySetting1));
        }
    }
}
