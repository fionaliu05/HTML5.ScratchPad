using System;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace HTML5.ScratchPad.Knockout.Require.DataGrid.Extensions
{
    /// <summary>
    /// 
    /// MVC Helpers for to integrate RequireJS for finding Scripts folders whether they are at Root ("/") or ("Deep/Within/The/Site")
    /// Taken from: 
    /// src: http://volaresystems.com/blog/post/2014/05/27/Adding-RequireJS-to-an-ASPNET-MVC-project 
    /// It allows us to have loaded on every page: 1) require.js, 2) main.js, 3) the DOM
    /// Has the following dependencies
    /// - RequireJS
    /// - DomReady - http://requirejs.org/docs/download.html
    /// - main.js under Scripts
    /// </summary>
    public static class RequireJsHelpers
    {
        public static MvcHtmlString InitPageMainModule(this HtmlHelper helper, string pageModule)
        {
            var require = new StringBuilder();

#if (DEBUG)
            var scriptsPath = "~/Scripts/";
#else
            var scriptsPath = "~/Scripts-Build/";
#endif

            var absolutePath = VirtualPathUtility.ToAbsolute(scriptsPath);

            require.AppendLine("<script>");
#if (DEBUG)
            require.AppendFormat("    require([\"{0}main.js\"]," + Environment.NewLine, absolutePath);
#else
            require.AppendFormat("    require([\"{0}main.js?v={1}\"]," + Environment.NewLine, absolutePath, helper.AssemblyRevisionNumber());
#endif
            require.AppendLine("        function() {");
            require.AppendFormat("            require([\"{0}\", \"domReady!\"]);" + Environment.NewLine, pageModule);
            require.AppendLine("        }");
            require.AppendLine("    );");
            require.AppendLine("</script>");

            return new MvcHtmlString(require.ToString());
        }
    }
}