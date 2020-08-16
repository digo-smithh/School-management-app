using System;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using School_API_Consummer.Classes;

namespace School_API_Consummer
{
    public partial class Form2 : Form
    {
        private Fila<Resultados> fila;
        private bool aumentar;
        public Form2()
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:4000/");
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                response.Close();
            }
            catch (Exception)
            {
                throw new HttpRequestException("Falha ao conectar-se ao servidor. Tente novamente mais tarde!");
            }

            try
            {
                InitializeComponent();
                fila = new Fila<Resultados>();
                textBox1.Focus();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza de que deseja encerrar o programa?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Width = 38;
            button2.Height = 38;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.Width = 41;
            button2.Height = 41;
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            button2.Width = 46;
            button2.Height = 46;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            verificarCampos();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            verificarCampos();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Equals(","))
            {
                textBox4.Text = "";
                return;
            }
            if (textBox4.TextLength > 0 && float.Parse(textBox4.Text) > (float)10)
            {
                textBox4.Text = "";
            }
            verificarCampos();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals(","))
            {
                textBox2.Text = "";
                return;
            }
            verificarCampos();
            if (textBox2.TextLength > 0 && float.Parse(textBox2.Text) > (float)100)
            {
                textBox2.Text = "";
            }
        }

        private void verificarCampos()
        {
            if (textBox1.TextLength > 0 &&
                textBox2.TextLength > 0 &&
                textBox3.TextLength > 0 &&
                textBox4.TextLength > 0)
                button2.Enabled = true;
            else
                button2.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:4000/");

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("Alunos/" + textBox1.Text).Result;

            if (response.StatusCode.ToString().Equals("NotFound"))
            {
                MessageBox.Show("Aluno não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                client.Dispose();
                limparTela();
                return;
            }

            response = client.GetAsync("Disciplina/" + textBox3.Text).Result;

            if (response.StatusCode.ToString().Equals("NotFound"))
            {
                MessageBox.Show("Disciplina não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                client.Dispose();
                limparTela();
                return;
            }

            response = client.GetAsync("Matricula/" + textBox1.Text + "/" + textBox3.Text).Result;

            if (response.StatusCode.ToString().Equals("NotFound"))
            {
                MessageBox.Show("Matrícula não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                client.Dispose();
                limparTela();
                return;
            }

            response = client.GetAsync("Resultado/" + textBox1.Text + "/" + textBox3.Text).Result;

            if (!response.StatusCode.ToString().Equals("NotFound"))
            {
                MessageBox.Show("Este resultado já foi cadastrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                client.Dispose();
                limparTela();
                return;
            }

            client.Dispose();

            for(int i = 0; i < fila.GetQtd(); i++)
            {
                if(fila.Get(i).RA == short.Parse(textBox1.Text) && fila.Get(i).Cod == short.Parse(textBox3.Text))
                {
                    MessageBox.Show("O dado já foi inserido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    limparTela();
                    return;
                }
            }

            dataGridView1.Rows.Add();
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = textBox1.Text;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1].Value = textBox3.Text;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value = textBox4.Text;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[3].Value = textBox2.Text;

            Resultados res = new Resultados(short.Parse(textBox1.Text), int.Parse(textBox3.Text), float.Parse(textBox4.Text), float.Parse(textBox2.Text));

            fila.Enfileirar(res);
            limparTela();
            button2.Enabled = false;
            button1.Enabled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }

            if (textBox4.TextLength == 2 && !textBox4.Text.Contains(",") && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }

            if (textBox4.TextLength > 0 && (e.KeyChar == ','))
            {
                textBox4.MaxLength = 3;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }

            if (textBox2.TextLength == 3 && !textBox2.Text.Contains(",") && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }

            if (textBox2.TextLength > 0 && (e.KeyChar == ','))
            {
                textBox2.MaxLength = 4;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:4000/");

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = null;

            for (int i = 0; i < fila.GetQtd(); i++)
            {
                string json = new JavaScriptSerializer().Serialize(fila.Get(i));
                response = client.PostAsync("Resultado", new StringContent(json, Encoding.UTF8, "application/json")).Result;
            }

            if (response.StatusCode.ToString().Equals("InternalServerError"))
            {
                MessageBox.Show(response.ReasonPhrase, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                client.Dispose();
                limparTela();
                limparTabela();
                return;
            }

            client.Dispose();
            MessageBox.Show("Os dados foram inseridos com sucesso!", "Parabéns!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            limparTela();
            limparTabela();
            button1.Enabled = false;
            button2.Enabled = false;
        }

        private void limparTela()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox1.Focus();
        }

        private void limparTabela()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cadastrarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            aumentar = false;
            regularFontes();
            cadastrarToolStripMenuItem2.Font = new Font(new FontFamily("Trebuchet MS"), 9, FontStyle.Underline);
        }

        private void visualizarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            aumentar = true;
            regularFontes();
            visualizarToolStripMenuItem2.Font = new Font(new FontFamily("Trebuchet MS"), 9, FontStyle.Underline);
        }

        private void disciplinasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aumentar = true;
            regularFontes();
            disciplinasToolStripMenuItem.Font = new Font(new FontFamily("Trebuchet MS"), 9, FontStyle.Underline);
        }

        private void alunosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aumentar = true;
            regularFontes();
            alunosToolStripMenuItem.Font = new Font(new FontFamily("Trebuchet MS"), 9, FontStyle.Underline);
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                var result = new Resultados(short.Parse(row.Cells[0].Value.ToString()),
                                           int.Parse(row.Cells[1].Value.ToString()),
                                           float.Parse(row.Cells[2].Value.ToString()),
                                           float.Parse(row.Cells[3].Value.ToString()));

                fila.Retirar(result);
            }
        }

        private void regularFontes()
        {
            alunosToolStripMenuItem.Font = new Font(new FontFamily("Trebuchet MS"), 9, FontStyle.Regular);
            disciplinasToolStripMenuItem.Font = new Font(new FontFamily("Trebuchet MS"), 9, FontStyle.Regular);
            visualizarToolStripMenuItem2.Font = new Font(new FontFamily("Trebuchet MS"), 9, FontStyle.Regular);
            cadastrarToolStripMenuItem2.Font = new Font(new FontFamily("Trebuchet MS"), 9, FontStyle.Regular);
        }

        private void timerForm_Tick(object sender, EventArgs e)
        {
           if (aumentar)
            {
                if (panel1.Height < 500)
                {
                    panel1.Height = panel1.Height + 40;

                    if (panel1.Height == 480)
                    {
                        label5.Visible = true;
                        label6.Visible = true;
                    }
                }
            }
           else
            {
                if (panel1.Height > 0)
                {
                    panel1.Height = panel1.Height - 40;

                    if (panel1.Height == 40)
                    {
                        label5.Visible = false;
                        label6.Visible = false;
                    }
                }
            }
        }
    }
}
