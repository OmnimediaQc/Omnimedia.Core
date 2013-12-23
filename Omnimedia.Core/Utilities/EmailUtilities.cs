using System;
using System.IO;
using System.Web.Mvc;

namespace Omnimedia.Core.Utilities
{
    public static class EmailUtilities
    {
        /// <summary>
        /// Renders the view to string.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public static string RenderViewToString(this Controller controller, string viewName, object model)
        {
            try
            {
                controller.ViewData.Model = model;
                using (var sw = new StringWriter())
                {
                    ControllerContext controllerContext = controller.ControllerContext;
                    ViewEngineResult viewResult = ViewEngines.Engines.FindView(controllerContext, viewName, null);
                    ViewContext viewContext = new ViewContext(controllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
                    viewResult.View.Render(viewContext, sw);
                    viewResult.ViewEngine.ReleaseView(controllerContext, viewResult.View);
                    return sw.ToString();
                }
            }
            catch (Exception exception)
            {
                return null;
            }
        }
    }
}