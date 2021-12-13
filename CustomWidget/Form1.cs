using System.Runtime.InteropServices;


namespace CustomWidget
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr hP, IntPtr hC, string sC, string sW);
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr GetShellWindow();

        private IntPtr GetWindowsHandle()
        {
            IntPtr _progmanHndl = GetShellWindow();
            IntPtr nWinHandle = FindWindowEx(_progmanHndl, IntPtr.Zero, "SHELLDLL_DefView", null);

            if (nWinHandle != IntPtr.Zero) return nWinHandle;

            _progmanHndl = FindWindowEx(IntPtr.Zero, IntPtr.Zero, "Progman", null);
            nWinHandle = FindWindowEx(_progmanHndl, IntPtr.Zero, "SHELLDLL_DefView", null);

            if (nWinHandle != IntPtr.Zero) return nWinHandle;

            _progmanHndl = FindWindowEx(IntPtr.Zero, IntPtr.Zero, "WorkerW", null);
            nWinHandle = FindWindowEx(_progmanHndl, IntPtr.Zero, "SHELLDLL_DefView", null);

            return nWinHandle;

        }


        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        void MakeWin()
        {
            IntPtr a = GetWindowsHandle();

            SetParent(Handle, a);
        }


        public Form1()
        {
            MakeWin();  
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}