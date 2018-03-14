using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HighlightVideoOnline.DependencyServices
{
    public interface IContentVideoDependency
    {
       string DownloadUrl(string url);
    }
}
