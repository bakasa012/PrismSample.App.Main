using PrismSample.Lib.Models.DataBinding;
using PrismSample.Lib.Models.NPOI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace PrismSample.Lib.Models
{
    public class ConvertExcelFileModel
    {
        private static ConvertExcelFileModel instance;
        public static ConvertExcelFileModel Instance { get { if (instance == null) instance = new ConvertExcelFileModel(); return instance; } set => instance = value; }
        private ConvertExcelFileModel() { }

        [Obsolete]
        public void ProcessConvertExcelFiles(string pathFolderImportFileExcelGlobal,string pathFolderExportFileExcelGlobal, string startDate,List<DataBindingCompanyCode> dataBindingCompanyCodes)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(pathFolderImportFileExcelGlobal);

            FileInfo[] files = directoryInfo.GetFiles("自己調達許諾シール給付申請書.*", SearchOption.AllDirectories);
            List<DataHeaderExcel> dataHeaderExcels = new List<DataHeaderExcel>();
            List<DataBodyExcelFile> dataBodyExcelFiles = new List<DataBodyExcelFile>();
            int countFile = 0;
            if (startDate.Length > 0)
            {
                string strStartDate = startDate;
                MessageBoxResult messageBoxResult = WPFCustomMessageBox.CustomMessageBox.ShowOKCancel("処理を開始してもよろしいですか？", "", "はい", "いいえ");
                if (messageBoxResult == MessageBoxResult.OK)
                {
                    foreach (FileInfo file in files)
                    {
                        string fileExt = file.Extension;
                        if (fileExt == ".xls" || fileExt == ".xlsx")
                        {
                            countFile++;
                            ReadExcelFiles.Instance.ReadFileExcelWitdNPOI(file.FullName, dataHeaderExcels, dataBodyExcelFiles);
                            DataBindingCompanyCode retData = GetDataCompanyCode.Instance.Get(dataBindingCompanyCodes, dataHeaderExcels[3].column3, dataHeaderExcels[3].column5);
                            string outputNameFile = retData.GEOStoreCode + "_" + retData.StoreName +
                                "-【" + strStartDate + "月末〆】" + strStartDate + "月度自己調達許諾シール給付申請書.xlsx";
                            ExportExcelFiles.Instance.ExportExcelFileWithNPOI(pathFolderExportFileExcelGlobal +
                                @"\" + outputNameFile,
                                dataHeaderExcels, dataBodyExcelFiles);
                        }
                    }
                    WPFCustomMessageBox.CustomMessageBox.Show(countFile.ToString() + "つのファイルが正常に変換されました", "Information!");
                }
            }
        }
    }
}
