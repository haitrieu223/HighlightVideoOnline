using HighlightVideoOnline.Models.Objects.Infos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HighlightVideoOnline.Models.Interfaces
{
    public interface ICategoryRepository
    {
        List<VideoInfo> GetListVideo();

    }
}
