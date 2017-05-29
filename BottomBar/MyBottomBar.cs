


using System;
using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace BottomBar
{
    public delegate void MyEventHandler(object source, MyEventArgs e);

    public class MyEventArgs : EventArgs
    {
        private RadioButton EventRBChecked;

        public MyEventArgs(RadioButton radiobtn)
        {
            EventRBChecked = radiobtn;
        }

        public RadioButton GetRadioBtn()
        {
            return EventRBChecked;
        }
    }

    public class MyBottomBar : LinearLayout
    {

        View root;
        Context context;
        ViewGroup.LayoutParams param;
        public MyBottomBar(Context context) : base(context)
        {
            this.context = context;
            root = Inflate(context, Resource.Layout.bottom_bar, this);
            init();
        }

        public MyBottomBar(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            this.context = context;
            root = Inflate(context, Resource.Layout.bottom_bar, this);
            init();
        }


        public event MyEventHandler OnChecked;

        public void init()
        {
            RadioGroup radiogroup = (RadioGroup)root.FindViewById(Resource.Id.bottombar);
            radiogroup.CheckedChange += changeChecked;
            int countBtns = radiogroup.ChildCount;
            if (countBtns == 0) return;
            LinearLayout linearLayoutE = (LinearLayout)root.FindViewById(Resource.Id.example);
            param = linearLayoutE.LayoutParameters;
            DisplayMetrics dm = Resources.DisplayMetrics;
            int id = radiogroup.GetChildAt(0).Id;
            
            ((RadioButton)root.FindViewById(id)).Checked = true;
            param.Width = dm.WidthPixels / countBtns;
            for (int i = 0; i < countBtns; i++)
            {
                root.FindViewById(id++).LayoutParameters = param;
            }
        }

        private void changeChecked(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            if (OnChecked != null)
            {
                OnChecked(this, new MyEventArgs((RadioButton)FindViewById(e.CheckedId)));
            }
        }
        
        
    }
}