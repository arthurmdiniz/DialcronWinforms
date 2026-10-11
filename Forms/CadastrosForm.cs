namespace DialcronWinforms.Forms;

public class CadastrosForm : Form
{
    public CadastrosForm()
    {
        Text = "Cadastros";
        Size = new Size(400, 400);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Cores.Creme;

        var lblTitulo = new Label
        {
            Text = "Cadastros",
            Font = new Font("Segoe UI", 20, FontStyle.Bold),
            ForeColor = Cores.Primary,
            AutoSize = true,
            Location = new Point(140, 30)
        };

        var btnClientes = new Button
        {
            Text = "Clientes",
            Size = new Size(200, 40),
            Location = new Point(100, 90),
            BackColor = Cores.Primary,
            ForeColor = Cores.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 11)
        };
        btnClientes.FlatAppearance.BorderSize = 0;

        var btnServicos = new Button
        {
            Text = "Servicos",
            Size = new Size(200, 40),
            Location = new Point(100, 145),
            BackColor = Cores.Primary,
            ForeColor = Cores.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 11)
        };
        btnServicos.FlatAppearance.BorderSize = 0;

        var btnProfissionais = new Button
        {
            Text = "Profissionais",
            Size = new Size(200, 40),
            Location = new Point(100, 200),
            BackColor = Cores.Primary,
            ForeColor = Cores.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 11)
        };
        btnProfissionais.FlatAppearance.BorderSize = 0;

        var btnUnidades = new Button
        {
            Text = "Unidades",
            Size = new Size(200, 40),
            Location = new Point(100, 255),
            BackColor = Cores.Primary,
            ForeColor = Cores.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 11)
        };
        btnUnidades.FlatAppearance.BorderSize = 0;

        var btnVoltar = new Button
        {
            Text = "Voltar",
            Size = new Size(100, 35),
            Location = new Point(150, 310),
            BackColor = Cores.Gray200,
            ForeColor = Cores.Gray900,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10)
        };
        btnVoltar.FlatAppearance.BorderSize = 0;

        Controls.Add(lblTitulo);
        Controls.Add(btnClientes);
        Controls.Add(btnServicos);
        Controls.Add(btnProfissionais);
        Controls.Add(btnUnidades);
        Controls.Add(btnVoltar);
    }
}
