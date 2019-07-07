using System.Text;

namespace NUnitTestsWithSelenium.TableHelpers
{
    public class TableRowData
    {
        public int RowIndex { get; set; }
        public string ColumnName { get; set; }
        public string ColumnValue { get; set; }

        public TableRowData()
        {

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Index:{RowIndex}, Column Name: {ColumnName}, Column Value: {ColumnValue}");

            return sb.ToString();
        }
    }
}
