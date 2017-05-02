using System.Windows.Forms;

namespace BouncingBalls
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Text = "Choose Number of Balls";
            txtNumberOfBalls.MaxLength = 2;
            AcceptButton = btnOk;
            StartPosition = FormStartPosition.CenterParent;

            KeyPress += (a, b) =>
            {
                if (!char.IsNumber(b.KeyChar))
                    b.Handled = true;
            };

            btnOk.Click += (a, b) =>
            {
                int numberOfBalls;
                if (!int.TryParse(txtNumberOfBalls.Text, out numberOfBalls) || numberOfBalls == 0)
                {
                    MessageBox.Show("Enter a valid number (1-99)");
                    return;
                }

                NumberOfBalls = numberOfBalls;
                this.DialogResult = DialogResult.OK;
            };
        }

        public int NumberOfBalls { get; set; }
    }
}
