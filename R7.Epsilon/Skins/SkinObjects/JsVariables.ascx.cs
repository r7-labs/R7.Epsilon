using System.Text;
using DotNetNuke.Entities.Users;

namespace R7.Epsilon.Skins.SkinObjects
{
    // TODO: Introduce ClientConfig class, serialize it to JSON
    public class JsVariables: EpsilonSkinObjectBase
    {
        #region Bindable properties

        public string LocalizationResources
        {
            get {
                var sb = new StringBuilder ();

                sb.AppendFormat ("feedbackMessageTemplate:'{0}'", T.GetString ("Feedback_MessageTemplate.Text"));
                sb.Append (",");
                sb.AppendFormat ("notSpecified:'{0}'", T.GetString ("NotSpecified.Text"));

                return sb.ToString ();
            }
        }

        public string QueryParams
        {
            get {
                var sb = new StringBuilder (Request.RawUrl.Length);
                foreach (string key in Request.QueryString.Keys) {
                    sb.AppendFormat ("{2}{0}:'{1}'", key, Request.QueryString [key], sb.Length == 0? "" : ",");
                }
                return sb.ToString ();
            }
        }

        public bool IsSuperUser {
            get {
                if (Request.IsAuthenticated) {
                    var user = UserController.Instance.GetCurrentUserInfo ();
                    if (user != null && user.IsSuperUser) {
                        return true;
                    }
                }
                return false;
            }
        }

        public bool IsAdmin {
            get {
                if (Request.IsAuthenticated) {
                    var user = UserController.Instance.GetCurrentUserInfo ();
                    if (user != null && user.IsInRole ("Administrators")) {
                        return true;
                    }
                }
                return false;
            }
        }

        #endregion
    }
}
