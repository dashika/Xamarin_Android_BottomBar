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
using Android.Graphics.Drawables;

namespace BottomBar
{
    [Activity(Label = "BaseActivity")]
    public class BaseActivity : Activity
    {
        MyBottomBar bottomBar;
        ImageView imgBack;
        protected TextView headingText;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            bottomBar = (MyBottomBar)FindViewById(Resource.Id.footer);
            imgBack = ((ImageView)FindViewById(Resource.Id.imgBack));
            headingText = ((TextView)FindViewById(Resource.Id.heading_text));
        }

        override
        protected void OnPause()
        {
            base.OnPause();
            bottomBar.OnChecked -= BottomBar_OnCheck;
            imgBack.Click -= ImgBack_Click;
        }

        override
        protected void OnResume()
        {
            base.OnResume();
            bottomBar.OnChecked += BottomBar_OnCheck;
            imgBack.Click += ImgBack_Click;
        }

        private void ImgBack_Click(object sender, EventArgs e)
        {
            base.OnBackPressed();
        }

        private void BottomBar_OnCheck(object source, MyEventArgs e)
        {
            Intent intent = new Intent();
            switch (e.GetRadioBtn().Id)
            {
                case Resource.Id.tab_icon1:
                    {
                        intent.SetClass(this, typeof(MainActivity));
                        break;
                    }
                case Resource.Id.tab_icon2:
                    {
                        intent.SetClass(this, typeof(Main2Activity));
                        break;
                    }
                case Resource.Id.tab_icon3:
                    {
                        intent.SetClass(this, typeof(Main3Activity));
                        break;
                    }
                case Resource.Id.tab_icon4:
                    {
                        intent.SetClass(this, typeof(Main4Activity));
                        break;
                    }
            }
            if (intent != null)
            {
                intent.SetFlags(ActivityFlags.NewTask | ActivityFlags.SingleTop);
                StartActivity(intent);
            }
        }
    }
}