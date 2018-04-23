Imports DevExpress.Utils
Imports DevExpress.XtraCharts
Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms

Namespace WindowsFormsApplication5
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            ' Create an empty chart.
            Dim chartControl1 As New ChartControl()

            ' Create a connection object. 
            Dim connection As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Public\Documents\DevExpress Demos 14.2\Components\Data\gsp.mdb")

            ' Create data objects.
            Dim adapter As New OleDbDataAdapter("SELECT * FROM GSP", connection)
            Dim ds As New DataSet()
            adapter.Fill(ds)

            ' Bind the chart to data.
            chartControl1.DataSource = ds
            chartControl1.DataAdapter = adapter

            ' Specify data members to bind the chart's series template.
            chartControl1.SeriesDataMember = "Table.Year"
            chartControl1.SeriesTemplate.ArgumentDataMember = "Table.Region"
            chartControl1.SeriesTemplate.ValueDataMembers.AddRange(New String() { "Table.GSP" })

            ' Specify the template's series view.
            chartControl1.SeriesTemplate.View = New StackedBarSeriesView()

            ' Adjust the X-axis and series labels' appearance.
            chartControl1.SeriesTemplate.LabelsVisibility = DefaultBoolean.False
            CType(chartControl1.SeriesTemplate.View, StackedBarSeriesView).AxisX.Label.Angle = 25
            CType(chartControl1.SeriesTemplate.View, StackedBarSeriesView).AxisX.Label.EnableAntialiasing = DefaultBoolean.True

            ' Dock the chart into its parent, and add it to the current form.
            chartControl1.Dock = DockStyle.Fill
            Me.Controls.Add(chartControl1)
        End Sub
    End Class
End Namespace
