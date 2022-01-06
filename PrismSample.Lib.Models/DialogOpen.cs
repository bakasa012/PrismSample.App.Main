using Reactive.Bindings;

namespace PrismSample.Lib.Models
{
    public class DialogOpen
    {
        private static DialogOpen instance;
        public static DialogOpen Instance { get { if (instance == null) instance = new DialogOpen(); return instance; } set => instance = value; }

        private DialogOpen() { }

        public void OpentFolderDialog(ReactiveProperty<string> pathFile)
        {
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = folderBrowserDialog.ShowDialog();
            string strPath = pathFile.Value;
            if ((int)result == 1 && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
            {
                    strPath = folderBrowserDialog.SelectedPath;
            }
            pathFile.Value = strPath;
        }
    }
}
