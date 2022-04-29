using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace App40
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue800, Primary.Blue900,
                Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            materialLabel3.Visible = false;
            materialComboBox2.Visible = false;
            //criar um arraylist
            ArrayList formaPagto = new ArrayList();
            formaPagto.Add(new FormaPagto(1, "Dinheiro"));
            formaPagto.Add(new FormaPagto(2, "Cartão"));
            formaPagto.Add(new FormaPagto(3, "Pix"));

            //vincular ao combo box
            materialComboBox1.DataSource = formaPagto;
            materialComboBox1.DisplayMember = "Descricao";
            materialComboBox1.ValueMember = "Id";

            for(int i = 1; i <= 12; i++)
            {
                materialComboBox2.Items.Add(i);
            }
        }

        public class FormaPagto
        {
            public int Id { get; set; }
            public string Descricao { get; set; }

            public FormaPagto(int id, string descricao)
            {
                this.Id = id;
                this.Descricao = descricao;
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            int escolha = materialComboBox1.SelectedIndex;
            double d = double.Parse(txtValor.Text);

            switch (escolha)
            {
                case 0:
                    MessageBox.Show($"O valor da compra é de {d:F2}");
                    break;
                case 1:
                    int parcelas = materialComboBox2.SelectedIndex+1;
                    double valorParcelado = d / (double) parcelas;
                    MessageBox.Show($"O valor parcelado ficou em: {valorParcelado}. " +
                        $"A quantidade de parcelas é de {parcelas}.");
                    break;
                case 2:
                    Random randNum = new Random();
                    MessageBox.Show("O metodo de pagamento escolhido foi PIX, a chave " +
                        $"para pagamento é {randNum.Next()}");
                    break;
            }
        }

        private void materialComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int escolha = materialComboBox1.SelectedIndex;
            if (escolha == 1)
            {
                materialComboBox2.Visible = true;
                materialLabel3.Visible = true;
            }
            else
            {
                materialComboBox2.Visible = false;
                materialLabel3.Visible = false;
            }
        }
    }
}



