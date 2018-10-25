namespace ImageContainerConsoleApp
{
    using ImageContainer;
    using System;
    using System.Drawing;
    using System.Threading;

    public class Program
    {
        private const string WindowName = @"";
        private const string WindowNotFoundMessage = "Window not found!";
        private const string SearchedImage = @"C:\";
        private const string PathToSaveTo = @"C:\";
        public static void Main()
        {
            Test3();
        }

        private static Bitmap Test1()
        {
            var wr = new Wrapper();
            Bitmap b = wr.CaptureWindowByCoordinates(672,316,1009,736);
            //byte[] bytes = cl.GetBitmapBytes(b);
            return b;
            //b.Save(PathToSaveTo, ImageFormat.Bmp);
        }

        private static void Test2()
        {
            var wr = new Wrapper();
            Bitmap b = wr.CaptureWindowByCoordinates(717, 502, 842, 579);
            
            var r = wr.CompareImages(b, @"C:\Users\zrusev\Desktop\1.bmp", 0.95, 0.5f);
            Console.WriteLine(r);
            Console.ReadLine();
        }

        private static void Test3()
        {
            var wr = new Wrapper();
            
            wr.BringWindowToFront(@"ALPS - ( SPAIN ) UAT - \\Remote");

            Thread.Sleep(1000);
            
            wr.SendSpecialKeystrokes( new[] { "MENU", "VK_H", "VK_A" });

            Thread.Sleep(1000);

            wr.SendSpecialKeystrokes(new[] { "RETURN" });
        }

        private static void Test4()
        {
            var wr = new Wrapper();

            var screenfound = wr.BringWindowToFront(WindowName);

            if (screenfound == 0)
            {
                Console.WriteLine(WindowNotFoundMessage);
                return;
            }

            Thread.Sleep(1000);

            Bitmap b = wr.CaptureWindow(WindowName);
            //b.Save(PathToSaveTo, ImageFormat.Bmp);

            Console.WriteLine(wr.CompareImages(b, SearchedImage, 0.95, 0.5f));
        }
    }
}
