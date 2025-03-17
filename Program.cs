using System.Runtime.InteropServices;

namespace Toggle_Click_Lock
{
    internal class Program
    {
        static void Main()
        {
            [DllImport("user32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool SystemParametersInfo(uint action, uint param, ref bool pvParam, uint winini);


            bool clickLockStatus = false;

            SystemParametersInfo(0x101E, 0, ref clickLockStatus, 0);

            SetClickLock(clickLockStatus);

            SystemParametersInfo(0x101E, 0, ref clickLockStatus, 0);

            Environment.Exit(0);
        }

        static public void SetClickLock(bool clickLockStatus)
        {
            [DllImport("user32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool SystemParametersInfo(uint action, uint param, bool pvParam, uint winini);

            bool valueToSet = false;

            if (clickLockStatus)
            {
               valueToSet = false;
               SystemParametersInfo(0x101F, 0, false, 0);
            }
            else
            {
               valueToSet = true;
               SystemParametersInfo(0x101F, 0, true, 0);
            }
        }
    }
}


