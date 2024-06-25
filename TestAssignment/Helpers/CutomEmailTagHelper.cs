using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TestApplication.Helpers
{
    public class CutomEmailTagHelper : TagHelper
    {
        public string MyEmail { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", $"mailto:{MyEmail}");
            output.Attributes.Add("id","my-email-id");
            output.Content.SetContent("my-email");

        }
    }
}
