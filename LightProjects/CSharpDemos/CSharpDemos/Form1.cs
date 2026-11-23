using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CSharpDemos
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr SendMessage(IntPtr hWnd, Int32 Msg, Int32 wParam, Int32 lParam);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // create a new process
            Process proc;

            // Start the process
            proc = Process.Start("notepad.exe");
            proc.WaitForInputIdle();

            // Set the panel control as the application's parent
            SetParent(proc.MainWindowHandle, this.panel1.Handle);
            
            // maximize the application
            SendMessage(proc.MainWindowHandle, 274, 61488, 0);

        }
    }
}
