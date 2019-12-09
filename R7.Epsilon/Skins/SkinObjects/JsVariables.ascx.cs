//
//  File: JsVariables.ascx.cs
//  Project: R7.Epsilon
//
//  Author: Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2014-2019 Roman M. Yagodin, R7.Labs
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Affero General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Affero General Public License for more details.
//
//  You should have received a copy of the GNU Affero General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System.Text;

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

                sb.AppendFormat ("feedbackTemplate:'{0}',", T.GetString ("Feedback_Template.Text"));
                sb.AppendFormat ("feedbackPageTemplate:'{0}',", T.GetString ("FeedbackPage_Template.Text"));
                sb.AppendFormat ("feedbackSelectionTemplate:'{0}',", T.GetString ("FeedbackSelection_Template.Text"));
                sb.AppendFormat ("subMenuCloseButtonTitle:'{0}',", T.GetString ("SubMenuClose.Text"));
                sb.AppendFormat ("feedbackMessage:'{0}'", T.GetString ("FeedbackMessage.Text"));

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

        #endregion
    }
}
