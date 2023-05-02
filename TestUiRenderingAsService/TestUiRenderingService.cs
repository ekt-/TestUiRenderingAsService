using System;
using System.ServiceProcess;
using System.Threading;
using System.Timers;
using SharedProject;

namespace TestUiRenderingAsService
{
    public partial class TestUiRenderingService : ServiceBase
    {
        private System.Timers.Timer m_timer;

        public TestUiRenderingService()
        {
            InitializeComponent();
            ScheduleWorkerThreadCreation();
        }

        private void ScheduleWorkerThreadCreation()
        {
            m_timer = new System.Timers.Timer();
            m_timer.Interval = 100;
            m_timer.Elapsed += CreateWorkerThread;
        }

        protected override void OnStart(string[] args)
        {
            m_timer.Start();
        }

        private void CreateWorkerThread(object sender, ElapsedEventArgs e)
        {
            try
            {
                // create a thread that will do all the rendering work.
                // needed because WPF needs a STA thread, but ServiceBase are always created MTA
                // and do not honor the [STAThread attributes]
                var thread = new Thread(WorkerMethod);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                OnStop(); // kill the timer
            }
            catch (Exception exception)
            {
                Log.Info($"OnTick::{exception.Message}");
            }
        }

        protected override void OnStop()
        {
            m_timer.Stop();
            m_timer.Dispose();
        }

        private void WorkerMethod(object state)
        {
            try
            {
                Log.Info("### OnStart (STA.Thread)");
                SaveToImage.TrySavingWinFormControlAsPng();
                SaveToImage.TrySavingWpfControlAsPng();
            }
            catch (Exception e)
            {
                Log.Info(e.Message);
            }
        }
        
        
    }
}
