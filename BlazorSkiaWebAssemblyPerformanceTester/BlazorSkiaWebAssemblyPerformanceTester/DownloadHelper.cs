using Microsoft.JSInterop;

namespace BlazorSkiaWebAssemblyPerformanceTester
{
    public class DownloadHelper
    {
        public static async Task SaveAs(IJSRuntime js, string filename, byte[] data)
        {
            await js.InvokeAsync<object>(
                "window.downloadFile",
                filename,
                Convert.ToBase64String(data));
        }
    }
}