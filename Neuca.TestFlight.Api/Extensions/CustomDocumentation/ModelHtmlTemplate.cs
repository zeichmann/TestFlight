namespace Neuca.TestFlight.Api.Extensions.CustomDocumentation;

public static class ModelHtmlTemplate
{
    public const string Template = @"
<script src=""//unpkg.com/graphre/dist/graphre.js""></script>
<script src=""//unpkg.com/nomnoml/dist/nomnoml.js""></script>
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
        canvas {
            width: 800px;            
            background-color: lightgray;
        }
    </style>
<canvas id=""target-canvas""></canvas>
<div style=""position:absolute; top:10px"">
<table width=100%><tr>
<td width=50%></td>
<td nowrap><a href=""/model.html""><b>Model</b></a></td><td>|<td>
<td nowrap><a href=""/data.html"">Seed Data</a></td><td>|<td> 
<td nowrap><a href=""/swagger"">Swagger</a></td>
<td width=50%></td>
</tr></table>

<br/><br/>

</div>
<script>
    var canvas = document.getElementById('target-canvas')
    var source = '###TXT###'
    
    nomnoml.draw(canvas, source)

</script>
    ";
}