namespace ProjectCSharp_SchoolGradingSystem;

public class MainWindowView
{
    public MainWindowView()
    {
        SwitchView = 0;
    }

    public MainWindowView(int x)
    {
        SwitchView = x;
    }

    public static int SwitchView { get; set; }

    public void switchusercontrol(int settothispage)
    {
        SwitchView = settothispage;
    }
}