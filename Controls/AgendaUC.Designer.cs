namespace DialcronWinforms.Controls;

partial class AgendaUC
{
    private System.ComponentModel.IContainer components = null;

    private MonthCalendar calendario;

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
        this.calendario = new MonthCalendar();
        this.SuspendLayout();

        // calendario
        this.calendario.Location = new Point(20, 20);
        this.calendario.Size = new Size(260, 200);
        this.calendario.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        this.calendario.BackColor = Cores.White;
        this.calendario.ForeColor = Cores.Gray900;
        this.calendario.TitleBackColor = Cores.Primary;
        this.calendario.TitleForeColor = Cores.White;
        this.calendario.TrailingForeColor = Cores.Gray400;

        // AgendaUC
        this.Name = "AgendaUC";
        this.ClientSize = new Size(900, 650);
        this.Dock = DockStyle.Fill;
        this.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        this.Padding = new Padding(20);
        this.AutoScroll = true;
        this.BackColor = Cores.Creme;

        this.Controls.Add(this.calendario);
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
