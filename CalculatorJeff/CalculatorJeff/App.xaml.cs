using System;
using System.Diagnostics;
using System.Windows;
namespace CalculatorJeff
{
    public  partial class App : Application
    {
        public void InitializeComponent()
        {
            base.StartupUri = new Uri("MainWindow.xaml", UriKind.Relative);
        }
        
    }
}
