Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports DevExpress.XtraCharts
' ...

Namespace BindAChartAtRuntime
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' Create an empty chart.
			Dim chart As New ChartControl()

			' Create data objects.
			Dim adapter As New OleDbDataAdapter("SELECT * FROM GSP", "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\gsp.mdb")
			Dim ds As New DataSet()
			'adapter.FillSchema(ds, SchemaType.Source);
			adapter.Fill(ds)

			' Bind the chart to data.
			chart.DataSource = ds
			chart.DataAdapter = adapter

			' Specify data members to bind the chart's series template.
			chart.SeriesDataMember = "Table.Year"
			chart.SeriesTemplate.ArgumentDataMember = "Table.Region"
			chart.SeriesTemplate.ValueDataMembers.AddRange(New String() { "Table.GSP" })

			' Specify the template's series view.
			chart.SeriesTemplate.View = New StackedBarSeriesView()

			' Adjust the X-axis and series labels' appearance.
			chart.SeriesTemplate.Label.Visible = False
			CType(chart.SeriesTemplate.View, StackedBarSeriesView).AxisX.Label.Angle = 25
			CType(chart.SeriesTemplate.View, StackedBarSeriesView).AxisX.Label.Antialiasing = True

			' Dock the chart into its parent, and add it to the current form.
			chart.Dock = DockStyle.Fill
			Me.Controls.Add(chart)
		End Sub

	End Class
End Namespace