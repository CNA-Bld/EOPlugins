using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;


namespace BrowserLocator
{
    public partial class BrowserLocatorWindow : Form
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool EnumChildWindows(IntPtr hwndParent, EnumWindowsProc lpEnumFunc, IntPtr lParam);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        private static bool isIEServerWindow(IntPtr hWnd)
        {
            int nRet;
            StringBuilder ClassName = new StringBuilder(256);
            nRet = GetClassName(hWnd, ClassName, ClassName.Capacity);
            return (nRet != 0) && (string.Compare(ClassName.ToString(), "Internet Explorer_Server", true) == 0);
        }

        public IntPtr FindTargetHandle(IntPtr mainHandle)
        {
            List<IntPtr> childHandles = new List<IntPtr>();

            GCHandle gcChildhandlesList = GCHandle.Alloc(childHandles);
            IntPtr pointerChildHandlesList = GCHandle.ToIntPtr(gcChildhandlesList);

            try
            {
                EnumWindowsProc childProc = new EnumWindowsProc(EnumWindow);
                EnumChildWindows(mainHandle, childProc, pointerChildHandlesList);
            }
            finally
            {
                gcChildhandlesList.Free();
            }

            foreach (IntPtr handle in childHandles) {
                if (isIEServerWindow(handle))
                {
                    return handle;
                }
            }

            foreach (IntPtr handle in childHandles)
            {
                IntPtr possibleHandle = FindTargetHandle(handle);
                if (!possibleHandle.Equals(IntPtr.Zero))
                {
                    return possibleHandle;
                }
            }

            return IntPtr.Zero;
        }

        private bool EnumWindow(IntPtr hWnd, IntPtr lParam)
        {
            GCHandle gcChildhandlesList = GCHandle.FromIntPtr(lParam);

            if (gcChildhandlesList == null || gcChildhandlesList.Target == null)
            {
                return false;
            }

            List<IntPtr> childHandles = gcChildhandlesList.Target as List<IntPtr>;
            childHandles.Add(hWnd);

            return true;
        }

        public BrowserLocatorWindow()
        {
            InitializeComponent();
        }

        override protected void OnLoad(EventArgs e)
        {
            IntPtr handle = GetHandle();
            Clipboard.SetText(handle.ToString());
            MessageBox.Show("Copied " + handle.ToString() + " to cilpboard.");
            Close();
        }

        private IntPtr GetHandle()
        {
            Process process = Process.GetCurrentProcess();
            return FindTargetHandle(process.MainWindowHandle);
        }
    }
}
