#pragma checksum "C:\Users\thery\OneDrive - Ynov\Master 1\NET\projet hearthstone\hearthStoneDeckBuilder\Views\BuildDeck\dataFrames\hero_power.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f75bf76c3ccb53c4f1840f43a527d6e549d290da"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BuildDeck_dataFrames_hero_power), @"mvc.1.0.view", @"/Views/BuildDeck/dataFrames/hero_power.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/BuildDeck/dataFrames/hero_power.cshtml", typeof(AspNetCore.Views_BuildDeck_dataFrames_hero_power))]
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
#line 1 "C:\Users\thery\OneDrive - Ynov\Master 1\NET\projet hearthstone\hearthStoneDeckBuilder\Views\_ViewImports.cshtml"
using hearthStoneDeckBuilder;

#line default
#line hidden
#line 2 "C:\Users\thery\OneDrive - Ynov\Master 1\NET\projet hearthstone\hearthStoneDeckBuilder\Views\_ViewImports.cshtml"
using hearthStoneDeckBuilder.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f75bf76c3ccb53c4f1840f43a527d6e549d290da", @"/Views/BuildDeck/dataFrames/hero_power.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"06ae6452dcd2cfe392de7bd57543f61735f9d773", @"/Views/_ViewImports.cshtml")]
    public class Views_BuildDeck_dataFrames_hero_power : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<hearthStoneDeckBuilder.ViewModels.BuildDeckStatViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(65, 95, true);
            WriteLiteral("<h1 id=\"hero_power_title\" class=\"text-center\" style=\"display:none\">Sorts des Héros</h1>\r\n<table");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 160, "\"", 185, 1);
#line 3 "C:\Users\thery\OneDrive - Ynov\Master 1\NET\projet hearthstone\hearthStoneDeckBuilder\Views\BuildDeck\dataFrames\hero_power.cshtml"
WriteAttributeValue("", 165, Model.CardStat.Name, 165, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(186, 429, true);
            WriteLiteral(@" class=""table"" style=""display:none"" style=""display:none"">
    <thead>
        <tr>
            <th>
                Titre
            </th>
            <th>
                Classe
            </th>
            <th>
                Cout
            </th>
            <th>
                Rareté
            </th>
            <th>
                Image
            </th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 24 "C:\Users\thery\OneDrive - Ynov\Master 1\NET\projet hearthstone\hearthStoneDeckBuilder\Views\BuildDeck\dataFrames\hero_power.cshtml"
     foreach (HeroPowerCard card in Model.Cards) {

#line default
#line hidden
            BeginContext(667, 33, true);
            WriteLiteral("            <tr data-class-type=\"");
            EndContext();
            BeginContext(701, 14, false);
#line 25 "C:\Users\thery\OneDrive - Ynov\Master 1\NET\projet hearthstone\hearthStoneDeckBuilder\Views\BuildDeck\dataFrames\hero_power.cshtml"
                            Write(card.CardClass);

#line default
#line hidden
            EndContext();
            BeginContext(715, 46, true);
            WriteLiteral("\">\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(762, 9, false);
#line 27 "C:\Users\thery\OneDrive - Ynov\Master 1\NET\projet hearthstone\hearthStoneDeckBuilder\Views\BuildDeck\dataFrames\hero_power.cshtml"
               Write(card.Name);

#line default
#line hidden
            EndContext();
            BeginContext(771, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(839, 14, false);
#line 30 "C:\Users\thery\OneDrive - Ynov\Master 1\NET\projet hearthstone\hearthStoneDeckBuilder\Views\BuildDeck\dataFrames\hero_power.cshtml"
               Write(card.CardClass);

#line default
#line hidden
            EndContext();
            BeginContext(853, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(921, 9, false);
#line 33 "C:\Users\thery\OneDrive - Ynov\Master 1\NET\projet hearthstone\hearthStoneDeckBuilder\Views\BuildDeck\dataFrames\hero_power.cshtml"
               Write(card.Cost);

#line default
#line hidden
            EndContext();
            BeginContext(930, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(998, 11, false);
#line 36 "C:\Users\thery\OneDrive - Ynov\Master 1\NET\projet hearthstone\hearthStoneDeckBuilder\Views\BuildDeck\dataFrames\hero_power.cshtml"
               Write(card.Rarity);

#line default
#line hidden
            EndContext();
            BeginContext(1009, 230, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    <button class=\"\" onclick=\"popoverTest()\" data-container=\"body\" data-html=\"true\" data-toggle=\"popover\" data-placement=\"bottom\" data-content=\'<img height=\"400\" src=\"");
            EndContext();
            BeginContext(1240, 16, false);
#line 39 "C:\Users\thery\OneDrive - Ynov\Master 1\NET\projet hearthstone\hearthStoneDeckBuilder\Views\BuildDeck\dataFrames\hero_power.cshtml"
                                                                                                                                                                                  Write(card.LinkPicture);

#line default
#line hidden
            EndContext();
            BeginContext(1256, 119, true);
            WriteLiteral("\">\'>\r\n                        ouvrir l\'image\r\n                    </button>\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 44 "C:\Users\thery\OneDrive - Ynov\Master 1\NET\projet hearthstone\hearthStoneDeckBuilder\Views\BuildDeck\dataFrames\hero_power.cshtml"
    }

#line default
#line hidden
            BeginContext(1382, 22, true);
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<hearthStoneDeckBuilder.ViewModels.BuildDeckStatViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
