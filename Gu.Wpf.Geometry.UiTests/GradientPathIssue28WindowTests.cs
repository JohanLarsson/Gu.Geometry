namespace Gu.Wpf.Geometry.UiTests
{
    using Gu.Wpf.UiAutomation;
    using NUnit.Framework;

    public static class GradientPathIssue28WindowTests
    {
        private const string WindowName = "GradientPathIssue28Window";

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            ImageAssert.OnFail = OnFail.SaveImageToTemp;
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            Application.KillLaunched("Gu.Wpf.Geometry.Demo.exe");
        }

        [Test]
        public static void ArcSegmentIssue28()
        {
            using var app = Application.Launch("Gu.Wpf.Geometry.Demo.exe", WindowName);
            var window = app.MainWindow;
            ImageAssert.AreEqual($"Images\\GradientPathIssue28Window\\{ImageFolder.Current}\\ArcSegment.png", window.FindGroupBox("Path"), ImageFolder.AddAttachment);
        }
    }
}