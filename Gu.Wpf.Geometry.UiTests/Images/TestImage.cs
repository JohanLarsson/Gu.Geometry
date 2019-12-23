namespace Gu.Wpf.Geometry.UiTests
{
    using System.Drawing;
    using System.IO;
    using Gu.Wpf.UiAutomation;
    using NUnit.Framework;

    internal static class TestImage
    {
        internal static readonly string Current = GetCurrent();

        [Script]
        public static void Rename()
        {
            var folder = @"C:\Git\_GuOrg\Gu.Wpf.Adorners\Gu.Wpf.Adorners.UiTests";
            var oldName = "Red_border_default_visibility_width_100.png";
            var newName = "Red_border_default_visibility_width_100.png";

            foreach (var file in Directory.EnumerateFiles(folder, oldName, SearchOption.AllDirectories))
            {
                File.Move(file, file.Replace(oldName, newName));
            }

            foreach (var file in Directory.EnumerateFiles(folder, "*.cs", SearchOption.AllDirectories))
            {
                File.WriteAllText(file, File.ReadAllText(file).Replace(oldName, newName));
            }
        }

        internal static void OnFail(Bitmap? expected, Bitmap actual, string resource)
        {
            var fullFileName = Path.Combine(Path.GetTempPath(), resource);
            _ = Directory.CreateDirectory(Path.GetDirectoryName(fullFileName));
            actual.Save(fullFileName);
            TestContext.AddTestAttachment(fullFileName);
        }

        private static string GetCurrent()
        {
            if (WindowsVersion.IsWindows7())
            {
                return "Win7";
            }

            if (WindowsVersion.IsWindows10())
            {
                return "Win10";
            }

            if (WindowsVersion.CurrentContains("Windows Server 2019"))
            {
                return "WinServer2019";
            }

            return WindowsVersion.CurrentVersionProductName;
        }

        [System.Diagnostics.Conditional("DEBUG")]
        public class ScriptAttribute : TestAttribute
        {
        }
    }
}