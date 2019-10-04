using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace NKN.Core.Extensions
{
	public static class HtmlHelperExtensions
	{
		public static MvcHtmlString Action<TController>(this HtmlHelper htmlHelper, Func<TController, string> actionNameFunc, object routeValues = null)
			where TController : Controller
		{
			if (actionNameFunc == null) throw new ArgumentNullException(nameof(actionNameFunc));

			var controllerName = typeof(TController).Name.RemoveControllerSuffix();
			var actionName = actionNameFunc(null);

			return htmlHelper.Action(actionName, controllerName, routeValues);
		}

		public static void RenderAction<TController>(this HtmlHelper htmlHelper, Func<TController, string> actionNameFunc, object routeValues = null)
			where TController : Controller
		{
			if (actionNameFunc == null) throw new ArgumentNullException(nameof(actionNameFunc));

			var controllerName = typeof(TController).Name.RemoveControllerSuffix();
			var actionName = actionNameFunc(null);

			htmlHelper.RenderAction(actionName, controllerName, routeValues);
		}
	}
}
