using FluentEmail.Core.Interfaces;
using RazorLight;
using System.Threading.Tasks;

namespace GreenProject.Backend.Infrastructure.Notifications.Mail
{
    public class RazorRenderer : ITemplateRenderer
    {
        private readonly IRazorLightEngine _engine;

        public RazorRenderer(string path)
        {
            _engine = new RazorLightEngineBuilder()
                .UseFileSystemProject(path)
                .UseMemoryCachingProvider()
                .Build();
        }

        public async Task<string> ParseAsync<T>(string template, T model, bool isHtml = true)
        {
            string result = await _engine.CompileRenderStringAsync(template, template, model, new System.Dynamic.ExpandoObject());
            return result;
        }

        string ITemplateRenderer.Parse<T>(string template, T model, bool isHtml)
        {
            return ParseAsync(template, model, isHtml).GetAwaiter().GetResult();
        }
    }
}
