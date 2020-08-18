<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DynamicShowHidePreview._Default" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>How to dynamically hide or show a preview row</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" KeyFieldName="ID" OnHtmlRowPrepared="ASPxGridView1_HtmlRowPrepared">
            <Templates>
                <PreviewRow>
                    <dxe:ASPxLabel ID="ASPxLabel1" runat="server" Text='<%# Eval("Description") %>'>
                    </dxe:ASPxLabel>
                </PreviewRow>
            </Templates>
            <Columns>
                <dxwgv:GridViewDataTextColumn FieldName="Name" VisibleIndex="0">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn Caption="More Info?" VisibleIndex="1">
                    <DataItemTemplate>
                        <dxe:ASPxCheckBox ID="ASPxCheckBox1" runat="server" AutoPostBack="true" Checked="<%# IsPreviewVisible(Container.KeyValue) %>" OnCheckedChanged="ASPxCheckBox1_CheckedChanged">
                        </dxe:ASPxCheckBox>
                    </DataItemTemplate>
                </dxwgv:GridViewDataTextColumn>
            </Columns>
            <Settings ShowPreview="True" />
        </dxwgv:ASPxGridView>
    </div>
    </form>
</body>
</html>
