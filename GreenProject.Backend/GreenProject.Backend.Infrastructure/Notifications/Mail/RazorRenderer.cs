using FluentEmail.Core.Interfaces;
using RazorLight;
using RazorLight.Razor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace GreenProject.Backend.Infrastructure.Notifications.Mail
{
    public class RazorRenderer : ITemplateRenderer
    {
		private readonly IRazorLightEngine engine;

		public RazorRenderer(string path)
		{
			engine = new RazorLightEngineBuilder()
				.UseFileSystemProject(path)
				.UseMemoryCachingProvider()
				.Build();
		}

		public async Task<string> ParseAsync<T>(string template, T model, bool isHtml = true)
		{
			string result = await engine.CompileRenderStringAsync(template, template, model, new System.Dynamic.ExpandoObject());
			return result;
		}

		string ITemplateRenderer.Parse<T>(string template, T model, bool isHtml)
		{
			return ParseAsync(template, model, isHtml).GetAwaiter().GetResult();
		}
	}
}
