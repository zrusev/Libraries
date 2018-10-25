namespace ImageContainer
{
    using Enums;
    using Structs;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using WindowsInput.Native;

    internal static class VirtualInput
    {
        /// <summary>
        /// Send special keys to virtual machine(string[] keysEntry)
        /// </summary>
        /// <param name="keysEntry">string[] keysEntry</param>
        /// <returns>void</returns>
        public static void SendKeystrokes(string[] keysEntry)
        {
            var commandList = new List<int>();

            foreach (var entry in keysEntry)
            {
                commandList.Add((int)(VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), entry));
            }

            ProcessKeys(commandList.ToArray());
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint SendInput(int numberOfInputs, Input[] inputs, int sizeOfInputStructure);

        [DllImport("user32.dll")]
        internal static extern uint MapVirtualKey(uint uCode, uint uMapType);

        private static void ProcessKeys(int[] keys)
        {
            Input[] inputs = new Input[keys.Length + 1];

            for (int i = 0; i < keys.Length; i++)
            {
                uint skey = MapVirtualKey((uint)keys[i], (uint)0x0);
                inputs[i].type = InputType.INPUT_KEYBOARD;
                inputs[i].Event.ki.dwFlags = KeyEventF.SCANCODE;
                inputs[i].Event.ki.wScan = (ushort)skey;
            }

            //Release the first pressed key
            uint skeyLast = MapVirtualKey((uint)keys[0], (uint)0x0);
            inputs[keys.Length].type = InputType.INPUT_KEYBOARD;
            inputs[keys.Length].Event.ki.dwFlags = KeyEventF.SCANCODE;
            inputs[keys.Length].Event.ki.dwFlags |= KeyEventF.KEYUP;
            inputs[keys.Length].Event.ki.wScan = (ushort)skeyLast;

            uint cSuccess = SendInput(inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
        }
    }
}