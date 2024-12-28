using System;
using System.Windows.Forms;
using System.Reflection;
using System.ComponentModel;

namespace VocabManager
{
    public class Status
    {
        public Int32 firstDisplayedScrollingRow;
        public SortOrder lastSortOrder;
        public Int32 lastSortColumn;
        public Int32 lastCellRow;
        public Int32 lastCellColumn;
    }

    public class DataGridView_Utils
    {
        public static void SetDoubleBufferForDgv(ref DataGridView dgv, bool doubleBuffered)
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null, dgv, new object[] { doubleBuffered });
        }

        /// Save last position and sort order
        public static Status GetStatus(ref DataGridView dgv)
        {
            Status status = new Status();

            try
            {
                status.firstDisplayedScrollingRow = dgv.FirstDisplayedScrollingRowIndex;
                status.lastSortOrder = dgv.SortOrder;
                status.lastSortColumn = dgv.SortedColumn?.Index ?? -1;
                status.lastCellRow = dgv.CurrentCell?.RowIndex ?? -1;
                status.lastCellColumn = dgv.CurrentCell?.ColumnIndex ?? -1;

                return status;
            }
            catch (Exception)
            {
                return status;
            }
        }

        /// Restore last position and sort order
        public static void SetStatus(ref DataGridView dgv, Status status)
        {
            try
            {
                if (status.lastSortColumn > -1)
                {
                    DataGridViewColumn newColumn = dgv.Columns[status.lastSortColumn];
                    switch (status.lastSortOrder)
                    {
                        case SortOrder.Ascending:
                            dgv.Sort(newColumn, ListSortDirection.Ascending);
                            break;
                        case SortOrder.Descending:
                            dgv.Sort(newColumn, ListSortDirection.Descending);
                            break;
                        case SortOrder.None:
                            break;
                    }
                }

                if (status.firstDisplayedScrollingRow >= 0)
                {
                    dgv.FirstDisplayedScrollingRowIndex = status.firstDisplayedScrollingRow;
                }

                if (status.lastCellRow > -1 && status.lastCellColumn > -1)
                {
                    dgv.CurrentCell = dgv[status.lastCellColumn, status.lastCellRow];
                }
            }
            catch (Exception)
            {
            }
        }

        public static bool IsSameCellValue(ref DataGridView dgv, int column, int row)
        {
            if (row < 1)
            {
                return false;
            }

            DataGridViewCell cell1 = dgv[column, row];
            DataGridViewCell cell2 = dgv[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }
    }
}
