Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web

Namespace DynamicShowHidePreview
	Partial Public Class _Default
		Inherits System.Web.UI.Page
		Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
			ASPxGridView1.DataSource = GetData()
			ASPxGridView1.DataBind()
		End Sub

		Private Function GetData() As DataTable
			Dim table As New DataTable()
			table.Columns.Add("ID", GetType(Integer))
			table.Columns.Add("Name", GetType(String))
			table.Columns.Add("Description", GetType(String))
			For i As Integer = 0 To 9
				table.Rows.Add(i, "Item " & i.ToString(), "Description " & i.ToString())
			Next i
			Return table
		End Function

		Private Const MoreInfoPrefix As String = "MoreInfoForRow_"
		Private Function GetKey(ByVal key As Object) As String
			Return String.Format("{0}{1}", MoreInfoPrefix, key)
		End Function

		Protected Function IsPreviewVisible(ByVal key As Object) As Boolean
			Dim isVisible As Object = Session(GetKey(key))
			Dim result As Boolean = True.Equals(isVisible)
			Return True.Equals(isVisible)
		End Function

		Protected Sub ASPxCheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
			Dim check As ASPxCheckBox = CType(sender, ASPxCheckBox)
			Dim container As GridViewDataItemTemplateContainer = CType(check.Parent, GridViewDataItemTemplateContainer)
			Dim key As Object = container.KeyValue
			Session(GetKey(key)) = check.Checked
			ASPxGridView1.DataBind()
		End Sub

		Protected Sub ASPxGridView1_HtmlRowPrepared(ByVal sender As Object, ByVal e As ASPxGridViewTableRowEventArgs)
			If e.RowType = GridViewRowType.Preview Then
				If (Not IsPreviewVisible(e.KeyValue)) Then
					e.Row.Style(HtmlTextWriterStyle.Display) = "none"
				End If
			End If
		End Sub
	End Class
End Namespace
