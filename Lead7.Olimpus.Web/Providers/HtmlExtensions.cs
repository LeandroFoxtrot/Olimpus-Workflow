using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace Lead7.Olimpus.Web.Providers
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString RadioButtonForEnum<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var names = Enum.GetNames(metaData.ModelType);
            var sb = new StringBuilder();
            foreach (var name in names)
            {
                var id = string.Format("{0}_{1}_{2}", htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix, metaData.PropertyName, name);
                var radio = htmlHelper.RadioButtonFor(expression, name, new { id = id }).ToHtmlString();
                sb.AppendFormat("{0} <label for=\"{1}\" style=\"padding-right: 20px\">{2}</label>", radio, id, HttpUtility.HtmlEncode(name));
            }
            return MvcHtmlString.Create(sb.ToString());
        }

        public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression)
        {
            return DropDownListForEnum(htmlHelper, expression, null);
        }

        public static MvcHtmlString DropDownListForEnum<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, object htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            Type enumType = GetNonNullableModelType(metadata);
            IEnumerable<TEnum> values = Enum.GetValues(enumType).Cast<TEnum>();
            IEnumerable<SelectListItem> items = from value in values
                                                select new SelectListItem
                                                {
                                                    Text = GetEnumDescription(value),
                                                    Value = value.ToString(),
                                                    Selected = value.Equals(metadata.Model)
                                                };

            return htmlHelper.DropDownListFor(expression, items, htmlAttributes);
        }

        public static MvcHtmlString ImageLink(this HtmlHelper html, string action, string controller, object routeValues, string imagePath, string alt)
        {
            var url = new UrlHelper(html.ViewContext.RequestContext);
            var imgBuilder = new TagBuilder("img");

            imgBuilder.MergeAttribute("src", url.Content(imagePath));
            imgBuilder.MergeAttribute("alt", alt);

            var imgHtml = imgBuilder.ToString(TagRenderMode.SelfClosing);
            var anchorBuilder = new TagBuilder("a");

            anchorBuilder.MergeAttribute("href", url.Action(action, controller, routeValues));
            anchorBuilder.InnerHtml = imgHtml + alt;

            var anchorHtml = anchorBuilder.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(anchorHtml);
        }

        public static string GetEnumDescription<TEnum>(TEnum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if ((attributes != null) && (attributes.Length > 0)) return attributes[0].Description;
            else return value.ToString();
        }

        public static MvcHtmlString FilePicker(this HtmlHelper htmlHelper, string name)
        {
            return htmlHelper.FilePicker(name, null);
        }

        public static MvcHtmlString FilePicker(this HtmlHelper html, string name, object htmlAttributes)
        {
            return html.FilePicker(name, FilterFileType.AllFiles, htmlAttributes);
        }

        public static MvcHtmlString FilePicker(this HtmlHelper html, string name, FilterFileType filter, object htmlAttributes)
        {
            IDictionary<string, object> attrs = new RouteValueDictionary(htmlAttributes);

            var tag = new TagBuilder("input");

            tag.MergeAttribute("type", "file");
            tag.MergeAttribute("name", name);

            var accept = string.Empty;

            switch (filter)
            {
                case FilterFileType.AllFiles: break;
                case FilterFileType.Audio: accept = @"audio/*"; break;
                case FilterFileType.Video: accept = @"video/*"; break;
                case FilterFileType.Image: accept = @"image/*"; break;
                case FilterFileType.MIME_type: accept = @"MIME_type/*"; break;
            }

            if (filter != FilterFileType.AllFiles)
            {
                tag.MergeAttribute("accept", accept);
            }

            if (attrs.Any()) tag.MergeAttributes(attrs);

            tag.MergeAttribute("data-buttonText", Resources.Empresa.Procurar);

            return MvcHtmlString.Create(tag.ToString(TagRenderMode.SelfClosing));
        }

        private static Type GetNonNullableModelType(ModelMetadata modelMetadata)
        {
            Type realModelType = modelMetadata.ModelType;
            Type underlyingType = Nullable.GetUnderlyingType(realModelType);
            if (underlyingType != null)
            {
                realModelType = underlyingType;
            }
            return realModelType;
        }
    }

    public enum FilterFileType
    {
        /// <summary>
        /// All files Only
        /// </summary>
        AllFiles = 0,
        /// <summary>
        /// Audio Files appear in the "Files of type" box
        /// </summary>
        Audio = 0x0001,
        /// <summary>
        /// Video Files appear in the "Files of type" box
        /// </summary>
        Video = 0x0010,
        /// <summary>
        /// Image Files appear in the "Files of type" box
        /// </summary>
        Image = 0x0100,
        /// <summary>
        /// MIME Files appear in the "Files of type" box
        /// </summary>
        MIME_type = 0x1000
    }
}