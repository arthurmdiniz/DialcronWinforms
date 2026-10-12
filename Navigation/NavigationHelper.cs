namespace DialcronWinforms.Navigation;

public static class NavigationHelper
{
    private static Panel? _container;
    private static UserControl? _current;

    public static void Initialize(Panel container)
    {
        _container = container;
    }

    public static void NavigateTo(UserControl control)
    {
        if (_container is null)
            throw new InvalidOperationException("NavigationHelper not initialized.");

        _current = control;
        _current.Dock = DockStyle.Fill;

        _container.Controls.Clear();
        _container.Controls.Add(_current);
    }
}
