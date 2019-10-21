using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Plugin.Media;
using Newtonsoft.Json;
using RestSharp;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;

namespace Astronomy.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FacePage : ContentPage
    {
        [Obsolete]
        public FacePage()
        {
            InitializeComponent();

            /*  */
            RestClient client = new RestClient("https://centralus.api.cognitive.microsoft.com/");
            client.AddDefaultHeader("Ocp-Apim-Subscription-Key", "<Key Comes Here>");
            RestRequest request = new RestRequest("face/v1.0/detect?returnFaceAttributes=emotion", Method.POST);
            request.AddHeader("Content-Type", "application/json");

            String imageURL = "https://pixabay.com/get/54e7d54b495aac14f6da8c7dda793f7f1636dfe2564c704c722e7ed2954ec55d_340.jpg";
            request.AddParameter("application/json", "{\"url\":\"" + imageURL + "\"}", ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            demoText.Text = "Sadness Score";
            demoText2.Text += response.Content;

            //CameraButton.Clicked += CameraButton_Clicked;
        }
        //private async void CameraButton_Clicked(object sender, EventArgs e)
        //{
        //    var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

        //    if (photo != null)
        //        PhotoImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
        //}
    }
}