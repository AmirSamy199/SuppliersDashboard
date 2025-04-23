
using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;

namespace SuppliersDashboard.Helper
{
    public class ExcelHeader
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
    public class EldeebExcel
    {
        public  List<ExcelHeader> GetHeaders(string key)
        {
            List<ExcelHeader> result = new List<ExcelHeader>();
            string[] values = key.Split('/');
            foreach(string item in values)
            {
                var value = item.Split(':');
                result.Add(new ExcelHeader { Key = value[0], Value = value[1] });
            }
            return result;
        }
        public Workbook GetExcel<T>(List<T> model, int sheetsize = 0)
        {
            Workbook wb = new Workbook();
            if (sheetsize == 0)
            {
                Worksheet ws1 = wb.Worksheets[0];
                List<string> properties = getProperties<T>(model.FirstOrDefault());
                for (int i = 1; i < properties.Count; i++)
                {
                    ws1.Cells[$"{getCharKey(i)}{1}"].PutValue(translate(properties[i - 1]));
                }

                for (int i = 1; i < properties.Count; i++)
                {
                    for (int j = 2; j <= model.Count + 1; j++)
                    {
                        ws1.Cells[$"{getCharKey(i)}{j}"].PutValue(GetValue(model[j - 2], properties[i - 1]));
                    }
                }
            }
            else
            {
                Worksheet ws1 = wb.Worksheets[0];
                Worksheet ws2 = wb.Worksheets[1];
                Worksheet ws3 = wb.Worksheets[2];
                Worksheet ws4 = wb.Worksheets[3];
                Worksheet ws5 = wb.Worksheets[4];
                Worksheet ws6 = wb.Worksheets[5];
                Worksheet ws7 = wb.Worksheets[6];
                List<string> properties = getProperties<T>(model.FirstOrDefault());
                for (int i = 1; i < properties.Count; i++)
                {
                    
                    ws1.Cells[$"{getCharKey(i)}{1}"].PutValue(translate(properties[i - 1]));
                    if (model.Count > sheetsize * 1 && model.Count <= sheetsize * 2)
                    {
                        ws2.Cells[$"{getCharKey(i)}{1}"].PutValue(translate(properties[i - 1]));
                    }
                    if (model.Count > sheetsize * 2 && model.Count <= sheetsize * 3)
                    {
                        ws3.Cells[$"{getCharKey(i)}{1}"].PutValue(translate(properties[i - 1]));
                    }
                    if (model.Count > sheetsize * 3 && model.Count <= sheetsize * 4)
                    {
                        ws4.Cells[$"{getCharKey(i)}{1}"].PutValue(translate(properties[i - 1]));
                    }
                    if (model.Count > sheetsize * 4 && model.Count <= sheetsize * 5)
                    {
                        ws5.Cells[$"{getCharKey(i)}{1}"].PutValue(translate(properties[i - 1]));
                    }
                    if (model.Count > sheetsize * 5 && model.Count <= sheetsize * 6)
                    {
                        ws6.Cells[$"{getCharKey(i)}{1}"].PutValue(translate(properties[i - 1]));
                    }
                    if (model.Count > sheetsize * 6)
                    {
                        ws7.Cells[$"{getCharKey(i)}{1}"].PutValue(translate(properties[i - 1]));
                    }
                }
                for (int i = 1; i < properties.Count; i++)
                {

                    for (int j = 2; j <= model.Count + 1; j++)
                    {
                        if (j <= sheetsize)
                        {
                            ws1.Cells[$"{getCharKey(i)}{j}"].PutValue(GetValue(model[j - 2], properties[i - 1]));

                        }
                        if (j > sheetsize && j <= sheetsize * 2)
                        {
                            ws2.Cells[$"{getCharKey(i)}{j - sheetsize + 1}"].PutValue(GetValue(model[j - 2], properties[i - 1]));

                        }
                        if (j > sheetsize * 2 && j <= sheetsize * 3)
                        {
                            ws3.Cells[$"{getCharKey(i)}{j - (sheetsize * 2) + 1}"].PutValue(GetValue(model[j - 2], properties[i - 1]));

                        }
                        if (j > sheetsize * 3 && j <= sheetsize * 4)
                        {
                            ws4.Cells[$"{getCharKey(i)}{j - (sheetsize * 3) + 1}"].PutValue(GetValue(model[j - 2], properties[i - 1]));

                        }
                        if (j > sheetsize * 4 && j <= sheetsize * 5)
                        {
                            ws5.Cells[$"{getCharKey(i)}{j - (sheetsize * 4) + 1}"].PutValue(GetValue(model[j - 2], properties[i - 1]));

                        }
                        if (j > sheetsize * 5 && j <= sheetsize * 6)
                        {
                            ws6.Cells[$"{getCharKey(i)}{j - (sheetsize * 5) + 1}"].PutValue(GetValue(model[j - 2], properties[i - 1]));

                        }

                        if (j > sheetsize * 6)
                        {
                            ws7.Cells[$"{getCharKey(i)}{j - (sheetsize * 6) + 1}"].PutValue(GetValue(model[j - 2], properties[i - 1]));

                        }
                    }



                }

            }
            return wb;
        }

