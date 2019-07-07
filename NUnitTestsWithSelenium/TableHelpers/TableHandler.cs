using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace NUnitTestsWithSelenium.TableHelpers
{
    public class TableHandler
    {
        public List<TableRowData> TableCollection { get; set; } = new List<TableRowData>();

        public TableHandler(IWebElement element)
        {
            // Get the columns from the table
            var columns = element.FindElements(By.TagName("th"));

            // Get the rows from  the table
            var rows = element.FindElements(By.TagName("tr"));

            int rowIndex = 0;
            foreach (IWebElement row in rows)
            {
                // Get all the data from a particular row (Reading children elements from parent)
                var colDatas = row.FindElements(By.XPath(".//*"));

                int colIndex = 0;
                foreach (var colValue in colDatas)
                {
                    TableCollection.Add(new TableRowData
                    {
                        RowIndex = rowIndex,
                        ColumnName = (columns[colIndex].Text != string.Empty) ?
                                      columns[colIndex].Text : colIndex.ToString(),
                        ColumnValue = colValue.Text,
                    });

                    // Move to next column index
                    colIndex++;
                }

                rowIndex++;
            }
        }

        public string ReadCell(string columnName, int rowNumber)
        {
            var data = TableCollection.Where(x => x.ColumnName == columnName && x.RowIndex == rowNumber).Select(x => x.ColumnValue).FirstOrDefault();
            return data;
        }
    }
}
