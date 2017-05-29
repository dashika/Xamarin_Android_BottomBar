using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace BottomBar
{
    public class Tab : LinearLayout
    {

        private View root;
        private RadioButton imageView;
        private TextView textView;
        private Context context;
        private TabData tabData;

        public Tab(Context context) : base(context) { this.context = context; }

        public Tab(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            this.context = context;
        }

        public LinearLayout init(TabData tabData)
        {
            this.tabData = tabData;
            root = Inflate(context, Resource.Layout.tab, this);
            imageView = (RadioButton)root.FindViewById(Resource.Id.tab_icon);
            textView = (TextView)root.FindViewById(Resource.Id.tab_text);
            imageView.SetButtonDrawable(tabData.getIcon());

            textView.Text = (tabData.getText());

            return this;
        }

        public void check()
        {
            imageView.Checked = (!imageView.Checked);

        }

        public void go()
        {
            context.StartActivity(tabData.getIntent());
        }
    }
}