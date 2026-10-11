namespace DialcronWinforms.Forms;

public class MainForm : Form
{
    public MainForm()
    {
        Text = "Dialcron";
        Size = new Size(450, 400);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Cores.Creme;

        var lblTitulo = new Label
        {
            Text = "Dialcron",
            Font = new Font("Segoe UI", 24, FontStyle.Bold),
            ForeColor = Cores.Primary,
            AutoSize = true,
            Location = new Point(160, 40)
        };

        var lblSubtitulo = new Label
        {
            Text = "Sistema de agendamentos",
            Font = new Font("Segoe UI", 12),
            ForeColor = Cores.Gray600,
            AutoSize = true,
            Location = new Point(150, 85)
        };

        var btnAgenda = new Button
        {
            Text = "Agenda",
            Size = new Size(200, 45),
            Location = new Point(125, 140),
            BackColor = Cores.Primary,
            ForeColor = Cores.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 12)
        };
        btnAgenda.FlatAppearance.BorderSize = 0;

        var btnCadastros = new Button
        {
            Text = "Cadastros",
            Size = new Size(200, 45),
            Location = new Point(125, 200),
            BackColor = Cores.Primary,
            ForeColor = Cores.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 12)
        };
        btnCadastros.FlatAppearance.BorderSize = 0;

        var btnBackup = new Button
        {
            Text = "Backup",
            Size = new Size(200, 45),
            Location = new Point(125, 260),
            BackColor = Cores.Primary,
            ForeColor = Cores.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 12)
        };
        btnBackup.FlatAppearance.BorderSize = 0;

        Controls.Add(lblTitulo);
        Controls.Add(lblSubtitulo);
        Controls.Add(btnAgenda);
        Controls.Add(btnCadastros);
        Controls.Add(btnBackup);
    }
}
