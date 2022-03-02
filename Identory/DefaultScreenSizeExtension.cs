using Identory.Models.Enum;

namespace Identory
{
    public static class DefaultScreenSizeExtension
    {
        public static int Width(this DefaultDesktopScreenSize screenSize)
        {
            switch (screenSize)
            {
                case DefaultDesktopScreenSize.Size_1024x768: return 1024;
                case DefaultDesktopScreenSize.Size_1280x720: return 1280;
                case DefaultDesktopScreenSize.Size_1280x800: return 1280;
                case DefaultDesktopScreenSize.Size_1280x1024: return 1280;
                case DefaultDesktopScreenSize.Size_1360x768: return 1360;
                case DefaultDesktopScreenSize.Size_1366x768: return 1366;
                case DefaultDesktopScreenSize.Size_1440x900: return 1440;
                case DefaultDesktopScreenSize.Size_1536x864: return 1536;
                case DefaultDesktopScreenSize.Size_1600x900: return 1600;
                case DefaultDesktopScreenSize.Size_1680x1050: return 1680;
                case DefaultDesktopScreenSize.Size_1920x1080: return 1920;
                case DefaultDesktopScreenSize.Size_1920x1200: return 1920;
                case DefaultDesktopScreenSize.Size_2048x1152: return 2048;
                case DefaultDesktopScreenSize.Size_2560x1080: return 2560;
                case DefaultDesktopScreenSize.Size_2560x1440: return 2560;
                case DefaultDesktopScreenSize.Size_3440x1440: return 3440;
                case DefaultDesktopScreenSize.Size_3840x2160: return 3840;
                default: return 800;
            }
        }

        public static int Height(this DefaultDesktopScreenSize screenSize)
        {
            switch (screenSize)
            {
                case DefaultDesktopScreenSize.Size_1024x768: return 768;
                case DefaultDesktopScreenSize.Size_1280x720: return 720;
                case DefaultDesktopScreenSize.Size_1280x800: return 800;
                case DefaultDesktopScreenSize.Size_1280x1024: return 1024;
                case DefaultDesktopScreenSize.Size_1360x768: return 768;
                case DefaultDesktopScreenSize.Size_1366x768: return 768;
                case DefaultDesktopScreenSize.Size_1440x900: return 900;
                case DefaultDesktopScreenSize.Size_1536x864: return 864;
                case DefaultDesktopScreenSize.Size_1600x900: return 900;
                case DefaultDesktopScreenSize.Size_1680x1050: return 1050;
                case DefaultDesktopScreenSize.Size_1920x1080: return 1080;
                case DefaultDesktopScreenSize.Size_1920x1200: return 1200;
                case DefaultDesktopScreenSize.Size_2048x1152: return 1152;
                case DefaultDesktopScreenSize.Size_2560x1080: return 1080;
                case DefaultDesktopScreenSize.Size_2560x1440: return 1440;
                case DefaultDesktopScreenSize.Size_3440x1440: return 1440;
                case DefaultDesktopScreenSize.Size_3840x2160: return 2160;
                default: return 800;
            }
        }
    }
}
