using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismSample.Lib.Models.NPOI
{
    public class SetFontHorizontalVertical
    {
        private static SetFontHorizontalVertical instance;

        public static SetFontHorizontalVertical Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SetFontHorizontalVertical();
                }

                return instance;
            }

            set { instance = value; }
        }
        private SetFontHorizontalVertical() { }
        public void SetFont(XSSFWorkbook wb, string caseFont, IRow row, int indexCell)
        {
            IFont font = wb.CreateFont();
            ICellStyle cellStyle = wb.CreateCellStyle();
            switch (caseFont)
            {
                case "horizontalLeft":
                    font.FontName = "MS PGothic";
                    font.FontHeightInPoints = 11;
                    cellStyle.Alignment = HorizontalAlignment.Right;
                    cellStyle.VerticalAlignment = VerticalAlignment.Center;
                    cellStyle.BorderBottom = BorderStyle.Thin;
                    cellStyle.BorderLeft = BorderStyle.Thin;
                    cellStyle.BorderRight = BorderStyle.Thin;
                    cellStyle.BorderTop = BorderStyle.Thin;
                    break;
                default:
                    break;
            }
            cellStyle.SetFont(font);
            row.GetCell(indexCell).CellStyle = cellStyle;
        }
        public void SetCellFontMultiRow(XSSFWorkbook wb, ISheet sheet, int startRow, int endRow, int startCell, int endCell, string strCase)
        {
            for (int i = startRow; i <= endRow; i++)
            {
                for (int j = startCell; j <= endCell; j++)
                {
                    this.SetFont(wb, strCase, sheet.GetRow(i), j);
                }
            }
        }
    }
}
