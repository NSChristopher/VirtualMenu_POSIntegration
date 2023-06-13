namespace VirtualMenu.LingaAPI
{
    public class ApiEndpoints
    {
        public const string BaseAddress = "https://api.lingaros.com/v1/lingapos/";
        //format with storId
        public const string GetMenuItems = "store/{0}/menuItems";
        //format with menuItemId
        public const string GetMenuItem = "menuItem/{0}";
    }
}
