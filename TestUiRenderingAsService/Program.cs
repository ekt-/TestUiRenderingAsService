using System.ServiceProcess;
using System.Windows.Forms;

namespace TestUiRenderingAsService
{
    static class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false); // this actually changes how text is rendered

            ServiceBase.Run(new TestUiRenderingService());
        }
    }
}
