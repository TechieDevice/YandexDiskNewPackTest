using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using YandexDisk.Client;
using YandexDisk.Client.Clients;
using YandexDisk.Client.Protocol;

namespace YandexDiskApp
{
    public partial class mainForm : Form
    {
        private IDiskApi _diskApi;

        private string downloads;

        public mainForm(IDiskApi api)
        {
            downloads = Path.Combine(Directory.GetCurrentDirectory(), "downloads");
            if (!Directory.Exists(downloads))
            {
                var dir = new FileInfo(downloads);
                dir.Directory.CreateSubdirectory("downloads");
            }

            _diskApi = api;

            InitializeComponent();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string name = openFileDialog.FileName;
            pathToFile.Text = name;
        }

        private async void getListButton_Click(object sender, EventArgs e)
        {
            try
            {
                var result = await _diskApi.MetaInfo.GetInfoAsync(new ResourceRequest
                                                    {
                                                        Path = pathInDisk.Text
                                                    }, CancellationToken.None);
            
                resultBox.Text = String.Empty;
                if (result.Embedded.Items.Any() == true)
                {
                    var items = result.Embedded.Items.ToList();
                    foreach (var item in items)
                    {
                        resultBox.Text += item.Path + Environment.NewLine;
                        if (item.PublicUrl != String.Empty)
                            resultBox.Text += item.PublicUrl + Environment.NewLine;
                        resultBox.Text += item.Modified + Environment.NewLine;
                        resultBox.Text += Environment.NewLine;
                    }
                }
                else
                {
                    resultBox.Text = "folder is empty";
                }
            }
            catch (Exception ex)
            {
                resultBox.Text = ex.Message;
            }
        }

        private async void publishButton_Click(object sender, EventArgs e)
        {
            try
            {
                await _diskApi.MetaInfo.PublishFolderAsync(pathInDisk.Text, CancellationToken.None);
                resultBox.Text = "file published";
            }
            catch (Exception ex)
            {
                resultBox.Text = ex.Message;
            }
        }

        private async void downloadButton_Click(object sender, EventArgs e)
        {
            try
            {
                var path = Path.Combine(downloads, pathInDisk.Text.Split('/').Last().Split(@"\").Last());
                await _diskApi.Files.DownloadFileAsync(path: pathInDisk.Text,
                                                       localFile: path,
                                                       cancellationToken: CancellationToken.None);
                resultBox.Text = "file downloaded";
            }
            catch (Exception ex)
            {
                resultBox.Text = ex.Message;
            }
        }

        private async void uploadButton_Click(object sender, EventArgs e)
        {
            try
            {
                var path = Path.Combine(pathInDisk.Text, pathToFile.Text.Split('/').Last().Split(@"\").Last());
                await _diskApi.Files.UploadFileAsync(path: path,
                                                     overwrite: false,
                                                     localFile: pathToFile.Text, 
                                                     cancellationToken: CancellationToken.None);
                resultBox.Text = "file uploaded";
            }
            catch (Exception ex)
            {
                resultBox.Text = ex.Message;
            }
        }   
    }
}
