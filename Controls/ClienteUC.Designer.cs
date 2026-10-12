namespace DialcronWinforms.Controls;

partial class ClienteUC
{
    private System.ComponentModel.IContainer components = null;

    private Label lblConstrucao;

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
        this.SuspendLayout();

        // ClienteUC
        this.Name = "ClienteUC";
        this.lblConstrucao = new Label();
        this.lblConstrucao.Text = "Tela em construção - " + this.Name;
        this.lblConstrucao.Font = new Font("Segoe UI", 16, FontStyle.Bold);
        this.lblConstrucao.ForeColor = Cores.Gray600;
        this.lblConstrucao.TextAlign = ContentAlignment.MiddleCenter;
        this.lblConstrucao.Dock = DockStyle.Fill;
        this.Controls.Add(this.lblConstrucao);
        this.Dock = DockStyle.Fill;
        this.ClientSize = new Size(700, 550);
        this.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        this.Padding = new Padding(20);
        this.AutoScroll = true;
        this.BackColor = Cores.Creme;
        this.ForeColor = Cores.Gray900;

        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
