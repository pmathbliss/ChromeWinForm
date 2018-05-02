using SharpCaster.Controllers;
using SharpCaster.Models;
using SharpCaster.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChromeWinForm
{
    public partial class MainForm : Form
    {

        private ChromecastService _chromecastService;
        private Chromecast selectedChromecast;

        public MainForm()
        {
            InitializeComponent();
        }

        private async void btnFind_ClickAsync(object sender, EventArgs e)
        {
            lbChromeCasts.DisplayMember = "FriendlyName";
            lbChromeCasts.ValueMember = "FriendlyName";
            _chromecastService = ChromecastService.Current;
            btnFind.Enabled = false;
            ObservableCollection<Chromecast> devices = await _chromecastService.StartLocatingDevices();
            await Task.Delay(4000);

            if(devices.Count == 0)
            {
                btnFind.Enabled = true;
                return;
            }

            lbChromeCasts.Items.Clear();
            foreach (var device in devices)
            {
                lbChromeCasts.Items.Add(device);
            }
            btnFind.Enabled = true;
            //_chromecastService.ConnectToChromecast(device.First()).Wait(2000);
            //LaunchingSharpCasterDemo("my url");
        }

        public async void LaunchingSharpCasterDemo(string url)
        {
            var controller = await _chromecastService.ChromeCastClient.LaunchWeb();
            await Task.Delay(4000);
            await controller.LoadUrl("https://www.windytv.com/");
            await Task.Delay(4000);
        }

        private void lbChromeCasts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var box = sender as ListBox;
            selectedChromecast = (Chromecast)box.SelectedItem;

            lblChromeCastName.Text = selectedChromecast.FriendlyName;
            txtURL.Enabled = true;
        }

        private void txtURL_TextChanged(object sender, EventArgs e)
        {
            var textbox = (TextBox)sender;
            btnCast.Enabled = textbox.Text.Length > 0;
        }

        private async void btnCast_Click(object sender, EventArgs e)
        {
            string url = txtURL.Text;
            btnCast.Enabled = false;
            if(url.Length < 10)
            {
                MessageBox.Show("Enter a valid URL");
                btnCast.Enabled = true;
                return;
            }
            try
            {
                if (!_chromecastService.ChromeCastClient.Connected)
                {
                    ////_chromecastService.ConnectToChromecast(selectedChromecast).Wait(6000);
                }
                var thing =_chromecastService.ChromeCastClient.ChromecastStatus.Applications.First(x => x.AppId == WebController.WebAppId);

                var controller = await _chromecastService.ChromeCastClient.LaunchWeb();
                await Task.Delay(4000);
                await controller.LoadUrl(txtURL.Text);
                await Task.Delay(4000);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            btnCast.Enabled = true;

        }
    }
}
