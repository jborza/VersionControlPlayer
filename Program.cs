using System.Threading;

namespace VersionControlPlayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Keyboard kbd = new Keyboard();
            Thread.Sleep(10000);
            while(true)
            {
                Thread.Sleep(100);
                //click on buy max (T)
                kbd.Send(Keyboard.ScanCodeShort.KEY_T);
                //click on buy max (M)
                kbd.Send(Keyboard.ScanCodeShort.KEY_M);
            }
        }
    }
}