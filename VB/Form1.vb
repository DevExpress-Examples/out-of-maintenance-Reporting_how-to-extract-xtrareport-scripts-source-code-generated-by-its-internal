Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraReports
Imports System.Reflection
Imports DevExpress.XtraReports.UI

Namespace RepGetScripts
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Dim report As New XtraReport1()

			report.CreateDocument()

			Dim esm As XREventsScriptManager = CType(GetType(XtraReport).InvokeMember("eventsScriptMgr", BindingFlags.GetField Or BindingFlags.NonPublic Or BindingFlags.Instance, Nothing, report, Nothing), XREventsScriptManager)
			Dim scriptManager As Object = GetType(XREventsScriptManager).InvokeMember("scriptExecutor", BindingFlags.GetField Or BindingFlags.NonPublic Or BindingFlags.Instance, Nothing, esm, Nothing)

			Dim param() As Object = {New StringBuilder()}

			scriptManager.GetType().InvokeMember("GenerateSource", BindingFlags.InvokeMethod Or BindingFlags.NonPublic Or BindingFlags.Instance, Nothing, scriptManager, param)

			richTextBox1.Text = param(0).ToString()
			CType(New ReportPrintTool(report), ReportPrintTool).ShowPreview()
			Me.Activate()
		End Sub
	End Class
End Namespace