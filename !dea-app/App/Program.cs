using System;
using System.Net.Http;
using System.Windows.Forms;

namespace School_API_Consummer
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Form pre = new Form1();
                pre.ShowDialog();
                pre = null;

                Form app = new Form2();
                app.ShowDialog();
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu algum erro inesperado. Tente novamente mais tarde.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
         
        }
    }
}
