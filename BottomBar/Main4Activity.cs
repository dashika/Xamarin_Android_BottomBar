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
    [Activity(Label = "Main4Activity", LaunchMode = Android.Content.PM.LaunchMode.SingleTask)]
    public class Main4Activity : BaseActivity
    {
        private readonly String TAG4 = "TAG4";

        protected FragmentManager fragmentManager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            fragmentManager = FragmentManager;

            FrameLayout contentFrameLayout = (FrameLayout)FindViewById(Resource.Id.container);
            LayoutInflater.Inflate(Resource.Layout.content_main4, contentFrameLayout);

            Button btn = (Button)FindViewById(Resource.Id.btnActivity4_1);
            btn.Click += Btn_Click;

            Fragment fragment = fragmentManager.FindFragmentByTag(TAG4);
            if (fragment != null)
            {
                replaceFragment(fragment, TAG4);
            }

            headingText.Text = Title;
        }

        override
      protected void OnStart()
        {
            base.OnStart();
            ((RadioButton)FindViewById(Resource.Id.tab_icon4)).Checked = true;
        }


        private void replaceFragment(Fragment fragment, String tag)
        {
            FragmentTransaction transaction = fragmentManager.BeginTransaction();
            transaction.Add(Resource.Id.container, fragment, tag);
            transaction.AddToBackStack(tag);
            transaction.Commit();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            replaceFragment(new Fragment41(), TAG4);
        }
    }
}