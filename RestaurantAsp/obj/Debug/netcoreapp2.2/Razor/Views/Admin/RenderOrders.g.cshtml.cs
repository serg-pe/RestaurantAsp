#pragma checksum "/home/serg/projects/restaurant asp/RestaurantAsp/RestaurantAsp/Views/Admin/RenderOrders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1a1b9301d3fb07631ad769cabd9f52b4a217082b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_RenderOrders), @"mvc.1.0.view", @"/Views/Admin/RenderOrders.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/RenderOrders.cshtml", typeof(AspNetCore.Views_Admin_RenderOrders))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "/home/serg/projects/restaurant asp/RestaurantAsp/RestaurantAsp/Views/_ViewImports.cshtml"
using RestaurantAsp;

#line default
#line hidden
#line 2 "/home/serg/projects/restaurant asp/RestaurantAsp/RestaurantAsp/Views/_ViewImports.cshtml"
using RestaurantAsp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1a1b9301d3fb07631ad769cabd9f52b4a217082b", @"/Views/Admin/RenderOrders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b4cdc74d4e88f070c4a50c49e852d71d62fdede", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_RenderOrders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IList<Order>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/ajax.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(20, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 3 "/home/serg/projects/restaurant asp/RestaurantAsp/RestaurantAsp/Views/Admin/RenderOrders.cshtml"
  
    ViewBag.Title = "title";
    Layout = "Admin/_Layout";

