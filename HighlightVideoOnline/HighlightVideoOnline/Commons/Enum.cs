using System;
using System.Collections.Generic;
using System.Text;

namespace HighlightVideoOnline.Commons
{
    public enum EnumCategory
    {
        All = 0,
        NewMovie = 1,
        HotMovie = 2,
        OddMovie = 3,
        SeriesMovie = 4
    }

    public enum EnumTabMenu
    {
        Home = 1,
        History = 2,
        WatchLater = 3,
        Setting = 4
    }

    public enum EnumTypeVideo
    {
        All = -1,
        Wwe = 0,
        Soccer = 1,
        Game = 2,
        Mma =3
    }

    public enum TransitionType
    {
        Fade,
        Flip,
        Scale,
        SlideFromLeft,
        SlideFromRight,
        SlideFromTop,
        SlideFromBottom
    }
}
