using System.ServiceProcess;

namespace MyNewWindowsService
{
    public partial class MyWindowsService : ServiceBase
    {
        private readonly ActionManager actionManager;
        public MyWindowsService()
        {
            InitializeComponent();
            actionManager = new ActionManager();
        }

        protected override void OnStart(string[] args)
        {
            actionManager.Start();
        }

        protected override void OnStop()
        {
            actionManager.Stop();
        }
    }
}
