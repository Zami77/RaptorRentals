#pragma checksum "D:\Blazor\RaptorRentals\Shared\MainLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a3f39ad5f715b5a0baf8046ec7858398aa2d963c"
// <auto-generated/>
#pragma warning disable 1591
namespace RaptorRentals.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Blazor\RaptorRentals\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Blazor\RaptorRentals\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Blazor\RaptorRentals\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Blazor\RaptorRentals\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Blazor\RaptorRentals\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Blazor\RaptorRentals\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Blazor\RaptorRentals\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Blazor\RaptorRentals\_Imports.razor"
using RaptorRentals;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Blazor\RaptorRentals\_Imports.razor"
using RaptorRentals.Shared;

#line default
#line hidden
#nullable disable
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "sidebar");
            __builder.OpenComponent<RaptorRentals.Shared.NavMenu>(2);
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(3, "\r\n\r\n");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "main");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "top-row px-4 auth");
            __builder.AddAttribute(8, "style", "z-index: 100");
            __builder.OpenComponent<RaptorRentals.Shared.LoginDisplay>(9);
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\r\n\r\n    ");
            __builder.OpenElement(11, "div");
            __builder.AddAttribute(12, "class", "content px-4");
            __builder.AddContent(13, 
#nullable restore
#line 13 "D:\Blazor\RaptorRentals\Shared\MainLayout.razor"
         Body

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
