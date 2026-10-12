namespace DialcronWinforms.Controls;

partial class UnidadeUC
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
        lblConstrucao = new Label();
        SuspendLayout();
        // 
        // lblConstrucao
        // 
        lblConstrucao.Dock = DockStyle.Fill;
        lblConstrucao.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblConstrucao.ForeColor = Color.FromArgb(92, 75, 78);
        lblConstrucao.Location = new Point(20, 20);
        lblConstrucao.Name = "lblConstrucao";
        lblConstrucao.Size = new Size(971, 675);
        lblConstrucao.TabIndex = 0;
        lblConstrucao.Text = "Tela em construção - UnidadeUC";
        lblConstrucao.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // UnidadeUC
        // 
        AutoScroll = true;
        BackColor = Color.FromArgb(255, 248, 245);
        Controls.Add(lblConstrucao);
        ForeColor = Color.FromArgb(59, 48, 50);
        Name = "UnidadeUC";
        Padding = new Padding(20);
        Size = new Size(1011, 715);
        ResumeLayout(false);
    }
}
