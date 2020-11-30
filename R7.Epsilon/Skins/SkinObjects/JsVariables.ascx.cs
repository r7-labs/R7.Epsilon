using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Users;
using DotNetNuke.Entities.Portals;
using R7.Epsilon.Components;
using R7.Epsilon.Models;

namespace R7.Epsilon.Skins.SkinObjects
{
    public class JsVariables: EpsilonSkinObjectBase
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings {
            ContractResolver = new CamelCasePropertyNamesContractResolver ()
            #if DEBUG
            , Formatting = Formatting.Indented
            #endif
        };

        protected string ClientVars => JsonConvert.SerializeObject (new ClientVars {
            ActiveTabId = ActiveTab.TabID,
            PortalAlias = PortalSettings.Current.PortalAlias.HTTPAlias,
            EnablePopups = PortalSettings.EnablePopUps,
            InPopup = UrlUtils.InPopUp (),
            CookiePrefix = Const.COOKIE_PREFIX,
            IsEditMode = PortalSettings.UserMode == PortalSettings.Mode.Edit,
            FeedbackUrl = Globals.NavigateURL (Config.Feedback.TabId),
            FeedbackTabId = Config.Feedback.TabId,
            FeedbackModuleId = Config.Feedback.ModuleId,
            IsSuperUser = GetIsSuperUser (),
            IsAdmin = GetIsAdmin (),
            QueryParams = GetQueryParams (),
            DefaultThemeName = Config.Themes [0].Name,
            Themes = GetThemes (),
            Resources = GetResources ()
        }, _jsonSerializerSettings);

        IDictionary<string, string> GetResources ()
        {
            return new Dictionary<string, string> {
                {"feedbackMessageTemplate", T.GetString ("Feedback_MessageTemplate.Text")},
                {"notSpecified", T.GetString ("NotSpecified.Text")}
            };
        }

        IDictionary<string, object> GetThemes ()
        {
            var themesDict = new Dictionary<string, object> ();
            foreach (var theme in Config.Themes) {
                themesDict.Add (theme.Name, theme);
            }
            return themesDict;
        }

        IDictionary<string, string> GetQueryParams ()
        {
            var queryStringDict = new Dictionary<string, string> ();
            foreach (string key in Request.QueryString.Keys) {
                queryStringDict.Add (key, Request.QueryString [key]);
            }
            return queryStringDict;
        }

        bool GetIsSuperUser ()
        {
            if (Request.IsAuthenticated) {
                var user = UserController.Instance.GetCurrentUserInfo ();
                if (user != null && user.IsSuperUser) {
                    return true;
                }
            }
            return false;
        }

        bool GetIsAdmin ()
        {
            if (Request.IsAuthenticated) {
                var user = UserController.Instance.GetCurrentUserInfo ();
                if (user != null && user.IsInRole ("Administrators")) {
                    return true;
                }
            }
            return false;
        }
    }
}
