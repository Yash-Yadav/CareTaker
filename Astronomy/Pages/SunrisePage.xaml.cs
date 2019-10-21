using System;
using System.Threading.Tasks;
using Xamarin.Forms;

using System.Net.Http;

namespace Astronomy.Pages
{
    public partial class SunrisePage : ContentPage
    {
        ILatLongService LatLongService { get; set; }
        public SunrisePage ()
        {
            InitializeComponent ();
            LatLongService = new FakeLatLongService();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await InitializeUI();
        }

        async Task InitializeUI ()
        {
            var latLongData = await LatLongService.GetLatLong();
            var sunData = await new SunriseService().GetSunriseSunsetTimes(latLongData.Latitude, latLongData.Longitude);

            var riseTime = sunData.Sunrise.ToLocalTime();
            var setTime = sunData.Sunset.ToLocalTime();

            var span = setTime.TimeOfDay - riseTime.TimeOfDay;

            lblDate.Text = DateTime.Today.ToString("D");
            lblSunrise.Text = riseTime.ToString("h:mm tt");
            lblDaylight.Text = $"{span.Hours} hours, {span.Minutes} minutes";
            lblSunset.Text = setTime.ToString("h:mm tt");

            var request = new HttpRequestMessage();
            String msg = "Hi this is a Demo String...";
            String receiverNumber = "9873686122";
            request.RequestUri = new Uri("https://login.smsninja.in/sms/api?action=send-sms&api_key=<KeyComesHere>&to=+91" 
                + receiverNumber 
                + "&from=ANURAG&sms=" 
                + msg);
            request.Method = HttpMethod.Get;
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //Success
                await DisplayAlert("Alert", "You have been alerted", "OK");
            }
            HttpContent content = response.Content;
        }
    }
}