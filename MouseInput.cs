using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VersionControlPlayer
{
    internal class MouseInput
    {
        //mouse event constants
        const int MOUSEEVENTF_LEFTDOWN = 2;
        const int MOUSEEVENTF_LEFTUP = 4;
        //input type constant
        const int INPUT_MOUSE = 0;

        public struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public int mouseData;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        public struct INPUT
        {
            public uint type;
            public MOUSEINPUT mi;
        };

        [DllImport("User32.dll", SetLastError = true)]
        public static extern int SendInput(int nInputs, ref INPUT pInputs,
                                   int cbSize);

        public void Click(int x, int y)
        {
            //set up the INPUT struct and fill it for the mouse down
            INPUT i = new INPUT();
            i.type = INPUT_MOUSE;
            i.mi.dx = x;
            i.mi.dy = y;
            i.mi.dwFlags = MOUSEEVENTF_LEFTDOWN;
            i.mi.dwExtraInfo = IntPtr.Zero;
            i.mi.mouseData = 0;
            i.mi.time = 0;
            //send the input 
            SendInput(1, ref i, Marshal.SizeOf(i));
            //set the INPUT for mouse up and send it
            i.mi.dwFlags = MOUSEEVENTF_LEFTUP;
            SendInput(1, ref i, Marshal.SizeOf(i));
        }
    }
}
