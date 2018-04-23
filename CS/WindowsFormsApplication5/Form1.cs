using DevExpress.Utils;
using DevExpress.XtraCharts;
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApplication5 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // Create an empty chart.
            ChartControl chartControl1 = new ChartControl();

            // Create a connection object. 
            OleDbConnection connection = new OleDbConnection(
              "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\Public\\Documents\\DevExpress Demos 14.2\\Components\\Data\\gsp.mdb");

            // Create data objects.
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM GSP", connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            // Bind the chart to data.
            chartControl1.DataSource = ds;
            chartControl1.DataAdapter = adapter;

            // Specify data members to bind the chart's series template.
            chartControl1.SeriesDataMember = "Table.Year";
            chartControl1.SeriesTemplate.ArgumentDataMember = "Table.Region";
            chartControl1.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Table.GSP" });

            // Specify the template's series view.
            chartControl1.SeriesTemplate.View = new StackedBarSeriesView();

            // Adjust the X-axis and series labels' appearance.
            chartControl1.SeriesTemplate.LabelsVisibility = DefaultBoolean.False;
            ((StackedBarSeriesView)chartControl1.SeriesTemplate.View).AxisX.Label.Angle = 25;
            ((StackedBarSeriesView)chartControl1.SeriesTemplate.View).AxisX.Label.EnableAntialiasing = DefaultBoolean.True;

            // Dock the chart into its parent, and add it to the current form.
            chartControl1.Dock = DockStyle.Fill;
            this.Controls.Add(chartControl1);
        }
    }
}
