using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.OS;
using Naxam.Controls.Platform.Droid;
using Android.Graphics;
using static Android.App.ActivityManager;

namespace AppClass.Droid
{
    [Activity(Label = "AppClass", Icon = "@drawable/ClassPadIcon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            Xamarin.Forms.Forms.Init(this, bundle);


            var stateList = new Android.Content.Res.ColorStateList(
                new int[][] {
                    new int[] { Android.Resource.Attribute.StateChecked
                },
                new int[] { Android.Resource.Attribute.StateEnabled
                }
                },
                new int[] {
                    Color.Rgb(170,190,220), //Selected
                    Color.Rgb(0,30,60) //Normal
	            });

            BottomTabbedRenderer.BackgroundColor = Color.Rgb(51, 102, 153); 
            BottomTabbedRenderer.IconSize = 30;
            BottomTabbedRenderer.ItemPadding = new Xamarin.Forms.Thickness(8);
            BottomTabbedRenderer.FontSize = 18;
            BottomTabbedRenderer.ItemTextColor = stateList;
            BottomTabbedRenderer.ItemIconTintList = stateList;
            BottomTabbedRenderer.ItemAlign = ItemAlignFlags.Center;
            BottomTabbedRenderer.Typeface = Typeface.CreateFromAsset(this.Assets, "ErasRegular.ttf");
            Window.SetStatusBarColor(Color.Black);
            ImageCircle.Forms.Plugin.Droid.ImageCircleRenderer.Init();
            ButtonCircle.FormsPlugin.Droid.ButtonCircleRenderer.Init();

            Bitmap bm = BitmapFactory.DecodeResource(Resources, Resource.Drawable.icon);
            TaskDescription taskDesc = new TaskDescription("AppClass", bm, Resources.GetColor(Resource.Color.black));
            SetTaskDescription(taskDesc);

            LoadApplication(new App());
        }
    }
}

