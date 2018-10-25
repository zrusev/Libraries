namespace ImageContainer
{
    using Structs;
    using System.Drawing;

    public class Wrapper
    {
        /// <summary>
        /// Compares the images.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="targetImage">The target image.</param>
        /// <param name="compareLevel">The compare level.</param>
        /// <param name="filepath">The filepath.</param>
        /// <param name="similarityThreshold">The similarity threshold.</param>
        /// <returns>Boolean result</returns>
        public bool CompareImages(Bitmap image, string targetImage, double compareLevel, float similarityThreshold, string filepath = @"C:\")
            => ScreenCapture.CompareImages(image, targetImage, compareLevel, similarityThreshold, filepath);


        /// <summary>
        /// ScreenCapture wrapped CaptureDesktop() method
        /// </summary>
        public Bitmap CaptureDesktop() => ScreenCapture.CaptureDesktop();


        /// <summary>
        /// ScreenCapture wrapped CaptureActiveWindow() method
        /// </summary>
        public Bitmap CaptureActiveWindow() => ScreenCapture.CaptureActiveWindow();


        /// <summary>
        /// ScreenCapture wrapped CaptureWindow() method
        /// <param name="name">String process name</param>
        /// </summary>
        public Bitmap CaptureWindow(string name) => ScreenCapture.CaptureWindow(name);


        /// <summary>
        /// ScreenCapture wrapped BringWindowToFront() method
        /// <param name="name">String process name</param>
        /// </summary>
        public int BringWindowToFront(string name) => ScreenCapture.BringWindowToFront(name);


        /// <summary>
        /// Capture window by coordinates(Rect rectangle)
        /// </summary>
        /// <param name="name">Rect rectangle</param>
        /// <returns>Bitmap image</returns>
        public Bitmap CaptureWindowByCoordinates(int left, int top, int right, int bottom)
            => ScreenCapture.CaptureWindowByCoordinates(new Rect() { Left = left, Top = top, Right = right, Bottom = bottom });        


        /// <summary>
        /// Gets bytes from a bitmap image(Bitmap image)
        /// </summary>
        /// <param name="name">Bitmap image</param>
        /// <returns>Byte array</returns>
        public byte[] GetBitmapBytes(Bitmap image) => ScreenCapture.GetBitmapBytes(image);


        /// <summary>
        /// Send keyboard text(string textEntry)
        /// </summary>
        /// <param name="textEntry">string textEntry</param>
        /// <returns>void</returns>
        public void SendText(string textEntry) => Simulator.SendText(textEntry);


        /// <summary>
        /// Send char array(string textEntry)
        /// </summary>
        /// <param name="textEntry">string textEntry</param>
        /// <returns>void</returns>
        public void SendTextByChars(string textEntry) => Simulator.SendTextByChars(textEntry);


        /// <summary>
        /// Send key(string textEntry)
        /// </summary>
        /// <param name="textEntry">string textEntry</param>
        /// <returns>void</returns>
        public void SendKey(string textEntry) => Simulator.SendKey(textEntry);


        /// <summary>
        /// Send keyboard combination(string key, string[] keysEntry)
        /// </summary>
        /// <param name="key">string key</param>
        /// <param name="keysEntry">string[] keysEntry</param>
        /// <returns>void</returns>
        public void SendKeystrokes(string key, string[] keysEntry) => Simulator.SendKeystrokes(key, keysEntry);


        /// <summary>
        /// Send special keys to virtual machine(string[] keysEntry)
        /// </summary>
        /// <param name="keysEntry">string[] keysEntry</param>
        /// <returns>void</returns>
        public void SendSpecialKeystrokes(string[] keysEntry) => VirtualInput.SendKeystrokes(keysEntry);


        /// <summary>
        /// Left mouse click
        /// </summary>
        /// <returns>void</returns>
        public void SendLeftButtonClick() => Simulator.SendLeftButtonClick();


        /// <summary>
        /// Double left mouse click
        /// </summary>
        /// <returns>void</returns>
        public void SendLeftButtonDoubleClick() => Simulator.SendLeftButtonDoubleClick();


        /// <summary>
        /// Right mouse click
        /// </summary>
        /// <returns>void</returns>
        public void SendRightButtonClick() => Simulator.SendRightButtonClick();


        /// <summary>
        /// Double right mouse click
        /// </summary>
        /// <returns>void</returns>
        public void SendRightButtonDoubleClick() => Simulator.SendRightButtonDoubleClick();
    }
}