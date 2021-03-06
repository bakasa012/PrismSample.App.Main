using NPOI.SS.UserModel;

namespace PrismSample.Lib.Models.NPOI
{
    class SetCellTypeValueForMultiRow
    {
        private static SetCellTypeValueForMultiRow instance;

        public static SetCellTypeValueForMultiRow Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SetCellTypeValueForMultiRow();
                }

                return instance;
            }

            set { instance = value; }
        }
        private SetCellTypeValueForMultiRow() { }
        public void SetCellValueTypeMultiRow(ISheet sheet, int startRow, int endRow, int startCell, int endCell, CellType cellType)
        {
            for (int i = startRow; i <= endRow; i++)
            {
                for (int j = startCell; j <= endCell; j++)
                {
                    sheet.GetRow(i).GetCell(j).SetCellType(cellType);
                }
            }
        }
    }
}
