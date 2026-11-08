using System;
using System.Windows.Forms;

namespace WindowsFormsApp111
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form111());
        }
    }
}