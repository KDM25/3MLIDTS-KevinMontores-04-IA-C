using System;
using System.Windows.Forms;

namespace _3MLIDTS_KevinMontores_04_IA_C
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}