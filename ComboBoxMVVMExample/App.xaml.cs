using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ComboBoxMVVMExample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // MVVM Instantiation on App.xaml
            //MainWindow appMainWindow = new MainWindow();
            //ViewModel.ExampleViewModel viewModelContext = new ViewModel.ExampleViewModel();
            //appMainWindow.DataContext = viewModelContext;
            //appMainWindow.Show();
        }
    }
}
