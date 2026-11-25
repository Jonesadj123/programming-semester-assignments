using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Module4project
{
    internal static class Program
    {
        /// <summary>
        /// Main entry point for the Module 4 application.
        /// This application shows C# data types
        /// through a Windows Forms interface.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Enable Windows visual styles.
            Application.EnableVisualStyles();

            // Set compatible text rendering.
            Application.SetCompatibleTextRenderingDefault(false);

            // Launch the data types form.
            Application.Run(new frmofDataTypes());
        }
    }
}
}
