using System;
using System.Collections.Generic;
using System.Text;

namespace HighlightVideoOnline.Commons
{
   public static class CommonFunc
    {
        public static TransitionType GetRandomTransitionType()
        {
            Random random = new Random();
            int index = random.Next((int)TransitionType.Fade, (int)TransitionType.SlideFromBottom);
            TransitionType trans = TransitionType.Fade;
            switch (index)
            {
                case (int)TransitionType.Fade:
                    trans = TransitionType.Fade;
                    break;
                case (int)TransitionType.Flip:
                    trans = TransitionType.Flip;
                    break;
                case (int)TransitionType.Scale:
                    trans = TransitionType.Scale;
                    break;
                case (int)TransitionType.SlideFromBottom:
                    trans = TransitionType.SlideFromBottom;
                    break;
                case (int)TransitionType.SlideFromLeft:
                    trans = TransitionType.SlideFromLeft;
                    break;
                case (int)TransitionType.SlideFromRight:
                    trans = TransitionType.SlideFromRight;
                    break;
                case (int)TransitionType.SlideFromTop:
                    trans = TransitionType.SlideFromTop;
                    break;
            }
            return trans;
        }
    }
}
