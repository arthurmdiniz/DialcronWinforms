namespace DialcronWinforms.Forms;

partial class ClienteForm
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
        this.Text = "Cadastro de Clientes";
        this.ClientSize = new Size(700, 550);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.BackColor = Cores.Creme;
    }
}
