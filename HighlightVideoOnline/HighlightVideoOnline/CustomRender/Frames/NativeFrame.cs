using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HighlightVideoOnline.CustomRender.Frames
{
    public class NativeFrame : Frame
    {
        public NativeFrame()
        {
            TapGestureRecognizer frameTap = new TapGestureRecognizer();
            frameTap.Tapped += FrameTap_Tapped;
            GestureRecognizers.Add(frameTap);
        }

        private void FrameTap_Tapped(object sender, EventArgs e)
        {
           
        }
    }
}
