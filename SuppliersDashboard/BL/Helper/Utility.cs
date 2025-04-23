using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScoposERB.Helper
{
    public static class Utility
    {
        public static DataTable ConvertFiletoDataTable(HttpPostedFileBase file)
        {
            DataTable dt = new DataTable();
            var FileName = file.FileName;
            string FileExtension = Path.GetExtension(file.FileName).ToLower();
            if (FileExtension == ".xls" || FileExtension == ".xlsx" || FileExtension == ".csv")
            {
                string FileLocation = HttpContext.Current.Server.MapPath("~/Uploads/") + FileName;
                if (System.IO.File.Exists(FileLocation))
                {
                    System.IO.File.Delete(FileLocation);
                }
                file.SaveAs(FileLocation);

                string ConnectionString = string.Empty;

                if (FileExtension == ".csv")
                {
                    dt = ConvertCSVtoDataTable(FileLocation);
                }  
                else if (FileExtension == ".xls")
                {
                    ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileLocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                    dt = Utility.ConvertXSLXtoDataTable(ConnectionString);
                }
                else if (FileExtension == ".xlsx")
                {
                    ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    dt = Utility.ConvertXSLXtoDataTable(ConnectionString);
                }

            }

            return dt;
        }
        public static DataTable ConvertCSVtoDataTable(string strFilePath)
        {
            DataTable dt = new DataTable();
            using (StreamReader sr = new StreamReader(strFilePath))
            {
                string[] headers = sr.ReadLine().Split(',');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }

                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(',');
                    if (rows.Length > 1)
                    {
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            dr[i] = rows[i].Trim();
                        }
                        dt.Rows.Add(dr);
                    }
                }

            }
            return dt;
        }

        public static DataTable ConvertXSLXtoDataTable(string connString)
        {
            OleDbConnection oledbConn = new OleDbConnection(connString);
            DataTable dt = new DataTable();
            try
            {

                oledbConn.Open();
                using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", oledbConn))
                {
                    OleDbDataAdapter oleda = new OleDbDataAdapter();
                    oleda.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    oleda.Fill(ds);

                    dt = ds.Tables[0];
                }
            }
            catch(Exception ex)
            {
            }
            finally
            {

                oledbConn.Close();
            }

            return dt;
        }

        //public static DataTable ExcelToTable(string filename)
        //{
        //    //byte[] bytes= System.IO.File.ReadAllBytes();

        //    FileStream excelStream = new FileStream(HttpContext.Current.Server.MapPath(filename), FileMode.Open);
        //    var table = new DataTable();
        //    var book = new HSSFWorkbook(excelStream);
        //    excelStream.Close();

        //    var sheet = book.GetSheetAt(0);
        //    var headerRow = sheet.GetRow(0);//第一行为标题行
        //    var cellCount = headerRow.LastCellNum;//LastCellNum = PhysicalNumberOfCells
        //    var rowCount = sheet.LastRowNum;//LastRowNum = PhysicalNumberOfRows - 1

        //    //header
        //    for (int i = headerRow.FirstCellNum; i < cellCount; i++)
        //    {
        //        var column = new DataColumn(headerRow.GetCell(i).StringCellValue);
        //        table.Columns.Add(column);
        //    }

        //    //body
        //    for (var i = sheet.FirstRowNum + 1; i <= rowCount; i++)
        //    {
        //        var row = sheet.GetRow(i);
        //        var dataRow = table.NewRow();
        //        if (row != null)
        //        {
        //            for (int j = row.FirstCellNum; j < cellCount; j++)
        //            {
        //                if (row.GetCell(j) != null)
        //                    dataRow[j] = GetCellValue(row.GetCell(j));
        //            }
        //        }
        //        table.Rows.Add(dataRow);
        //    }

        //    return table;
        //}


        //private static string GetCellValue(ICell cell)
        //{


        //    if (cell == null)
        //        return string.Empty;
        //    switch (cell.CellType)
        //    {
        //        case CellType.Blank:
        //            return string.Empty;
        //        case CellType.Boolean:
        //            return cell.BooleanCellValue.ToString();
        //        case CellType.Error:
        //            return cell.ErrorCellValue.ToString();
        //        case CellType.Numeric:
        //        case CellType.Unknown:
        //        default:
        //            return cell.ToString();//This is a trick to get the correct value of the cell. NumericCellValue will return a numeric value no matter the cell value is a date or a number
        //        case CellType.String:
        //            return cell.StringCellValue;
        //        case CellType.Formula:
        //            try
        //            {
        //                var e = new HSSFFormulaEvaluator(cell.Sheet.Workbook);
        //                e.EvaluateInCell(cell);
        //                return cell.ToString();
        //            }
        //            catch
        //            {
        //                return cell.NumericCellValue.ToString();
        //            }
        //    }
        //}


        //public static DataTable ToDataTable(this ExcelPackage package)
        //{
        //    ExcelWorksheet workSheet = package.Workbook.Worksheets.First();
        //    DataTable table = new DataTable();
        //    foreach (var firstRowCell in workSheet.Cells[1, 1, 1, workSheet.Dimension.End.Column])
        //    {
        //        table.Columns.Add(firstRowCell.Text);
        //    }

        //    for (var rowNumber = 2; rowNumber <= workSheet.Dimension.End.Row; rowNumber++)
        //    {
        //        var row = workSheet.Cells[rowNumber, 1, rowNumber, workSheet.Dimension.End.Column];
        //        var newRow = table.NewRow();
        //        foreach (var cell in row)
        //        {
        //            newRow[cell.Start.Column - 1] = cell.Text;
        //        }
        //        table.Rows.Add(newRow);
        //    }
        //    return table;
        //}
    }
}

