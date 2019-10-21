using Xamarin.Forms;

using RestSharp;
namespace Astronomy.Pages
{
    public partial class AstronomicalBodiesPage : ContentPage
    {
        public AstronomicalBodiesPage()
        {
            InitializeComponent();

            btnEarth.Clicked += (s, e) => Navigation.PushAsync(new AstronomicalBodyPage(SolarSystemData.Earth));
            btnMoon.Clicked += (s, e) => Navigation.PushAsync(new AstronomicalBodyPage(SolarSystemData.Moon));
            btnSun.Clicked += (s, e) => Navigation.PushAsync(new AstronomicalBodyPage(SolarSystemData.Sun));
            btnComet.Clicked += (s, e) => Navigation.PushAsync(new AstronomicalBodyPage(SolarSystemData.HalleysComet));


            /*  */
            var client = new RestClient("https://fcm.googleapis.com/fcm/send");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", "key=<Key Comes here>");
            request.AddParameter("application/json", "{\r\n\"data\": {\r\n    \"notification\": {\r\n        \"title\": \"Alert User\",\r\n        \"body\": \"Please Act accordingly...\",\r\n        \"icon\": \"https://pixabay.com/get/54e7d54b495aac14f6da8c7dda793f7f1636dfe2564c704c722e7ed2954ec55d_340.jpg\",\r\n        \"image\": \"https://pixabay.com/get/54e7d54b495aac14f6da8c7dda793f7f1636dfe2564c704c722e7ed2954ec55d_340.jpg\",\r\n        \"click_action\":\"http://microsoft.com/\"\r\n    }\r\n  },\r\n  \"to\": \"Device Token\"\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            DisplayAlert("Alert", response.ToString(), "OK");
        }
    }
}