using NPOI.HSSF.Util;
using NPOI.SS.UserModel;

namespace PrismSample.Lib.Models.NPOI
{
    class SetExcelColumnStyle
    {
        private static SetExcelColumnStyle instance;

        public static SetExcelColumnStyle Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SetExcelColumnStyle();
                }

                return instance;
            }

            set { instance = value; }
        }

        private SetExcelColumnStyle() { }

        public void SetColumnStyle(IWorkbook wb, ISheet sheet)
        {
            ICellStyle cellStyle = wb.CreateCellStyle();
            IFont font = wb.CreateFont();
            font.FontName = "MS PGothic";
            font.FontHeightInPoints = 11;
            cellStyle.FillForegroundColor = HSSFColor.White.Index;
            cellStyle.FillPattern = FillPattern.LeastDots;
            cellStyle.BorderBottom = BorderStyle.Thick;
            cellStyle.BottomBorderColor = HSSFColor.White.Index;
            cellStyle.SetFont(font);
            for (int i = 0; i < 200; i++)
            {
                sheet.SetDefaultColumnStyle(i, cellStyle);
            }
        }
    }
}
