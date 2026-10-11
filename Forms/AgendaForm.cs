namespace DialcronWinforms.Forms;

public class AgendaForm : Form
{
    public AgendaForm()
    {
        Text = "Agenda";
        Size = new Size(900, 650);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Cores.Creme;

        var calendario = new MonthCalendar
        {
            Location = new Point(20, 20),
            CalendarDimensions = new Size(1, 1)
        };

        Controls.Add(calendario);
    }
}
