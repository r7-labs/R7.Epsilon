using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DotNetNuke.UI.UserControls;
using DotNetNuke.UI.WebControls;
using DotNetNuke.Web.UI.WebControls;

namespace R7.Epsilon.LayoutManager
{
    public partial class EditLayout
    {
        protected LinkButton buttonUpdate;
        protected LinkButton buttonDelete;
        protected HyperLink linkCancel;
        protected TextBox layoutEditor;
        protected TextBox textLayoutName;
        protected ModuleAuditControl ctlAudit;
        protected HiddenField hiddenPortalId;
    }
}
