#pragma checksum "D:\CaferiaApp\CaferiaApp\Views\WalletRequests\ContactUsIndex.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "25553154c77374f6e42f9eef4c95119c11552cd3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_WalletRequests_ContactUsIndex), @"mvc.1.0.view", @"/Views/WalletRequests/ContactUsIndex.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/WalletRequests/ContactUsIndex.cshtml", typeof(AspNetCore.Views_WalletRequests_ContactUsIndex))]
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
#line 1 "D:\CaferiaApp\CaferiaApp\Views\_ViewImports.cshtml"
using CaferiaApp;

#line default
#line hidden
#line 2 "D:\CaferiaApp\CaferiaApp\Views\_ViewImports.cshtml"
using CaferiaApp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"25553154c77374f6e42f9eef4c95119c11552cd3", @"/Views/WalletRequests/ContactUsIndex.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ebf370e69a26286caf214a6b82fc122cbb69603", @"/Views/_ViewImports.cshtml")]
    public class Views_WalletRequests_ContactUsIndex : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CaferiaApp.Models.ContactUs>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/vendor/datatable/js/jquery.dataTables.min.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/vendor/datatable/js/dataTables.bootstrap4.min.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 10, true);
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n");
            EndContext();
            BeginContext(59, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 8 "D:\CaferiaApp\CaferiaApp\Views\WalletRequests\ContactUsIndex.cshtml"
  
    ViewData["Title"] = "Contact Messages";

#line default
#line hidden
            BeginContext(113, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Css", async() => {
                BeginContext(129, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 13 "D:\CaferiaApp\CaferiaApp\Views\WalletRequests\ContactUsIndex.cshtml"
      await Html.RenderPartialAsync("_DataTableCssPartial");

#line default
#line hidden
            }
            );
            BeginContext(197, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Sole", async() => {
                BeginContext(214, 177, true);
                WriteLiteral("\r\n    <style>\r\n\r\n\r\n    \r\n        .table tr th {\r\n            text-align: center;\r\n        }\r\n\r\n        .table tr td {\r\n            text-align: center;\r\n        }\r\n    </style>\r\n");
                EndContext();
            }
            );
            BeginContext(394, 1434, true);
            WriteLiteral(@"
<div class=""container-fluid mt-4"">
    <div class=""card animated fadeIn overflow-hidden"">
        <div class=""card-header p-3"">
            <div class=""row align-items-center"">
                <div class=""col"">
                    <h3 class=""mb-0 skewed skewed-yellow text-dark d-inline-block text-uppercase ls-1"">Contact Messages</h3>
                </div>

            </div>
        </div>
        <div class=""card-body px-0 pb-2"">
            <div class=""table-responsive"">

                <table class=""table align-items-center  table-striped table-bordered"" id=""datatable-basic"">
                    <thead class=""thead-light"">
                        <tr>

                            <th>
                                S/L
                            </th>
                            <th>
                                Name
                            </th>
                            <th>
                                Email
                            </th>

                ");
            WriteLiteral(@"            <th>
                                Phone
                            </th>

                            <th>
                                Subject
                            </th>

                            <th>
                                Message
                            </th>


                        </tr>
                    </thead>
                    <tbody>
");
            EndContext();
#line 74 "D:\CaferiaApp\CaferiaApp\Views\WalletRequests\ContactUsIndex.cshtml"
                          
                            int i = 0;
                        

#line default
#line hidden
            BeginContext(1923, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 78 "D:\CaferiaApp\CaferiaApp\Views\WalletRequests\ContactUsIndex.cshtml"
                         foreach (var item in Model)
                        {
                            i++;

#line default
#line hidden
            BeginContext(2040, 110, true);
            WriteLiteral("                            <tr>\r\n\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(2151, 1, false);
#line 84 "D:\CaferiaApp\CaferiaApp\Views\WalletRequests\ContactUsIndex.cshtml"
                               Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(2152, 115, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(2268, 9, false);
#line 87 "D:\CaferiaApp\CaferiaApp\Views\WalletRequests\ContactUsIndex.cshtml"
                               Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(2277, 115, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(2393, 10, false);
#line 90 "D:\CaferiaApp\CaferiaApp\Views\WalletRequests\ContactUsIndex.cshtml"
                               Write(item.Email);

#line default
#line hidden
            EndContext();
            BeginContext(2403, 117, true);
            WriteLiteral("\r\n                                </td>\r\n\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(2521, 10, false);
#line 94 "D:\CaferiaApp\CaferiaApp\Views\WalletRequests\ContactUsIndex.cshtml"
                               Write(item.Phone);

#line default
#line hidden
            EndContext();
            BeginContext(2531, 166, true);
            WriteLiteral("\r\n                                </td>\r\n                               \r\n                                <td class=\"text-wrap\">\r\n                                    ");
            EndContext();
            BeginContext(2698, 12, false);
#line 98 "D:\CaferiaApp\CaferiaApp\Views\WalletRequests\ContactUsIndex.cshtml"
                               Write(item.Subject);

#line default
#line hidden
            EndContext();
            BeginContext(2710, 117, true);
            WriteLiteral("\r\n                                </td>\r\n\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(2828, 12, false);
#line 102 "D:\CaferiaApp\CaferiaApp\Views\WalletRequests\ContactUsIndex.cshtml"
                               Write(item.Message);

#line default
#line hidden
            EndContext();
            BeginContext(2840, 80, true);
            WriteLiteral("\r\n                                </td>\r\n\r\n\r\n                            </tr>\r\n");
            EndContext();
#line 107 "D:\CaferiaApp\CaferiaApp\Views\WalletRequests\ContactUsIndex.cshtml"
                        }

#line default
#line hidden
            BeginContext(2947, 122, true);
            WriteLiteral("                    </tbody>\r\n                </table>\r\n\r\n\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(3087, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(3093, 119, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "25553154c77374f6e42f9eef4c95119c11552cd311344", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
#line 120 "D:\CaferiaApp\CaferiaApp\Views\WalletRequests\ContactUsIndex.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3212, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(3218, 123, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "25553154c77374f6e42f9eef4c95119c11552cd313498", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
#line 121 "D:\CaferiaApp\CaferiaApp\Views\WalletRequests\ContactUsIndex.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3341, 56, true);
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n\r\n    </script>\r\n");
                EndContext();
#line 125 "D:\CaferiaApp\CaferiaApp\Views\WalletRequests\ContactUsIndex.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CaferiaApp.Models.ContactUs>> Html { get; private set; }
    }
}
#pragma warning restore 1591