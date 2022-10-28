using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCSharp_SchoolGradingSystem
{
    
    public class MainWindowView
    {

        public static int SwitchView
        {
            get;
            set;
        }
        public MainWindowView()
        {
            SwitchView = 0;
        }
        public MainWindowView(int x)
        {
            SwitchView = x;
        }
        public void switchusercontrol(int settothispage)
        {
            SwitchView = settothispage;
        }

    }
    
}
