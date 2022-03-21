using System;
using System.Windows.Forms;

using YandexDisk.Client.Http;

namespace YandexDiskApp
{
    static class Program
    {
        private const string ACCESS_TOKEN = "AQAAAABehOdLAAe_lK0bsCViLUXhotDynS3_hUQ";
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var diskApi = new DiskHttpApi(ACCESS_TOKEN);

            Application.Run(new mainForm(diskApi));
        }
    }
}
