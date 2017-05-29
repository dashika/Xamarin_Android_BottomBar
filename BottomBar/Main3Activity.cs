using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace BottomBar
{
    [Activity(Label = "Main3Activity", LaunchMode = Android.Content.PM.LaunchMode.SingleTask)]
    public class Main3Activity : BaseActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            FrameLayout contentFrameLayout = (FrameLayout)FindViewById(Resource.Id.container);
            LayoutInflater.Inflate(Resource.Layout.content_main3, contentFrameLayout);

            headingText.Text = Title;
        }

        override
      protected void OnStart()
        {
            base.OnStart();
            ((RadioButton)FindViewById(Resource.Id.tab_icon3)).Checked = true;
        }
    }
}