using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using SharpCaster.Controllers;
using SharpCaster.Extensions;
using SharpCaster.Models;
using SharpCaster.Models.ChromecastStatus;
using SharpCaster.Models.MediaStatus;
using SharpCaster.Services;
using System.Windows.Forms;
using System.Diagnostics;

namespace ChromeWinForm
{
    public partial class MainForm : Form
    {

        private ChromecastService _chromecastService;
        private Chromecast selectedChromecast;
        private static SharpCaster.Controllers.WebController _controller;
        static readonly ChromecastService ChromecastService = ChromecastService.Current;
       // static SharpCaster.WebController _controller;

        public MainForm()
        {
            InitializeComponent();
            txtURL.DataBindings.Add("Text", Settings.Default, "URL");
        }

        private async void btnFind_ClickAsync(object sender, EventArgs e)
        {
            lbChromeCasts.DisplayMember = "FriendlyName";
            lbChromeCasts.ValueMember = "FriendlyName";
            _chromecastService = ChromecastService.Current;
            btnFind.Enabled = false;

            //ChromecastService.ChromeCastClient.ApplicationStarted += Client_ApplicationStarted;
            //ChromecastService.ChromeCastClient.VolumeChanged += _client_VolumeChanged;
            //ChromecastService.ChromeCastClient.MediaStatusChanged += ChromeCastClient_MediaStatusChanged;
            ChromecastService.ChromeCastClient.ConnectedChanged += ChromeCastClient_Connected;

            System.Console.WriteLine("Started locating chromecasts!");
            var devices = await _chromecastService.StartLocatingDevices();

            if (devices.Count == 0)
            {
                btnFind.Enabled = true;
                return;
            }
            lblStatus.Text = "Found chromecasts";
            lbChromeCasts.Items.Clear();
            foreach (var device in devices)
            {
                lbChromeCasts.Items.Add(device);
            }
            btnFind.Enabled = true;
        }

        public static WebController _webController = null;
        public async Task OpenWebPage(string url)
        {
            _webController = await ChromecastService.ChromeCastClient.LaunchWeb();
            await Task.Delay(5000);
            await _webController.LoadUrl(url); 
            await Task.Delay(5000);
        }

        public async Task CloseWebPageController()
        {
            if (_webController != null)
            {
                await _webController.StopApplication();  // <-- (2)
            }
        }


        public async void LaunchingSharpCasterDemo(string url)
        {
            var controller = await ChromecastService.ChromeCastClient.LaunchWeb();
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
            if (url.Length < 10)
            {
                MessageBox.Show("Enter a valid URL");
                btnCast.Enabled = true;
                return;
            }
            try
            {

                if (_chromecastService.ChromeCastClient.Connected)
                    await _chromecastService.ChromeCastClient.DisconnectChromecast();

                if (!_chromecastService.ChromeCastClient.Connected)
                {


                    lblStatus.Text = $"Finding {selectedChromecast.FriendlyName} {selectedChromecast.DeviceUri}";
                    //relocated selected device?
                    var devices = await ChromecastService.StartLocatingDevices();

                    if (devices.Count == 0)
                    {
                        System.Console.WriteLine("No chromecasts found");
                        return;
                    }
                    
                    var firstChromecast = devices.Where(x =>  x.DeviceUri == selectedChromecast.DeviceUri).First();//this will find the tv
                    
                    await ChromecastService.ConnectToChromecast(firstChromecast);

                    lblStatus.Text = $"Connected to {firstChromecast.FriendlyName} {firstChromecast.DeviceUri}";
                    //await connect.ContinueWith(t => {
                    //    lblStatus.Text = "Connected?";
                    //    Task openPage = OpenWebPage(url);
                    //    openPage.ContinueWith(x =>
                    //   {
                    //       lblStatus.Text = "Web page opened?";

                    //       btnCast.Enabled = true;
                    //   });
                    //});
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            btnCast.Enabled = true;

        }

        private  async static void ChromeCastClient_Connected(object sender, EventArgs e)
        {
            System.Console.WriteLine("Connected to chromecast");
            if (_controller == null)
            {

                _webController = await ChromecastService.ChromeCastClient.LaunchWeb();

                //await _controller.LoadUrl("https://www.youtube.com");
            }
        }

        private async static void ChromeCastClient_MediaStatusChanged(object sender, MediaStatus e)
        {
            if (e.PlayerState == PlayerState.Playing)
            {
                await Task.Delay(2000);
                await ChromecastService.ChromeCastClient.DisconnectChromecast();
                _controller = null;
                await Task.Delay(5000);
                var devices = await ChromecastService.StartLocatingDevices();

                if (devices.Count == 0)
                {
                    System.Console.WriteLine("No chromecasts found");
                    return;
                }

                var firstChromecast = devices.First();
                System.Console.WriteLine("Device found " + firstChromecast.FriendlyName);
                await ChromecastService.ConnectToChromecast(firstChromecast);
                await Task.Delay(5000);
                _controller = await ChromecastService.ChromeCastClient.LaunchWeb();
                await Task.Delay(4000);
                var track = new Track
                {
                    Name = "English Subtitle",
                    TrackId = 100,
                    Type = "TEXT",
                    SubType = "captions",
                    Language = "en-US",
                    TrackContentId =
               "https://commondatastorage.googleapis.com/gtv-videos-bucket/CastVideos/tracks/DesigningForGoogleCast-en.vtt"
                };
                while (_controller == null)
                {
                    await Task.Delay(500);
                }

                //await _controller.LoadMedia("https://commondatastorage.googleapis.com/gtv-videos-bucket/CastVideos/mp4/DesigningForGoogleCast.mp4", "video/mp4", null, "BUFFERED", 0D, null, ew[] { track }, new[] { 100 });
            }
        }

        private static void _client_VolumeChanged(object sender, Volume e)
        {
        }

        private static async void Client_ApplicationStarted(object sender, ChromecastApplication e)
        {
            System.Console.WriteLine($"Application {e.DisplayName} has launched");
            var track = new Track
            {
                Name = "English Subtitle",
                TrackId = 100,
                Type = "TEXT",
                SubType = "captions",
                Language = "en-US",
                TrackContentId =
               "https://commondatastorage.googleapis.com/gtv-videos-bucket/CastVideos/tracks/DesigningForGoogleCast-en.vtt"
            };
            while (_controller == null)
            {
                await Task.Delay(500);
            }

            //await _controller.LoadMedia("https://commondatastorage.googleapis.com/gtv-videos-bucket/CastVideos/mp4/DesigningForGoogleCast.mp4", "video/mp4", null, "BUFFERED", 0D, null, new[]  track }, new[] { 100 });
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Settings.Default.Save();
            if(MainForm._webController != null)
            {
                _webController.LoadUrl(txtURL.Text);
            }
        }

        private async void btnDisconnect_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Disconnecting...";
            if (MainForm._webController != null)
            {
                await MainForm._webController.StopApplication();
                MainForm._webController = null;
                lblStatus.Text = "Disconnected";
                return;
            }
            lblStatus.Text = "Not Connected";
        }
    }
}