#line default
#line hidden
            BeginContext(85, 436, true);
            WriteLiteral(@"
<div>
    <h2>Заказы</h2>
    <input type=""hidden""/>
    <div>
        <table class=""table table-striped"">
            <thead class=""font-weight-bold"">
            <tr>
                <td>Активность</td>
                <td>Дата заказа</td>
                <td>Телефон</td>
                <td>Адрес</td>
                <td>Блюда</td>
                <td></td>
            </tr>
            </thead>
            
            <tbody>
");
            EndContext();
#line 25 "/home/serg/projects/restaurant asp/RestaurantAsp/RestaurantAsp/Views/Admin/RenderOrders.cshtml"
             foreach (var order in Model)
            {

#line default
#line hidden
            BeginContext(577, 44, true);
            WriteLiteral("                <tr>\n                    <td");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 621, "\"", 644, 2);
            WriteAttributeValue("", 626, "activity_", 626, 9, true);
#line 28 "/home/serg/projects/restaurant asp/RestaurantAsp/RestaurantAsp/Views/Admin/RenderOrders.cshtml"
WriteAttributeValue("", 635, order.Id, 635, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(645, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(647, 14, false);
#line 28 "/home/serg/projects/restaurant asp/RestaurantAsp/RestaurantAsp/Views/Admin/RenderOrders.cshtml"
                                           Write(order.IsActive);

#line default
#line hidden
            EndContext();
            BeginContext(661, 30, true);
            WriteLiteral("</td>\n                    <td>");
            EndContext();
            BeginContext(692, 10, false);
#line 29 "/home/serg/projects/restaurant asp/RestaurantAsp/RestaurantAsp/Views/Admin/RenderOrders.cshtml"
                   Write(order.Date);

#line default
#line hidden
            EndContext();
            BeginContext(702, 30, true);
            WriteLiteral("</td>\n                    <td>");
            EndContext();
            BeginContext(733, 26, false);
#line 30 "/home/serg/projects/restaurant asp/RestaurantAsp/RestaurantAsp/Views/Admin/RenderOrders.cshtml"
                   Write(order.Customer.PhoneNumber);

#line default
#line hidden
            EndContext();
            BeginContext(759, 30, true);
            WriteLiteral("</td>\n                    <td>");
            EndContext();
            BeginContext(790, 22, false);
#line 31 "/home/serg/projects/restaurant asp/RestaurantAsp/RestaurantAsp/Views/Admin/RenderOrders.cshtml"
                   Write(order.Customer.Address);

#line default
#line hidden
            EndContext();
            BeginContext(812, 60, true);
            WriteLiteral("</td>\n                    <td>\n                        <ul>\n");
            EndContext();
#line 34 "/home/serg/projects/restaurant asp/RestaurantAsp/RestaurantAsp/Views/Admin/RenderOrders.cshtml"
                             foreach (var position in order.OrderPositions)
                            {

#line default
#line hidden
            BeginContext(978, 36, true);
            WriteLiteral("                                <li>");
            EndContext();
            BeginContext(1015, 26, false);
#line 36 "/home/serg/projects/restaurant asp/RestaurantAsp/RestaurantAsp/Views/Admin/RenderOrders.cshtml"
                               Write(position.Dish.Denomination);

#line default
#line hidden
            EndContext();
            BeginContext(1041, 2, true);
            WriteLiteral(": ");
            EndContext();
            BeginContext(1044, 17, false);
#line 36 "/home/serg/projects/restaurant asp/RestaurantAsp/RestaurantAsp/Views/Admin/RenderOrders.cshtml"
                                                            Write(position.Portions);

#line default
#line hidden
            EndContext();
            BeginContext(1061, 6, true);
            WriteLiteral("</li>\n");
            EndContext();
#line 37 "/home/serg/projects/restaurant asp/RestaurantAsp/RestaurantAsp/Views/Admin/RenderOrders.cshtml"
                            }

#line default
#line hidden
            BeginContext(1097, 81, true);
            WriteLiteral("                        </ul>\n                    </td>\n                    <td>\n");
            EndContext();
#line 41 "/home/serg/projects/restaurant asp/RestaurantAsp/RestaurantAsp/Views/Admin/RenderOrders.cshtml"
                         if (order.IsActive)
                        {

#line default
#line hidden
            BeginContext(1249, 80, true);
            WriteLiteral("                            <button class=\"btn btn-link\" type=\"button\" data-id=\"");
            EndContext();
            BeginContext(1330, 8, false);
#line 43 "/home/serg/projects/restaurant asp/RestaurantAsp/RestaurantAsp/Views/Admin/RenderOrders.cshtml"
                                                                           Write(order.Id);

#line default
#line hidden
            EndContext();
            BeginContext(1338, 20, true);
            WriteLiteral("\">Готов</button>   \n");
            EndContext();
#line 44 "/home/serg/projects/restaurant asp/RestaurantAsp/RestaurantAsp/Views/Admin/RenderOrders.cshtml"
                        }

#line default
#line hidden
            BeginContext(1384, 48, true);
            WriteLiteral("                    </td>\n                </tr>\n");
            EndContext();
#line 47 "/home/serg/projects/restaurant asp/RestaurantAsp/RestaurantAsp/Views/Admin/RenderOrders.cshtml"
            }

#line default
#line hidden
            BeginContext(1446, 57, true);
            WriteLiteral("            </tbody>\n        </table>\n    </div>\n</div>\n\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1521, 5, true);
                WriteLiteral("\n    ");
                EndContext();
                BeginContext(1526, 36, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1a1b9301d3fb07631ad769cabd9f52b4a217082b9734", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1562, 657, true);
                WriteLiteral(@"
    <script>
        $(document).ready(function() {
            $(""button"").click(function() {
                var btn = $(this);
                console.log(btn.attr('data-id'));
                send_ajax(
                    'get',
                    '/admin/orders/done/' + btn.attr('data-id'),
                    '',
                    function(response) {
                        $('#activity_' + btn.attr('data-id')).text(""False"");
                        btn.remove();
                    },
                    function() {
                        alert(""Операция не выполнена"");
                    });
            });
        })
    </script>
");
                EndContext();
            }
            );
            BeginContext(2221, 1, true);
            WriteLiteral("\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IList<Order>> Html { get; private set; }
    }
}
#pragma warning restore 1591
