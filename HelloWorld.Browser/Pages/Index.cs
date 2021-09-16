using DotNetForHtml5;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using HelloWorld.Browser.Interop;

namespace HelloWorld.Browser.Pages
{
    [Route("/")]
    public class Index : ComponentBase
    {
        protected override void BuildRenderTree(RenderTreeBuilder __builder)
        {
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            var runtime = new UnmarshalledJavaScriptExecutionHandler(this.JSRuntime);
            Cshtml5Initializer.Initialize(runtime);
            Program.RunApplication();
        }

        [Inject]
        private IJSRuntime JSRuntime { get; set; }
    }
}
