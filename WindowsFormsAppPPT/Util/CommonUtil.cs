using Rental.DAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental.Util
{
    class CommonUtil
    {
        public static DataTable GetCommonCode(string category)
        {
            CommonDAC dac = new CommonDAC();
            DataTable dt = dac.GetCommonCode(category);
            dac.Dispose();

            
                DataRow dr = dt.NewRow();
                dr["Code"] = "";
                dr["Name"] = "선택";
                dt.Rows.InsertAt(dr, 0);
                dt.AcceptChanges();
            

            return dt;
        }
        public static void ComboBoxBinding(ComboBox cbo, string category, bool blankItem = true, string blankText = "선택")
        {
            CommonDAC dac = new CommonDAC();
            DataTable dt = dac.GetCommonCode(category);
            dac.Dispose();

            if (blankItem)
            {
                DataRow dr = dt.NewRow();
                dr["Code"] = "";
                dr["Name"] = blankText;
                dt.Rows.InsertAt(dr, 0);
                dt.AcceptChanges();
            }

            cbo.DisplayMember = "Name";
            cbo.ValueMember = "Code";
            cbo.DataSource = dt;
        }

        public static void CmpListBinding(ComboBox cbo, bool blankItem = true, string blankText = "전체")
        {
            CmpDAC dac = new CmpDAC();
            DataTable dt = dac.GetAll();
            dac.Dispose();

            if(blankItem)
            {
                DataRow dr = dt.NewRow();
                dr["cmp_name"] = blankText;
                dt.Rows.InsertAt(dr, 0);
                dt.AcceptChanges();
            }

            cbo.DisplayMember = "cmp_name";
            cbo.DataSource = dt;
        }
        public static void SetInitGridView(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public static void AddGridTextColumn(DataGridView dgv, 
                                        string headerText, 
                                        string propertyName,
                                        DataGridViewContentAlignment align = DataGridViewContentAlignment.MiddleLeft, 
                                        int colWidth = 100, 
                                        bool visibility = true)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.Name = propertyName;
            col.HeaderText = headerText;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.DataPropertyName = propertyName;
            col.Width = colWidth;
            col.DefaultCellStyle.Alignment = align;
            col.Visible = visibility;
            col.ReadOnly = true;

            dgv.Columns.Add(col);
        }
    }
}
