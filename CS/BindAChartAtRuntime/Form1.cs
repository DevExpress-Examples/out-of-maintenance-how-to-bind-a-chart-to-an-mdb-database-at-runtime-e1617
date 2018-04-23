using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using DevExpress.XtraCharts;
// ...

namespace BindAChartAtRuntime {
    public partial class Form1: Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // Create an empty chart.
            ChartControl chart = new ChartControl();

            // Create data objects.
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM GSP",
                @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\gsp.mdb");
            DataSet ds = new DataSet();
            //adapter.FillSchema(ds, SchemaType.Source);
            adapter.Fill(ds);

            // Bind the chart to data.
            chart.DataSource = ds;
            chart.DataAdapter = adapter;

            // Specify data members to bind the chart's series template.
            chart.SeriesDataMember = "Table.Year";
            chart.SeriesTemplate.ArgumentDataMember = "Table.Region";
            chart.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Table.GSP" });

            // Specify the template's series view.
            chart.SeriesTemplate.View = new StackedBarSeriesView();

            // Adjust the X-axis and series labels' appearance.
            chart.SeriesTemplate.Label.Visible = false;
            ((StackedBarSeriesView)chart.SeriesTemplate.View).AxisX.Label.Angle = 25;
            ((StackedBarSeriesView)chart.SeriesTemplate.View).AxisX.Label.Antialiasing = true;

            // Dock the chart into its parent, and add it to the current form.
            chart.Dock = DockStyle.Fill;
            this.Controls.Add(chart);
        }

    }
}