#pragma checksum "C:\Users\thery\OneDrive - Ynov\Master 1\NET\projet hearthstone\hearthStoneDeckBuilder\Views\BuildDeck\dataFrames\minion.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "61bd4ce362135899c779b9fa731614516a22fa65"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BuildDeck_dataFrames_minion), @"mvc.1.0.view", @"/Views/BuildDeck/dataFrames/minion.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/BuildDeck/dataFrames/minion.cshtml", typeof(AspNetCore.Views_BuildDeck_dataFrames_minion))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"61bd4ce362135899c779b9fa731614516a22fa65", @"/Views/BuildDeck/dataFrames/minion.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"06ae6452dcd2cfe392de7bd57543f61735f9d773", @"/Views/_ViewImports.cshtml")]
    public class Views_BuildDeck_dataFrames_minion : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<hearthStoneDeckBuilder.ViewModels.BuildDeckStatViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(65, 64, true);
            WriteLiteral("<h1 id=\"minion_title\" class=\"text-center\">Créatures</h1>\r\n<table");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 129, "\"", 154, 1);
#line 3 "C:\Users\thery\OneDrive - Ynov\Master 1\NET\projet hearthstone\hearthStoneDeckBuilder\Views\BuildDeck\dataFrames\minion.cshtml"
WriteAttributeValue("", 134, Model.CardStat.Name, 134, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(155, 507, true);
            WriteLiteral(@" class=""table"">
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
                Attaque
            </th>
            <th>
                Vie
            </th>
            <th>
                Image
            </th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 30 "C:\Users\thery\OneDrive - Ynov\Master 1\NET\projet hearthstone\hearthStoneDeckBuilder\Views\BuildDeck\dataFrames\minion.cshtml"
     foreach (MinionCard card in Model.Cards) {

#line default
#line hidden
            BeginContext(711, 33, true);
            WriteLiteral("            <tr data-class-type=\"");
            EndContext();
            BeginContext(745, 14, false);
#line 31 "C:\Users\thery\OneDrive - Ynov\Master 1\NET\projet hearthstone\hearthStoneDeckBuilder\Views\BuildDeck\dataFrames\minion.cshtml"
                            Write(card.CardClass);

#line default
#line hidden
            EndContext();
            BeginContext(759, 46, true);
            WriteLiteral("\">\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(806, 9, false);
#line 33 "C:\Users\thery\OneDrive - Ynov\Master 1\NET\projet hearthstone\hearthStoneDeckBuilder\Views\BuildDeck\dataFrames\minion.cshtml"
               Write(card.Name);

#line default
#line hidden
            EndContext();
            BeginContext(815, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(883, 14, false);
#line 36 "C:\Users\thery\OneDrive - Ynov\Master 1\NET\projet hearthstone\hearthStoneDeckBuilder\Views\BuildDeck\dataFrames\minion.cshtml"
               Write(card.CardClass);

#line default
#line hidden
            EndContext();
            BeginContext(897, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(965, 9, false);
#line 39 "C:\Users\thery\OneDrive - Ynov\Master 1\NET\projet hearthstone\hearthStoneDeckBuilder\Views\BuildDeck\dataFrames\minion.cshtml"
               Write(card.Cost);

#line default
#line hidden
            EndContext();
            BeginContext(974, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1042, 11, false);
#line 42 "C:\Users\thery\OneDrive - Ynov\Master 1\NET\projet hearthstone\hearthStoneDeckBuilder\Views\BuildDeck\dataFrames\minion.cshtml"
               Write(card.Rarity);

#line default
#line hidden
            EndContext();
            BeginContext(1053, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1121, 11, false);
#line 45 "C:\Users\thery\OneDrive - Ynov\Master 1\NET\projet hearthstone\hearthStoneDeckBuilder\Views\BuildDeck\dataFrames\minion.cshtml"
               Write(card.Attack);

#line default
#line hidden
            EndContext();
            BeginContext(1132, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1200, 11, false);
#line 48 "C:\Users\thery\OneDrive - Ynov\Master 1\NET\projet hearthstone\hearthStoneDeckBuilder\Views\BuildDeck\dataFrames\minion.cshtml"
               Write(card.Health);

#line default
#line hidden
            EndContext();
            BeginContext(1211, 230, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    <button class=\"\" onclick=\"popoverTest()\" data-container=\"body\" data-html=\"true\" data-toggle=\"popover\" data-placement=\"bottom\" data-content=\'<img height=\"400\" src=\"");
            EndContext();
            BeginContext(1442, 16, false);
#line 51 "C:\Users\thery\OneDrive - Ynov\Master 1\NET\projet hearthstone\hearthStoneDeckBuilder\Views\BuildDeck\dataFrames\minion.cshtml"
                                                                                                                                                                                  Write(card.LinkPicture);

#line default
#line hidden
            EndContext();
            BeginContext(1458, 119, true);
            WriteLiteral("\">\'>\r\n                        ouvrir l\'image\r\n                    </button>\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 56 "C:\Users\thery\OneDrive - Ynov\Master 1\NET\projet hearthstone\hearthStoneDeckBuilder\Views\BuildDeck\dataFrames\minion.cshtml"
    }

#line default
#line hidden
            BeginContext(1584, 22, true);
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