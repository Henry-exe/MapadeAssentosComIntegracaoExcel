using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel; 

namespace ReservaAvancado
{
    public partial class Form1 : Form
    {
        private Excel.Application excelApp;
        private Excel.Workbook workbook;
        private Excel.Worksheet worksheet;
        private int linhaAtual = 2;

        public Form1()
        {
            InitializeComponent();
            InicializarBotoes();
            InicializarPlanilhaExcel();
            Form1_Load();

        }

        private void InicializarBotoes()
        {
            // Suponha que você tenha 40 botões com os nomes "button1", "button2", ..., "button40"
            for (int i = 1; i <= 50; i++)
            {
                Button btnAssento = (Button)Controls.Find($"button{i}", true).FirstOrDefault();

                if (btnAssento != null)
                {
                    btnAssento.Click += BtnAssento_Click;
                }
            }
        }
        public void Form1_Load()
        {
                string imagePath = @"C:\Users\henry\source\repos\ProjetosdaAula\ReservaAvancado\ReservaAvancado\Resources\Onibus.png";

                if (System.IO.File.Exists(imagePath))
                {
                    Image imagem = Image.FromFile(imagePath);
                    pictureBox1.BackgroundImage = imagem;
                    pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                    pictureBox1.ClientSize = new Size(ClientSize.Width, ClientSize.Height);
                }
        }

        private void InicializarPlanilhaExcel()
        {
            excelApp = new Excel.Application();
            excelApp.Visible = true;
            workbook = excelApp.Workbooks.Add();
            worksheet = (Excel.Worksheet)workbook.Worksheets[1];

            // Cabeçalho
            worksheet.Cells[1, 1] = "Assento";
            worksheet.Cells[1, 2] = "Nome";
            worksheet.Cells[1, 3] = "Sala";
        }

        private void BtnAssento_Click(object sender, EventArgs e)
        {
            Button botao = (Button)sender;
            if(botao.BackColor == Color.Red)
            {
                MessageBox.Show("Este Assento já foi reservado");
                return;
            }
            botao.BackColor = Color.Green;

            using (FormConfirmação dialog = new FormConfirmação(botao.Text))
            {
                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    if (string.IsNullOrWhiteSpace(dialog.Nome) || string.IsNullOrWhiteSpace(dialog.Sala))
                    {
                        MessageBox.Show("Preencha todos os campos antes de confirmar a reserva.");
                        botao.BackColor = Color.Gold;
                        return; // Não faz nada se algum campo estiver vazio
                    }

                    botao.BackColor = Color.Red;
                    PreencherPlanilhaExcel(botao.Text, dialog.Nome, dialog.Sala);
                }
                else if (result == DialogResult.Cancel)
                {
                    botao.BackColor = Color.Gold;
                }
               
            }
        }

        private void PreencherPlanilhaExcel(string botao, string nome, string sala)
        {
            worksheet.Cells[linhaAtual, 1] = botao;
            worksheet.Cells[linhaAtual, 2] = nome;
            worksheet.Cells[linhaAtual, 3] = sala;

            worksheet.Columns.AutoFit();

            linhaAtual++;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}