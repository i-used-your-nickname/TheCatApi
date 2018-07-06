using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Graphics;
using System.Net;

namespace TheCatApi
{
    [Activity(Theme = "@style/AppTheme", MainLauncher = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        Button load;
        ImageView cat;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            load = FindViewById<Button>(Resource.Id.load);
            cat = FindViewById<ImageView>(Resource.Id.cat);

          
            load.Click += delegate 
                {
                    var webClient = new WebClient();
                    var imageBytes = webClient.DownloadData("http://thecatapi.com/api/images/get?format=src&type=jpg");

                    //  if (imageBytes != null && imageBytes.Length > 0)  just for checking if exist
                    //{
                    var imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                    cat.SetImageBitmap(imageBitmap);
                    //}
                }; 

        }

     
    }
}

