#pragma checksum "C:\Users\user\Documents\CoursePortal\CoursePortal\Views\Course\Courses.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "80a8e11b7d594e81060945e0438dcbd9906edd85"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Course_Courses), @"mvc.1.0.view", @"/Views/Course/Courses.cshtml")]
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
#line 1 "C:\Users\user\Documents\CoursePortal\CoursePortal\Views\_ViewImports.cshtml"
using CoursePortal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\Documents\CoursePortal\CoursePortal\Views\_ViewImports.cshtml"
using CoursePortal.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"80a8e11b7d594e81060945e0438dcbd9906edd85", @"/Views/Course/Courses.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71e9a5bf3baf4812d325d7cb392078ddacdbfb50", @"/Views/_ViewImports.cshtml")]
    public class Views_Course_Courses : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CoursePortal.Models.UserCourses>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("nav-link text-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Course", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AuthorIndex", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SubscriberIndex", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "C:\Users\user\Documents\CoursePortal\CoursePortal\Views\Course\Courses.cshtml"
  
    ViewData["Title"] = "Course Portal";

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"text-center\">\r\n        <h1 class=\"display-4\">Your Courses</h1>\r\n");
#nullable restore
#line 6 "C:\Users\user\Documents\CoursePortal\CoursePortal\Views\Course\Courses.cshtml"
         using (Html.BeginForm())
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"form-group\">\r\n                <label>Filter By:</label>\r\n                <div class=\"col-md-10\">\r\n                    ");
#nullable restore
#line 11 "C:\Users\user\Documents\CoursePortal\CoursePortal\Views\Course\Courses.cshtml"
               Write(Html.EditorFor(model => model.filterBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 12 "C:\Users\user\Documents\CoursePortal\CoursePortal\Views\Course\Courses.cshtml"
               Write(Html.ValidationMessageFor(model => model.filterBy, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n");
            WriteLiteral("            <div class=\"form-group\">\r\n                <div class=\"col-md-offset-2 col-md-10\">\r\n                    <input type=\"submit\" value=\"Filter courses\" class=\"btn btn-default\" />\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 21 "C:\Users\user\Documents\CoursePortal\CoursePortal\Views\Course\Courses.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        <div class=""navbar-collapse collapse d-sm-inline-flex flex-sm-row-reverse"">
            <table class=""table"">
                <tr>
                    <th>
                        Name
                    </th>

                    <th>
                        Description
                    </th>

                    <th>
                        Author Name
                    </th>

                    <th>
                        Subject
                    </th>
                    <th></th>
                </tr>
");
#nullable restore
#line 43 "C:\Users\user\Documents\CoursePortal\CoursePortal\Views\Course\Courses.cshtml"
                 foreach (var course in Model.courses)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 47 "C:\Users\user\Documents\CoursePortal\CoursePortal\Views\Course\Courses.cshtml"
                       Write(Html.DisplayFor(modelItem => course.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n\r\n                        <td>\r\n                            ");
#nullable restore
#line 51 "C:\Users\user\Documents\CoursePortal\CoursePortal\Views\Course\Courses.cshtml"
                       Write(Html.DisplayFor(modelItem => course.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n\r\n                        <td>\r\n                            ");
#nullable restore
#line 55 "C:\Users\user\Documents\CoursePortal\CoursePortal\Views\Course\Courses.cshtml"
                       Write(Html.DisplayFor(modelItem => course.AuthorName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n\r\n                        <td>\r\n                            ");
#nullable restore
#line 59 "C:\Users\user\Documents\CoursePortal\CoursePortal\Views\Course\Courses.cshtml"
                       Write(Html.DisplayFor(modelItem => course.SubjectName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n\r\n                        <td>\r\n");
#nullable restore
#line 63 "C:\Users\user\Documents\CoursePortal\CoursePortal\Views\Course\Courses.cshtml"
                             if (Model.user.isAuthor)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "C:\Users\user\Documents\CoursePortal\CoursePortal\Views\Course\Courses.cshtml"
                           Write(Html.ActionLink("Remove Course", "RemoveCourse", new { id = course.Id }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "C:\Users\user\Documents\CoursePortal\CoursePortal\Views\Course\Courses.cshtml"
                                                                                                         
                            }
                            else
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 69 "C:\Users\user\Documents\CoursePortal\CoursePortal\Views\Course\Courses.cshtml"
                           Write(Html.ActionLink("Unsubscribe", "Unsubscribe", new { id = course.Id }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 69 "C:\Users\user\Documents\CoursePortal\CoursePortal\Views\Course\Courses.cshtml"
                                                                                                      
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 73 "C:\Users\user\Documents\CoursePortal\CoursePortal\Views\Course\Courses.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </table>\r\n        </div>\r\n");
#nullable restore
#line 76 "C:\Users\user\Documents\CoursePortal\CoursePortal\Views\Course\Courses.cshtml"
         if (Model.user.isAuthor)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "80a8e11b7d594e81060945e0438dcbd9906edd8510915", async() => {
                WriteLiteral("Return back");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 79 "C:\Users\user\Documents\CoursePortal\CoursePortal\Views\Course\Courses.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "80a8e11b7d594e81060945e0438dcbd9906edd8512803", async() => {
                WriteLiteral("Return back");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 83 "C:\Users\user\Documents\CoursePortal\CoursePortal\Views\Course\Courses.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CoursePortal.Models.UserCourses> Html { get; private set; }
    }
}
#pragma warning restore 1591
