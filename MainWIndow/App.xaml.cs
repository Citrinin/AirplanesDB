using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace MainWIndow
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //this.DispatcherUnhandledException += App_DispatcherUnhandledException;
        }

        //private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        //{
        //    MessageBox.Show(e.Exception.Message);
        //}

        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                base.OnStartup(e);
                MainWindow mainWindow = new MainWindow();
                MainWindow.Show();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }
    }
}
