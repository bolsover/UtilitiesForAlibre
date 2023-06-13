using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using AlibreX;
using com.alibre.automation;

namespace Bolsover.ThreeDLine
{
    public partial class ThreeDLineUserControl : UserControl
    {
        private IADSession _session;
        public BindingList<Coordinate> Data = new();


        public ThreeDLineUserControl(IADSession session)
        {
            this._session = session;
            InitTestData();
            InitializeComponent();
            BindDataToGrid();
        }

        private void BindDataToGrid()
        {
            coordinatesDataGridView.DataSource = Data;
        }

        private void InitTestData()
        {
            Data.Add(new Coordinate(0, 0, 0));
            Data.Add(new Coordinate(1, 1, 1));
        }


        private void buttonImportExcel_Click(object sender, EventArgs e)
        {
            var fdlg = new OpenFileDialog();
            fdlg.Title = "Select file";
            fdlg.InitialDirectory = @"Desktop";
            fdlg.FileName = textBoxExcel.Text;
            fdlg.Filter = "Excel(*.xls; *.xlsx)|*.xls, *.xlsx|All Files(*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                textBoxExcel.Text = fdlg.FileName;
                Import();
            }
        }


        private void Import()
        {
            var name = "Sheet1";
            var constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                         textBoxExcel.Text +
                         ";Extended Properties='Excel 8.0;HDR=YES;';";

            var con = new OleDbConnection(constr);
            var oconn = new OleDbCommand("Select * From [" + name + "$]", con);
            con.Open();

            var sda = new OleDbDataAdapter(oconn);
            var dataTable = new DataTable();
            sda.Fill(dataTable);
            Data.Clear();
            Coordinate coordinate;
            foreach (DataRow row in dataTable.Rows)
            {
                coordinate = new Coordinate((double) row[0], (double) row[1], (double) row[2]);
                Data.Add(coordinate);
            }

            var cm =
                (CurrencyManager) coordinatesDataGridView.BindingContext[Data];
            cm.Refresh();
        }

        private void buttonDeleteRow_Click(object sender, EventArgs e)
        {
            var cm =
                (CurrencyManager) coordinatesDataGridView.BindingContext[Data];
            var selectedCount = coordinatesDataGridView.SelectedRows.Count;
            while (selectedCount > 0)
            {
                if (!coordinatesDataGridView.SelectedRows[0].IsNewRow)
                {
                    coordinatesDataGridView.Rows.RemoveAt(coordinatesDataGridView.SelectedRows[0].Index);
                }

                selectedCount--;
            }

            cm.Refresh();
        }

        private void buttonAddRow_Click(object sender, EventArgs e)
        {
            Data.Add(new Coordinate(0, 0, 0));
            var cm =
                (CurrencyManager) coordinatesDataGridView.BindingContext[Data];
            cm.Refresh();
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            var ad3DSketch = ((IADPartSession) _session).Sketches3D.Add3DSketch("3DSketch");
            ((Alibre3DSketch) ad3DSketch).BeginChange();
            var prior = Data[0];
            for (var i = 1; i < Data.Count;)
            {
                var next = Data[i++];
                ad3DSketch.Figures.AddLine(prior.X / 10, prior.Y / 10, prior.Z / 10, next.X / 10, next.Y / 10,
                    next.Z / 10);
                prior = next;
            }

            ((Alibre3DSketch) ad3DSketch).EndChange();
        }
    }
}