namespace ImageContainer
{
    using AForge.Imaging;
    using Enums;
    using Structs;
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Runtime.InteropServices;

    internal class ScreenCapture
    {
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string className, string windowTitle);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowPlacement(IntPtr hWnd, ref WindowPlacement lpwndpl);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowWindow(IntPtr hWnd, ShowWindowEnum flags);

        [DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hwnd);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);


        /// <summary>
        /// Capture the active window
        /// </summary>
        /// <returns>Bitmap image</returns>
        public static Bitmap CaptureDesktop() => CaptureWindowByHandle(GetDesktopWindow());        


        /// <summary>
        /// Capture the window in front
        /// </summary>
        /// <returns>Bitmap image</returns>
        public static Bitmap CaptureActiveWindow() => CaptureWindowByHandle(GetForegroundWindow());
       

        /// <summary>
        /// Capture the searched window
        /// </summary>
        /// <param name="name">String process name</param>
        /// <returns>Bitmap image</returns>
        public static Bitmap CaptureWindow(string name)
        {
            IntPtr handle = FindWindow(null, name);

            return CaptureWindowByHandle(handle);
        }


        /// <summary>
        /// Extended method of CaptureWindow(string name)
        /// </summary>
        /// <param name="name">IntPtr handle</param>
        /// <returns>Bitmap image</returns>
        private static Bitmap CaptureWindowByHandle(IntPtr handle)
        {
            var rect = new Rect();
            GetWindowRect(handle, ref rect);
            var bounds = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
            var result = new Bitmap(bounds.Width, bounds.Height);

            using (var graphics = Graphics.FromImage(result))
            {
                graphics.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
            }

            return result;
        }


        /// <summary>
        /// Bring to front the searched window
        /// </summary>
        /// <param name="name">String process name</param>
        /// <returns>Integer</returns>
        public static int BringWindowToFront(string name)
        {
            IntPtr wdwIntPtr = FindWindow(null, name);

            if ((int)wdwIntPtr == 0)
            {
                return 0;
            }

            if (wdwIntPtr == GetForegroundWindow())
            {
                return 1;
            }

            WindowPlacement placement = new WindowPlacement();
            GetWindowPlacement(wdwIntPtr, ref placement);

            if (placement.showCmd != (int)CmdEnum.SW_SHOWMAXIMIZED)
            {
                ShowWindow(wdwIntPtr, ShowWindowEnum.Restore);
                ShowWindow(wdwIntPtr, ShowWindowEnum.Show);
            }

            SetForegroundWindow(wdwIntPtr);

            return 1;
        }


        /// <summary>
        /// Capture window by coordinates(Rect rectangle)
        /// </summary>
        /// <param name="name">Rect rectangle</param>
        /// <returns>Bitmap image</returns>
        public static Bitmap CaptureWindowByCoordinates(Rect rectangle)
        {
            var rect = rectangle;
            var bounds = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
            var result = new Bitmap(bounds.Width, bounds.Height);

            using (var graphics = Graphics.FromImage(result))
            {
                graphics.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
            }

            return result;
        }


        /// <summary>
        /// Gets bytes from a bitmap image(Bitmap image)
        /// </summary>
        /// <param name="name">Bitmap image</param>
        /// <returns>Byte array</returns>
        public static byte[] GetBitmapBytes(Bitmap image)
        {
            ImageConverter converter = new ImageConverter();
            var bytes = (byte[])converter.ConvertTo(image, typeof(byte[]));

            return bytes;
        }


        /// <summary>
        /// Compares the images.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="targetImage">The target image.</param>
        /// <param name="compareLevel">The compare level.</param>
        /// <param name="filepath">The filepath.</param>
        /// <param name="similarityThreshold">The similarity threshold.</param>
        /// <returns>Boolean result</returns>
        public static bool CompareImages(Bitmap image, string targetImage, double compareLevel, float similarityThreshold, string filepath)
        {
            // Load images into bitmaps
            var imageOne = image;
            var imageTwo = new Bitmap(targetImage);

            var newBitmap1 = ChangePixelFormat(new Bitmap(imageOne), PixelFormat.Format24bppRgb);
            var newBitmap2 = ChangePixelFormat(new Bitmap(imageTwo), PixelFormat.Format24bppRgb);

            //newBitmap1 = SaveBitmapToFile(newBitmap1, filepath, image, ".bmp");
            //newBitmap2 = SaveBitmapToFile(newBitmap2, filepath, targetImage, ".bmp");

            // Setup the AForge library
            var tm = new ExhaustiveTemplateMatching(similarityThreshold);

            // Process the images
            var results = tm.ProcessImage(newBitmap1, newBitmap2);

            // Compare the results, 0 indicates no match so return false
            if (results.Length <= 0)
            {
                return false;
            }

            // Return true if similarity score is equal or greater than the comparison level
            var match = results[0].Similarity >= compareLevel;

            return match;
        }


        /// <summary>
        /// Saves the bitmap automatic file.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="filepath">The filepath.</param>
        /// <param name="name">The name.</param>
        /// <param name="extension">The extension.</param>
        /// <returns>Bitmap image</returns>
        private static Bitmap SaveBitmapToFile(Bitmap image, string filepath, string name, string extension)
        {
            var savePath = string.Concat(filepath, "\\", Path.GetFileNameWithoutExtension(name), extension);

            image.Save(savePath, ImageFormat.Bmp);

            return image;
        }


        /// <summary>
        /// Change the pixel format of the bitmap image
        /// </summary>
        /// <param name="inputImage">Bitmapped image</param>
        /// <param name="newFormat">Bitmap format - 24bpp</param>
        /// <returns>Bitmap image</returns>
        private static Bitmap ChangePixelFormat(Bitmap inputImage, PixelFormat newFormat)
            => inputImage.Clone(new Rectangle(0, 0, inputImage.Width, inputImage.Height), newFormat);
    }
}