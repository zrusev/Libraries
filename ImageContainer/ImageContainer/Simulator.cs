namespace ImageContainer
{
    using System;
    using System.Collections.Generic;
    using WindowsInput;
    using WindowsInput.Native;

    internal static class Simulator
    {
        /// <summary>
        /// Send keyboard text(string textEntry)
        /// </summary>
        /// <param name="textEntry">string textEntry</param>
        /// <returns>void</returns>
        public static void SendText(string textEntry)
        {
            var sim = new InputSimulator();
            sim.Keyboard.Sleep(1000).TextEntry(textEntry).Sleep(1000);
        }


        /// <summary>
        /// Send char array(string textEntry)
        /// </summary>
        /// <param name="textEntry">string textEntry</param>
        /// <returns>void</returns>
        public static void SendTextByChars(string textEntry)
        {
            var sim = new InputSimulator();

            string[] lines = textEntry.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            foreach (string line in lines)
            {
                char[] words = line.ToCharArray();

                foreach (char word in words)
                {
                    sim.Keyboard.TextEntry(word).Sleep(500);
                }
            }
        }


        /// <summary>
        /// Send key(string textEntry)
        /// </summary>
        /// <param name="textEntry">string textEntry</param>
        /// <returns>void</returns>
        public static void SendKey(string textEntry)
        {
            var vk = (VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), textEntry);

            var sim = new InputSimulator();
            sim.Keyboard.KeyPress(vk).Sleep(1000);
        }


        /// <summary>
        /// Send keyboard combination(string key, string[] keysEntry)
        /// </summary>
        /// <param name="key">string key</param>
        /// <param name="keysEntry">string[] keysEntry</param>
        /// <returns>void</returns>
        public static void SendKeystrokes(string key, string[] keysEntry)
        {
            var vk = (VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), key);

            var commandList = new List<VirtualKeyCode>();

            foreach (var entry in keysEntry)
            {
                commandList.Add((VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), entry));
            }

            var sim = new InputSimulator();
            sim.Keyboard.ModifiedKeyStroke(vk, commandList).Sleep(1000);
        }


        /// <summary>
        /// Left mouse click
        /// </summary>
        /// <returns>void</returns>
        public static void SendLeftButtonClick() {
            var sim = new InputSimulator();
            sim.Mouse.LeftButtonClick().Sleep(500);
        }

        /// <summary>
        /// Double left mouse click
        /// </summary>
        /// <returns>void</returns>
        public static void SendLeftButtonDoubleClick()
        {
            var sim = new InputSimulator();
            sim.Mouse.LeftButtonDoubleClick().Sleep(500);
        }


        /// <summary>
        /// Right mouse click
        /// </summary>
        /// <returns>void</returns>
        public static void SendRightButtonClick()
        {
            var sim = new InputSimulator();
            sim.Mouse.RightButtonClick().Sleep(500);
        }


        /// <summary>
        /// Double right mouse click
        /// </summary>
        /// <returns>void</returns>
        public static void SendRightButtonDoubleClick()
        {
            var sim = new InputSimulator();
            sim.Mouse.RightButtonDoubleClick().Sleep(500);
        }
    }
}
