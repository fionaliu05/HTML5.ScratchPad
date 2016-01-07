using System.Web;
using System.Web.Mvc;

namespace HTML5.ScratchPad.Knockout.Require.DataGrid.Extensions
{
    /// <summary>
    /// Requires the folder structure for Scripts and Content to be 
    /// => Scripts - main.js at root level
    /// ==> app
    /// ==> lib
    /// ==> Content
    /// ===> app
    /// ===> lib
    /// </summary>
    public static class PathHelpers
    {
        public static string ScriptsPath(this HtmlHelper helper, string pathWithoutScripts)
        {
            var fullPath = "";
#if (DEBUG)
            var scriptsPath = "~/Scripts/";
            fullPath = VirtualPathUtility.ToAbsolute(scriptsPath + pathWithoutScripts);
#else
            var scriptsPath = "~/Scripts-Build/";
            fullPath = VirtualPathUtility.ToAbsolute(scriptsPath + pathWithoutScripts + "?v=" + helper.AssemblyRevisionNumber());
#endif
            return fullPath;
        }

        public static string ContentPath(this HtmlHelper helper, string pathWithoutContent)
        {
            var fullPath = "";
#if (DEBUG)
            var stylesPath = "~/Content/";
            fullPath = VirtualPathUtility.ToAbsolute(stylesPath + pathWithoutContent);
#else
            var stylesPath = "~/Content-Build/";
            fullPath = VirtualPathUtility.ToAbsolute(stylesPath + pathWithoutContent + "?v=" + helper.AssemblyRevisionNumber());
#endif
            return fullPath;
        }
    }
}