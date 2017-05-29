using Android.App;
using Android.Widget;
using Android.OS;

namespace BottomBar
{
    [Activity(Label = "BottomBar", MainLauncher = true, Icon = "@drawable/icon", LaunchMode = Android.Content.PM.LaunchMode.SingleTask)]
    public class MainActivity : BaseActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            FrameLayout contentFrameLayout = (FrameLayout)FindViewById(Resource.Id.container); 
            LayoutInflater.Inflate(Resource.Layout.content_main1, contentFrameLayout);

            headingText.Text = Title;
        }

        override
      protected void OnStart()
        {
            base.OnStart();
            ((RadioButton)FindViewById(Resource.Id.tab_icon1)).Checked = true;
        }
    }
}

