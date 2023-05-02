using System.Windows.Forms;
using SharedProject;

namespace TestUiRenderingAsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            SaveToImage.TrySavingWpfControlAsPng();
            SaveToImage.TrySavingWinFormControlAsPng();

            textBox1.Text += Common.OutputFolder;
        }
    }
}