        public Workbook GetExcelWithHeader<T>(List<T> model, List<ExcelHeader> Header)
        {
            Workbook wb = new Workbook();
            Worksheet ws1 = wb.Worksheets[0];


            for (int i = 1; i <= Header.Count; i++)
            {
                ws1.Cells[$"{getCharKey(i)}{1}"].PutValue(Header[i - 1].Value);
                ws1.Cells[$"{getCharKey(i)}{1}"].SetStyle(new Style { BackgroundColor = System.Drawing.Color.Blue });
            }

            for (int i = 1; i <= Header.Count; i++)
            {

                for (int j = 2; j <= model.Count + 1; j++)
                {
                    ws1.Cells[$"{getCharKey(i)}{j}"].PutValue(GetValue(model[j - 2], Header[i - 1].Key));

                }



            }

            return wb;

        }

        private List<string> getProperties<T>(T model)
        {
            List<string> properties = new List<string>();
            properties = typeof(T).GetProperties().Select(s => s.Name).ToList();
            return properties;
        }

        private string getCharKey(int i)
        {
            switch (i)
            {
                case 1: return "A";
                case 2: return "B";
                case 3: return "C";
                case 4: return "D";
                case 5: return "E";
                case 6: return "F";
                case 7: return "G";
                case 8: return "H";
                case 9: return "I";
                case 10: return "J";
                case 11: return "K";
                case 12: return "L";
                case 13: return "M";
                case 14: return "N";
                case 15: return "O";
                case 16: return "P";
                case 17: return "Q";
                case 18: return "R";
                case 19: return "S";
                case 20: return "T";
                case 21: return "U";
                case 22: return "V";
                case 23: return "W";
                case 24: return "X";
                case 25: return "Y";
                case 26: return "Z";
                case 27: return "AA";
                case 28: return "AB";
                case 29: return "AC";
                case 30: return "AD";
                case 31: return "AE";
                case 32: return "AF";
                case 33: return "AG";
                case 34: return "AH";
                case 35: return "AI";
                case 36: return "AJ";
                case 37: return "AK";
                case 38: return "AL";
                case 39: return "AM";
                default: return "AN";
            }
        }

        private string GetValue(object src, string Key)
        {
            try
            {
                try
                {

                    return src.GetType().GetProperty(Key.Trim()).GetValue(src, null).ToString();
                }
                catch
                {
                    return "";
                }
            }
            catch
            {
                return "";
            }
        }

        private string translate(string key)
        {
            //											
            switch (key)
            {

                case "ItemName":
                    return "اسم الصنف  ";
                case "Branch id":
                    return "رقم الفرع  ";
                case "Sales ID":
                    return "رقم البائع  ";
                case "ItemID":
                    return "رقم الصنف  ";
                case "Items":
                    return " الصنف  ";

                case "UserName":
                    return " الاسم  ";
                case "NumberOfUnits":
                    return " العدد  ";
                case "UnitPrice":
                    return " سعر الوحدة   ";

                case "TotalPrice":
                    return " السعر الكلي   ";
                case "SalesName":
                    return " اسم البائع   ";
                case "SalesId":
                    return " رقم البائع   ";
                case "TotalPil":
                    return " عدد الفواتير    ";
                case "TotalPillBeforDiscount":
                    return "مجموع الفواتير قبل الخصم    ";
                case "TotalPilDiscount":
                    return "مجموع خصم الفواتير    ";
                case "TotalPilAfterDiscount":
                    return " مجموع الفواتير بعد الخصم    ";
                case "TotalItemsQount":
                    return " عدد الاصناف    ";
                case "TotalItemsDiscount":
                    return " مجموع خصم الاصناف    ";
                case "TotalPilCach":
                    return "المدفوع في الفاتورة   ";
                case "TotalPilAgel":
                    return " الاجل   ";
                case "Msrofat":
                    return " مصروفات   ";
                case "TotalPilNet":
                    return " صافي الفاتورة   ";
                case "Collection":
                    return " التحصيل   ";
                case "MoneyReceiptPapers_Amount":
                    return " مبلغ اوراق الدفع    ";

                case "MoneyReceiptPapers_count":
                    return " عدد اوراق الدفع    ";

                case "DeferredMoneyPaper_count":
                    return " عدد اوراق التحصيل   ";

                case "DeferredMoneyPaper_Amount":
                    return " مبلغ اوراق التحصيل    ";






                case "BillNO":
                    return "رقم الفاتورة  ";
                case "Credit":
                    return " وارد  ";
                case "Debit":
                    return "منصرف    ";
                case "Item_Count":
                    return " العدد  ";
                case "Barcode":
                    return " الباركود";
                case "Item_ID":
                    return "كود الصنف  ";
                case "date":
                    return "التاريخ ";
                case "transactionType":
                    return "نوع الحركة  ";
                case "transaction":
                    return " الحركة  ";
                case "Typett":
                    return "النوع ";
                case "BillNo":
                    return "رقم العملية  ";

                case "Add_date":
                    return "التاريخ ";

                case "Old_RemainingAmount":
                    return "الرصيد السابق  ";

                case "SalesAmount":
                    return "كمية المبايعات ";

                case "ReturnAmount":
                    return "كمية المرتجعات   ";

                case "Amount_Required":
                    return "المبلغ المطلوب  ";

                case "TotalePayment":
                    return "اجمالي المدفوع  ";

                case "CollectionAmount":
                    return "التحصيل ";

                case "cash":
                    return "كاش  ";

                case "Deferred":
                    return "اجل    ";

                case "RemainingAmount":
                    return "الرصيد الحالي    ";
                case "BranchName":
                    return "اسم الفرع      ";

                case "Branch_Id":
                    return "رقم الفرع      ";
                case "Add_Date":
                    return "التاريخ        ";



                case "bal":
                    return " الصافي    ";


                default:
                    return key.Replace("_", " ");



            }

        }

    }

}