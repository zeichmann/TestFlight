using System.Text;
using Neuca.TestFlight.Infrastructure;

namespace Neuca.TestFlight.Api.Extensions.CustomDocumentation;

public static partial class CustomDocumentationExtension
{
    public static WebApplication CreateDataDocumentation(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<InMemoryDbContext>();

            var template = DataHtmlTemplate.Template;
            var env = app.Services.GetRequiredService<IWebHostEnvironment>();

            var sb = new StringBuilder();

            void AddTable<T>(string tableName, string header, IEnumerable<T> items, Func<T, string> selector)
            {
                sb.Append($"<table width=100%><tr><td width=50%></td><td>");
                sb.Append(
                    $"<table border=1 cellspacing=2 cellpadding=2><tr><td colspan='10' style='background-color: silver' align=middle><strong>{tableName}</strong></td><tr/>");
                sb.Append(header);
                foreach (var item in items)
                {
                    sb.Append($"<tr>{selector(item)}</tr>");
                }

                sb.Append("</tr></table>");
                sb.Append($"</td><td width=50%></td></tr></table>");
                sb.Append("<br/><br/>");
            }

            AddTable("FlightNumbers",
                "<tr><td class='bold'>Id</td><td class='bold'>Code</td><td class='bold'>From</td><td class='bold'>To</td><td>Continent</td><td class='bold'>AvailableDaysOfWeek</td>",
                dbContext.FlightNumbers, item =>
                    $"<td>{item.Id}</td><td>{item.Code}</td><td>{item.From}</td><td>{item.To}</td><td>{item.Continent}</td><td>{item.AvailableDaysOfWeek}</td>");

            AddTable("Flights",
                "<tr><td class='bold'>Id</td><td class='bold'>FlightId</td><td class='bold'>IndividualId</td><td class='bold'>FlightTime</td>",
                dbContext.Flights, item =>
                    $"<td>{item.Id}</td><td>{item.FlightId}</td><td>{item.IndividualId}</td><td>{item.FlightTime}</td>");

            AddTable("FlightPrices",
                "<tr><td class='bold'>Id</td><td class='bold'>DayOfWeek</td><td class='bold'>Hour</td><td class='bold'>FlightNumberId</td><td class='bold'>Price</td></tr>",
                dbContext.FlightPrices, item =>
                    $"<td>{item.Id}</td><td>{item.DayOfWeek}</td><td>{item.Hour}</td><td>{item.FlightNumberId}</td><td>{item.Price}</td>");

            AddTable("Tenants",
                "<tr><td class='bold'>Id</td><td class='bold'>Code</td><td class='bold'>DllReference</td><td class='bold'>FullServiceClassName</td></tr>",
                dbContext.Tenants, item =>
                    $"<td>{item.Id}</td><td>{item.Code}</td><td>{item.DllReference}</td><td>{item.FullServiceClassName}</td>");

            AddTable("Users",
                "<tr><td class='bold'>Id</td><td class='bold'>Nickname</td><td class='bold'>DateOfBirth</td></tr>",
                dbContext.NeucaUsers, item =>
                    $"<td>{item.Id}</td><td>{item.Nickname}</td><td>{item.DateOfBirth}</td>");

            template = template.Replace("###TXT###", sb.ToString());

            Console.WriteLine(template);
            File.WriteAllText(env.WebRootPath + "/data.html", template);
            return app;
        }
    }
}