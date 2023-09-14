using System;
using System.Windows.Forms;
namespace ReservaAvancado
{
    public partial class FormConfirmação : Form
    {
        public FormConfirmação(string botaoSelecionado)
        {
            InitializeComponent();
            label4.Text = botaoSelecionado;

            comboBox1.Items.Add("ADM 2A");
            comboBox1.Items.Add("MKT 2");
            comboBox1.Items.Add("ADM 2B");
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK; 
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
 
        }

        private void FormConfirmação_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; 
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
        }
        public string Nome => textBox1.Text;
        public string Sala => comboBox1.Text;

        private void label3_Click(object sender, EventArgs e)
        {

        }


    }
}
