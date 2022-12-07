using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web;

namespace DynamicShowHidePreview {
    public partial class _Default : System.Web.UI.Page {
        protected void Page_Init(object sender, EventArgs e) {
            ASPxGridView1.DataSource = GetData();
            ASPxGridView1.DataBind();
        }

        private DataTable GetData() {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Description", typeof(string));
            for(int i = 0; i < 10; i++) {
                table.Rows.Add(i, "Item " + i.ToString(), "Description " + i.ToString());
            }
            return table;
        }

        const string MoreInfoPrefix = "MoreInfoForRow_";
        private string GetKey(object key) {
            return string.Format("{0}{1}", MoreInfoPrefix, key);
        }

        protected bool IsPreviewVisible(object key) {
            object isVisible = Session[GetKey(key)];
            bool result = true.Equals(isVisible);
            return true.Equals(isVisible);
        }

        protected void ASPxCheckBox1_CheckedChanged(object sender, EventArgs e) {
            ASPxCheckBox check = (ASPxCheckBox)sender;
            GridViewDataItemTemplateContainer container = (GridViewDataItemTemplateContainer)check.Parent;
            object key = container.KeyValue;
            Session[GetKey(key)] = check.Checked;
            ASPxGridView1.DataBind();
        }

        protected void ASPxGridView1_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e) {
            if(e.RowType == GridViewRowType.Preview) {
                if(!IsPreviewVisible(e.KeyValue))
                    e.Row.Style[HtmlTextWriterStyle.Display] = "none";
            }
        }
    }
}
