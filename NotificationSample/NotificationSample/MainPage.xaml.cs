using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NotificationSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void SendNotification(object sender, EventArgs e)
        {
            DependencyService.Get<INotification>().CreateNotification("VLTutorials", message.Text);
        }
        public void MACAddress()
        {
            try { 
            var ni = NetworkInterface.GetAllNetworkInterfaces()
             .OrderBy(intf => intf.NetworkInterfaceType)
                .FirstOrDefault(intf => intf.OperationalStatus == OperationalStatus.Up
         && (intf.NetworkInterfaceType == NetworkInterfaceType.Wireless80211
             || intf.NetworkInterfaceType == NetworkInterfaceType.Ethernet));
            var hw = ni.GetPhysicalAddress();
            string mac = string.Join(":", (from ma in hw.GetAddressBytes() select ma.ToString("X2")).ToArray());
            MAC.Text = mac;
        }
            catch
            {
                MAC.Text = "N/A";
            }
        }
        private void Login(object sender, EventArgs e)
        {
            loginPanel.IsVisible = false;
            notificationPanel.IsVisible = true;
            devicePanel.IsVisible = true;
            MACAddress();
        }
    }
}
