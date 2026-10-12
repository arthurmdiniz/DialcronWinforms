namespace DialcronWinforms.Forms;

partial class ServicoForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.Text = "Cadastro de Servicos";
        this.ClientSize = new Size(600, 450);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.BackColor = Cores.Creme;
    }
}
