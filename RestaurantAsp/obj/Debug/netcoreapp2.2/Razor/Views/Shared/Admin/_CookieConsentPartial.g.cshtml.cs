#pragma checksum "/home/serg/projects/restaurant asp/RestaurantAsp/RestaurantAsp/Views/Shared/Admin/_CookieConsentPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fd8c2d2d07d75b0f470780d5f144a1fe8b3b732f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Admin__CookieConsentPartial), @"mvc.1.0.view", @"/Views/Shared/Admin/_CookieConsentPartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Admin/_CookieConsentPartial.cshtml", typeof(AspNetCore.Views_Shared_Admin__CookieConsentPartial))]
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
#line 1 "/home/serg/projects/restaurant asp/RestaurantAsp/RestaurantAsp/Views/Shared/Admin/_CookieConsentPartial.cshtml"
using Microsoft.AspNetCore.Http.Features;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd8c2d2d07d75b0f470780d5f144a1fe8b3b732f", @"/Views/Shared/Admin/_CookieConsentPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b4cdc74d4e88f070c4a50c49e852d71d62fdede", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Admin__CookieConsentPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(42, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 3 "/home/serg/projects/restaurant asp/RestaurantAsp/RestaurantAsp/Views/Shared/Admin/_CookieConsentPartial.cshtml"
  
    var consentFeature = Context.Features.Get<ITrackingConsentFeature>();
    var showBanner = !consentFeature?.CanTrack ?? false;
    var cookieString = consentFeature?.CreateConsentCookie();

#line default
#line hidden
            BeginContext(241, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 9 "/home/serg/projects/restaurant asp/RestaurantAsp/RestaurantAsp/Views/Shared/Admin/_CookieConsentPartial.cshtml"
 if (showBanner)
{

#line default
#line hidden
            BeginContext(261, 95, true);
            WriteLiteral("    <div id=\"cookieConsent\" class=\"alert alert-info alert-dismissible fade show\" role=\"alert\">\n");
            EndContext();
            BeginContext(508, 118, true);
            WriteLiteral("        <button type=\"button\" class=\"accept-policy close\" data-dismiss=\"alert\" aria-label=\"Close\" data-cookie-string=\"");
            EndContext();
            BeginContext(627, 12, false);
#line 13 "/home/serg/projects/restaurant asp/RestaurantAsp/RestaurantAsp/Views/Shared/Admin/_CookieConsentPartial.cshtml"
                                                                                                                 Write(cookieString);

#line default
#line hidden
            EndContext();
            BeginContext(639, 391, true);
            WriteLiteral(@""">
            <span aria-hidden=""true"">Accept</span>
        </button>
    </div>
    <script>
        (function () {
            var button = document.querySelector(""#cookieConsent button[data-cookie-string]"");
            button.addEventListener(""click"", function (event) {
                document.cookie = button.dataset.cookieString;
            }, false);
        })();
    </script>
");
            EndContext();
#line 25 "/home/serg/projects/restaurant asp/RestaurantAsp/RestaurantAsp/Views/Shared/Admin/_CookieConsentPartial.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
