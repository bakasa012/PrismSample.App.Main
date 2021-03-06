using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PrismSample.Lib.Models.NPOI
{
    class ReadExcelFiles
    {
        private static ReadExcelFiles instance;

        public static ReadExcelFiles Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ReadExcelFiles();
                }

                return instance;
            }

            set { instance = value; }
        }

        private ReadExcelFiles() { }
        public void ReadFileExcelWitdNPOI(string pathFile, List<DataBinding.DataHeaderExcel> dataHeaderExcels, List<DataBinding.DataBodyExcelFile> dataBodyExcelFiles)
        {
            dataHeaderExcels.Clear();
            dataBodyExcelFiles.Clear();
            using (FileStream fileStream = new FileStream(@pathFile, FileMode.Open, FileAccess.Read))
            {
                IWorkbook wb;
                switch (Path.GetExtension(pathFile).ToLower())
                {
                    case ".xlsx":
                        wb = new XSSFWorkbook(fileStream);
                        break;
                    default:
                        wb = new HSSFWorkbook(fileStream);
                        break;
                }
                ISheet sheet = wb.GetSheetAt(0);
                int lastRow = sheet.LastRowNum;
                int rowIndex = 4;
                ICellStyle set = sheet.GetRow(6).GetCell(0).CellStyle;
                while (rowIndex <= lastRow - 1)
                {
                    IRow nowRow = sheet.GetRow(rowIndex);
                    if (nowRow != null)
                    {
                        if (rowIndex < 17)
                        {
                            DataBinding.DataHeaderExcel dataHeaderExcel = new DataBinding.DataHeaderExcel
                            {
                                column1 = " ",
                                column2 = nowRow.GetCell(0, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString(),
                                column3 = nowRow.GetCell(1, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString().Trim(),
                                column4 = nowRow.GetCell(2, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString(),
                                column5 = nowRow.GetCell(3, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString(),
                                column6 = nowRow.GetCell(4, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString(),
                                column7 = "",
                                column8 = nowRow.GetCell(5, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString(),
                            };
                            dataHeaderExcels.Add(dataHeaderExcel);
                        }
                        else
                        {
                            DataBinding.DataBodyExcelFile dataBodyExcelFile = new DataBinding.DataBodyExcelFile()
                            {
                                column1 = " ",
                                column2 = nowRow.GetCell(0, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString(),
                                column3 = nowRow.GetCell(1, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString(),
                                column4 = nowRow.GetCell(2, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString(),
                                column5 = nowRow.GetCell(3, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString(),
                                column6 = nowRow.GetCell(4, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString(),
                                column7 = "",
                                column8 = nowRow.GetCell(5, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString(),
                            };
                            dataBodyExcelFiles.Add(dataBodyExcelFile);
                        }
                    }
                    else { }

                    rowIndex++;
                }
                fileStream.Close();
            };
        }
    }
}
