namespace Neuca.TestFlight.Api.Extensions.CustomDocumentation;

public static class DataHtmlTemplate
{
    public const string Template = @"
    <style>
        body, html {
            font-family: Arial;
            height: auto;
            margin: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            background-color: lightgray;
        }

        td {
            white-space: nowrap;
        }

        .bold {
        font-weight: bold;
            }
        .size {
            font-size: 12px !important;            
           }
    </style>
<html>

<body class='size'>

<div>
<table width=100%><tr>
<td width=50%></td>
<td nowrap><a href=""/model.html"">Model</a></td><td>|<td>
<td nowrap><a href=""/data.html""><b>Seed Data</b></a></td><td>|<td> 
<td nowrap><a href=""/swagger"">Swagger</a></td>
<td width=50%></td>
</tr></table>

<br/><br/>

###TXT###
</div>
</body>
</html>
";
}