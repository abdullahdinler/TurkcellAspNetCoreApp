using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetCoreApp.Web.TagHelpers
{
    public class ImageThumbnailTagHelper:TagHelper
    {
        public string ImgUrl { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "img";
            string fileName = ImgUrl.Split(".")[0];
            string fileExtensions = Path.GetExtension(ImgUrl);
            output.Attributes.SetAttribute("src",$"{fileName}-100×100{fileExtensions}");
        }
    }
}
