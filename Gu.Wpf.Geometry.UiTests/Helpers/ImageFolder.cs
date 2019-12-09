namespace Gu.Wpf.Geometry.UiTests
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Text.RegularExpressions;
    using Gu.Wpf.UiAutomation;
    using NUnit.Framework;

    internal static class ImageFolder
    {
        internal static readonly string Current = GetCurrent();

        internal static void AddAttachment(Exception exception, Bitmap bitmap)
        {
            var match = Regex.Match(exception.Message, "Did not find a file nor resource named (?<path>[^\n]+)");
            if (match.Success)
            {
                var fileName = Path.Combine(Path.GetTempPath(), match.Groups["path"].Value);
                Directory.CreateDirectory(Path.GetDirectoryName(fileName));
                bitmap.Save(fileName);
                TestContext.AddTestAttachment(fileName);
            }
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
    }
}