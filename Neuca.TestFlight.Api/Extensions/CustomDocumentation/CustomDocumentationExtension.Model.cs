using System.Text;
using Neuca.TestFlight.Infrastructure;
using Newtonsoft.Json;

namespace Neuca.TestFlight.Api.Extensions.CustomDocumentation;

public static partial class CustomDocumentationExtension
{
    public static WebApplication CreateModelDocumentation(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<InMemoryDbContext>();


            var template = ModelHtmlTemplate.Template;
            var env = app.Services.GetRequiredService<IWebHostEnvironment>();

            var jsonString = dbContext.ExportDbContextToJson();

            File.WriteAllText(env.WebRootPath + "/EnitytModel.json", jsonString);

            List<InMemoryDbContext.Node>
                nodes = JsonConvert.DeserializeObject<List<InMemoryDbContext.Node>>(jsonString);

            var sb = new StringBuilder();
            foreach (var node in nodes)
            {
                sb.Append($"[<table>{node.Name} | ");

                foreach (var property in node.Properties)
                {
                    sb.Append(property.IsPrimaryKey ? "(PK) " : "")
                        .Append($"{property.PropertyName} | {property.PropertyType}")
                        .Append(property.IsNullable ? " (nullable)" : "")
                        .Append(" ||");
                }

                if (sb.Length > 3)
                    sb.Length -= 3;

                sb.Append("]");
                sb.Append("\\n");

                foreach (var foreignKey in node.ForeignKeys)
                {
                    sb.Append($"[{node.Name}] o-> [{foreignKey.PrincipalTable}]\\n");
                }

                sb.Append("\\n");
            }

            template = template.Replace("###TXT###", sb.ToString());

            Console.WriteLine(template);
            File.WriteAllText(env.WebRootPath + "/model.html", template);
            File.WriteAllText(env.WebRootPath + "/EntityModel.nomnoml", sb.ToString());

            return app;
        }
    }
}