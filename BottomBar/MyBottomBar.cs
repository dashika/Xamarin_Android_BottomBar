


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
        Tab clickedTab;
        /// <summary>
        ///   if actiivity will recreated (without saveinstance)
        /// </summary>
        private static int checked_tab = -1;

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
         
            //if (checked_tab == -1)
            //{
            //    checked_tab = id;
            //}
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
                checked_tab = e.CheckedId;
                OnChecked(this, new MyEventArgs((RadioButton)FindViewById(e.CheckedId)));
            }
        }

        /// <summary>
        /// For dynamic add tabs
        /// </summary>
        /// <param name="tabDatas"></param>
        public void init(TabData[] tabDatas)
        {
            root = Inflate(context, Resource.Layout.bottom_bar, this);
            RadioGroup linearLayout = (RadioGroup)root.FindViewById(Resource.Id.bottombar);
            LinearLayout linearLayoutE = (LinearLayout)root.FindViewById(Resource.Id.example);
            param = linearLayoutE.LayoutParameters;
            DisplayMetrics dm = Resources.DisplayMetrics;

            param.Width = dm.WidthPixels / tabDatas.Length;
            for (int i = 0; i < tabDatas.Length; i++)
            {
                Tab tab = new Tab(context);
                tab.init(tabDatas[i]);
                tab.LayoutParameters = (param);
                linearLayout.AddView(tab);
                tab.Click += tabCick;

                if (i == 0 && clickedTab == null)
                {
                    clickedTab = tab;
                }
            }

            void tabCick(object v, EventArgs e)
            {
                Tab tab = ((Tab)v);
                tab.check();
                tab.go();
                if (clickedTab != null) clickedTab.check();
                clickedTab = tab;
            }
        }
    }
}