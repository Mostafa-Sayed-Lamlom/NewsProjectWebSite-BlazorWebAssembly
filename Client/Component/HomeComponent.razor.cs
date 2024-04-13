using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Client.Component
{
    public partial class HomeComponent
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> ImagAttribute { get; set; }
        [CascadingParameter]
        public string style { get; set; }
    }
}
