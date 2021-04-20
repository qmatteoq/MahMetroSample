using Bogus;
using MahApps.Metro.Controls;
using MahMetroSample.Entities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MahMetroSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : AcrylicWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void AcrylicWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ringLoading.IsActive = true;
            await Task.Delay(2000);
            LoadNotifications();
            txtComputerName.Text = Environment.MachineName;
            txtIpAddress.Text = GetLocalIPAddress();
            txtWindows10Version.Text = Environment.OSVersion.VersionString.Replace("Microsoft Windows NT", string.Empty);
            ringLoading.IsActive = false;
        }

        private void LoadNotifications()
        {
            var notifications = new Faker<Notification>()
                .RuleFor(o => o.Title, f => f.Lorem.Text())
                .RuleFor(o => o.Description, f => f.Lorem.Text())
                .RuleFor(o => o.Timestamp, f => f.Date.Past())
                .Generate(2);

            listNotifications.ItemsSource = notifications;
        }

        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        private void toggleBlur_Toggled(object sender, RoutedEventArgs e)
        {
            if (toggleBlur.IsOn)
            {
                this.EnableBlur();
            }
            else
            {
                this.DisableBlur();
            }
        }

        private void toggleTitleBar_Toggled(object sender, RoutedEventArgs e)
        {
            if (toggleTitleBar.IsOn)
            {
                this.ShowTitleBar = true;
            }
            else
            {
                this.ShowTitleBar = false;
            }
        }

        private void OnOpenSupportPage(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.onevinn.com/"){ UseShellExecute = true });
        }
    }
}
