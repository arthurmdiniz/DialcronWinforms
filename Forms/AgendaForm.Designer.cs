namespace DialcronWinforms.Forms;

partial class AgendaForm
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
        this.calendario.CalendarDimensions = new Size(1, 1);
        this.calendario.Name = "calendario";

        // AgendaForm
        this.Text = "Agenda";
        this.ClientSize = new Size(900, 650);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.BackColor = Cores.Creme;

        this.Controls.Add(this.calendario);
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
