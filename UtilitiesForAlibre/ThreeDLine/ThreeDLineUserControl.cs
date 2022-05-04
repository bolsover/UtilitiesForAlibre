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
        private IADSession session;
        public BindingList<Coordinate> data = new BindingList<Coordinate>();
       

        public ThreeDLineUserControl(IADSession session)
        {
            this.session = session;
            initTestData();
            InitializeComponent();
            BindDataToGrid();
        }

        private void BindDataToGrid()
        {
            this.coordinatesDataGridView.DataSource = data;
          
        }

        private void initTestData()
        {
            data.Add(new Coordinate(0,0,0));
            data.Add(new Coordinate(1,1,1));
        }


        private void buttonImportExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();  
            fdlg.Title = "Select file";  
            fdlg.InitialDirectory = @"Desktop";  
             fdlg.FileName = textBoxExcel.Text;  
            fdlg.Filter = "Excel(*.xls; *.xlsx)|*.xls, *.xlsx|All Files(*.*)|*.*";  
            fdlg.FilterIndex = 2;  
            fdlg.RestoreDirectory = true;  
            if (fdlg.ShowDialog() == DialogResult.OK)  
            {  
                textBoxExcel.Text = fdlg.FileName;  
                import();  
              
            }  
        }


        private void import()
        {
            String name = "Sheet1";
            String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                            textBoxExcel.Text + 
                            ";Extended Properties='Excel 8.0;HDR=YES;';";

            OleDbConnection con = new OleDbConnection(constr);
            OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
            con.Open();

            OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            data.Clear();
            Coordinate coordinate;
            foreach (DataRow row in dataTable.Rows)
            {
                coordinate = new Coordinate((double) row[0], (double) row[1], (double) row[2]);
               data.Add(coordinate);
            }
            CurrencyManager cm =
                (CurrencyManager) this.coordinatesDataGridView.BindingContext[data];
            cm.Refresh();
        }

        private void buttonDeleteRow_Click(object sender, EventArgs e)
        {
            CurrencyManager cm =
                (CurrencyManager) this.coordinatesDataGridView.BindingContext[data];
            int selectedCount = coordinatesDataGridView.SelectedRows.Count;           
            while (selectedCount > 0)
            {
                if (!coordinatesDataGridView.SelectedRows[0].IsNewRow)
                    coordinatesDataGridView.Rows.RemoveAt(coordinatesDataGridView.SelectedRows[0].Index);
                selectedCount--;
            }
            cm.Refresh();
          
        }

        private void buttonAddRow_Click(object sender, EventArgs e)
        {
            this.data.Add(new Coordinate(0,0,0));
            CurrencyManager cm =
                (CurrencyManager) this.coordinatesDataGridView.BindingContext[data];
            cm.Refresh();
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            IAD3DSketch ad3DSketch = ((IADPartSession) session).Sketches3D.Add3DSketch("3DSketch");
            ((Alibre3DSketch)ad3DSketch).BeginChange();
            Coordinate prior = data[0];
            for (int i = 1; i < data.Count; )
            {
                Coordinate next = data[i++];
                ad3DSketch.Figures.AddLine(prior.X/10, prior.Y/10, prior.Z/10, next.X/10, next.Y/10, next.Z/10);
                prior = next;
            }
            ((Alibre3DSketch)ad3DSketch).EndChange();
        }
    }
}