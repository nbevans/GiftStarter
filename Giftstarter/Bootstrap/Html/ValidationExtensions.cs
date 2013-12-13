using System;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Giftstarter.Bootstrap.Html {
    public static class ValidationExtensions {
        public static MvcHtmlString ValidationAlert(this HtmlHelper htmlHelper) {
            var errors = htmlHelper.ViewData.ModelState
                                   .SelectMany(kv => kv.Value.Errors);

            var sb = new StringBuilder(1024);
            foreach (var error in errors) {
                sb.AppendLine("<li>" + HttpUtility.HtmlEncode(error.ErrorMessage) + "</li>");
            }

            var html = new TagBuilder("div") {
                Attributes = {
                    { "class", "validation-summary-errors" },
                    { "data-valmsg-summary", "true" }
                },
                InnerHtml = "<ul>" + sb + "</ul>"
            };

            return MvcHtmlString.Create(html.ToString());
        }
    }
}