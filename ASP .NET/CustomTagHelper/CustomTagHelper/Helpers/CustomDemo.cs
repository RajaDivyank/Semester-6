using Microsoft.AspNetCore.Razor.TagHelpers;
namespace APIDemo.Helpers
{
    [HtmlTargetElement("custom-demo")]
    public class CustomDemo:TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", "https://github.com/RajaDivyank");
            output.Content.SetContent("Linkdin");
        }
    }
}
