#pragma checksum "D:\WIT praca dyplomowa\ProPosecco\ProPosecco\ProPosecco\Views\Administrator\ManageUsers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "210bd1da731dc37944662800b76cf4f2c02049e6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Administrator_ManageUsers), @"mvc.1.0.view", @"/Views/Administrator/ManageUsers.cshtml")]
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
#nullable restore
#line 1 "D:\WIT praca dyplomowa\ProPosecco\ProPosecco\ProPosecco\Views\_ViewImports.cshtml"
using ProPosecco;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"210bd1da731dc37944662800b76cf4f2c02049e6", @"/Views/Administrator/ManageUsers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"460cb5c7f92df98e8a7d9b4aa226fa947d1ffed9", @"/Views/_ViewImports.cshtml")]
    public class Views_Administrator_ManageUsers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ICollection<ProProsecco.Models.User.UserGetModelAdminView>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary py-2 w-100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger py-2 w-100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\WIT praca dyplomowa\ProPosecco\ProPosecco\ProPosecco\Views\Administrator\ManageUsers.cshtml"
  
    ViewData["Title"] = "Zarządzanie użytkownikami";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"row my-5 text-center\">\r\n        <div class=\"col-12 py-3\">\r\n            <h3 class=\"border-bottom-gold d-block w-50 mx-auto py-3\">Panel użytkowników</h3>\r\n        </div>\r\n        <div class=\"col-12 my-3\">\r\n");
#nullable restore
#line 13 "D:\WIT praca dyplomowa\ProPosecco\ProPosecco\ProPosecco\Views\Administrator\ManageUsers.cshtml"
             if (Model.Count > 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <table class=""table table-striped px-3 w-100"">
                    <tr>
                        <th class=""align-middle"" scope=""col"">Imię</th>
                        <th class=""align-middle"" scope=""col"">Nazwisko</th>
                        <th class=""align-middle"" scope=""col"">Miasto</th>
                        <th class=""align-middle"" scope=""col"">Email</th>
                        <th class=""align-middle"" scope=""col"">[Zobacz] </th>
                        <th class=""align-middle"" scope=""col"">[Usuń]</th>
                    </tr>

");
#nullable restore
#line 25 "D:\WIT praca dyplomowa\ProPosecco\ProPosecco\ProPosecco\Views\Administrator\ManageUsers.cshtml"
                     foreach (var user in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td class=\"align-middle\">");
#nullable restore
#line 28 "D:\WIT praca dyplomowa\ProPosecco\ProPosecco\ProPosecco\Views\Administrator\ManageUsers.cshtml"
                                                Write(user.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"align-middle\">");
#nullable restore
#line 29 "D:\WIT praca dyplomowa\ProPosecco\ProPosecco\ProPosecco\Views\Administrator\ManageUsers.cshtml"
                                                Write(user.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"align-middle\">\r\n");
#nullable restore
#line 31 "D:\WIT praca dyplomowa\ProPosecco\ProPosecco\ProPosecco\Views\Administrator\ManageUsers.cshtml"
                                 if (user.City != null)
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "D:\WIT praca dyplomowa\ProPosecco\ProPosecco\ProPosecco\Views\Administrator\ManageUsers.cshtml"
                               Write(user.City);

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "D:\WIT praca dyplomowa\ProPosecco\ProPosecco\ProPosecco\Views\Administrator\ManageUsers.cshtml"
                                              
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span>-</span>\r\n");
#nullable restore
#line 38 "D:\WIT praca dyplomowa\ProPosecco\ProPosecco\ProPosecco\Views\Administrator\ManageUsers.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </td>\r\n                            <td class=\"align-middle\">");
#nullable restore
#line 40 "D:\WIT praca dyplomowa\ProPosecco\ProPosecco\ProPosecco\Views\Administrator\ManageUsers.cshtml"
                                                Write(user.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"align-middle\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "210bd1da731dc37944662800b76cf4f2c02049e68735", async() => {
                WriteLiteral("Zobacz");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 42 "D:\WIT praca dyplomowa\ProPosecco\ProPosecco\ProPosecco\Views\Administrator\ManageUsers.cshtml"
                                                                                                               WriteLiteral(user.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </td>\r\n                            <td class=\"align-middle\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "210bd1da731dc37944662800b76cf4f2c02049e611388", async() => {
                WriteLiteral("Usuń");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 45 "D:\WIT praca dyplomowa\ProPosecco\ProPosecco\ProPosecco\Views\Administrator\ManageUsers.cshtml"
                                                                                                                 WriteLiteral(user.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 48 "D:\WIT praca dyplomowa\ProPosecco\ProPosecco\ProPosecco\Views\Administrator\ManageUsers.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </table>\r\n");
#nullable restore
#line 50 "D:\WIT praca dyplomowa\ProPosecco\ProPosecco\ProPosecco\Views\Administrator\ManageUsers.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h3 class=\"text-center text-red-normal py-5\">Nie ma żadnych użytkowników w bazie</h3>\r\n");
#nullable restore
#line 54 "D:\WIT praca dyplomowa\ProPosecco\ProPosecco\ProPosecco\Views\Administrator\ManageUsers.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ICollection<ProProsecco.Models.User.UserGetModelAdminView>> Html { get; private set; }
    }
}
#pragma warning restore 1591