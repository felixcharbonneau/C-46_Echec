namespace JeuEchec
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false; 
            this.MinimizeBox = false; 
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JeuEchec.nouvellePartie();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void ButtonQuitter_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
