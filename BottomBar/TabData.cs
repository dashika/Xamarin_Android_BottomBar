using Android.Content;
using Android.Graphics.Drawables;
using System;

namespace BottomBar
{
    public class TabData
    {
        Drawable icon;
        String text;

        public Drawable getIcon()
        {
            return icon;
        }

        public TabData setIcon(Drawable icon)
        {
            this.icon = icon;
            return this;
        }

        public String getText()
        {
            return text;
        }

        public TabData setText(String text)
        {
            this.text = text;
            return this;
        }

        public Intent getIntent()
        {
            return intent;
        }

        public TabData setIntent(Intent intent)
        {
            this.intent = intent;
            return this;
        }

        Intent intent;

    }
}
