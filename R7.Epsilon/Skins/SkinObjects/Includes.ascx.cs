using System;
using DotNetNuke.Web.Client;
using DotNetNuke.Web.Client.ClientResourceManagement;
using DotNetNuke.Framework.JavaScriptLibraries;
using R7.Epsilon.Components;
using R7.Dnn.Extensions.Client;

namespace R7.Epsilon.Skins.SkinObjects
{
    public class Includes: EpsilonSkinObjectBase
    {
        // TODO: Move to OnInit?
        protected override void OnLoad (EventArgs e)
        {
            ClientResourceManager.RegisterStyleSheet (Page, Const.SKIN_PATH + "css/bootstrap.min.css", (int) FileOrder.Css.SkinCss, "DnnPageHeaderProvider", "bootstrap", "4.6.0");

            var fontAwesome = JavaScriptLibraryHelper.GetHighestVersionLibrary ("FontAwesome");
            if (fontAwesome != null) {
                JavaScriptLibraryHelper.RegisterStyleSheet (fontAwesome,
                    Page, "css/all.min.css", (int) FileOrder.Css.SkinCss, "DnnPageHeaderProvider", "font-awesome");
            }

            JavaScript.RequestRegistration ("jQuery-BlueimpGallery");
            var blueimpLibrary = JavaScriptLibraryHelper.GetHighestVersionLibrary ("jQuery-BlueimpGallery");
            if (blueimpLibrary != null) {
                JavaScriptLibraryHelper.RegisterStyleSheet (blueimpLibrary,
                    Page, "css/blueimp-gallery.min.css", (int) FileOrder.Css.SkinCss, "DnnPageHeaderProvider", "blueimp-gallery");
            }

            ClientResourceManager.RegisterScript (Page, Const.SKIN_PATH + "js/bootstrap.bundle.min.js", (int) FileOrder.Js.DefaultPriority, "DnnFormBottomProvider", "bootstrap", "4.6.0");

            ClientResourceManager.RegisterScript (Page, Const.SKIN_PATH + "js/skin.min.js", (int) FileOrder.Js.DefaultPriority, "DnnFormBottomProvider", "skin", "0.0.0");

            ClientResourceManager.RegisterScript (Page, Const.SKIN_PATH + "js/clipboard.min.js", (int) FileOrder.Js.DefaultPriority, "DnnFormBottomProvider", "clipboard", "2.0.4");

            ClientResourceManager.RegisterScript (Page, Const.SKIN_PATH + "js/shortList.min.js", (int) FileOrder.Js.DefaultPriority, "DnnFormBottomProvider", "shortList", "0.0.0");

            if (!Skin.Options.DisableLazyAds) {
                JavaScript.RequestRegistration ("LazyAds");
            }
        }
    }
}
