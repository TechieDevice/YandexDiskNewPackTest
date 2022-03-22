using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using YandexDisk.Client;
using YandexDisk.Client.Clients;
using YandexDisk.Client.Protocol;

namespace YandexDiskApp
{
    public partial class mainForm : Form
    {
        private IDiskApi _diskApi;

        public mainForm(IDiskApi api)
        {
            _diskApi = api;

            InitializeComponent();
        }

        private string GetDownloadsPath()
        {
            var downloads = Path.Combine(Directory.GetCurrentDirectory(), "downloads");
            if (!Directory.Exists(downloads))
            {
                var dir = new FileInfo(downloads);
                dir.Directory.CreateSubdirectory("downloads");
            }

            return downloads;
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
                var result = await GetListAsync(pathInDisk.Text, CancellationToken.None);
            
                resultBox.Text = String.Empty;
                if (result.Embedded.Items.Any() == true)
                {
                    var items = result.Embedded.Items.ToList();
                    foreach (var item in items)
                    {
                        resultBox.Text += item.Path + Environment.NewLine;
                        if (item.PublicUrl != null)
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
                var link = await PublishAsync(pathInDisk.Text, CancellationToken.None);
                resultBox.Text = "file published, link:" + link.Href;
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
                var downloads = GetDownloadsPath();
                var path = Path.Combine(downloads, pathInDisk.Text.Split('/').Last().Split(@"\").Last());

                using (FileStream fileStream = File.Create(path))
                {
                    await DownloadAsync(fileStream, pathInDisk.Text, CancellationToken.None, false);
                }

                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    resultBox.Text = "file downloaded";
                });
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
                using (FileStream fileStream = File.OpenRead(pathToFile.Text))
                {
                    await UploadAsync(path, fileStream, false, CancellationToken.None);
                }

                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    resultBox.Text = "file uploaded";
                });
            }
            catch (Exception ex)
            {
                resultBox.Text = ex.Message;
            }
        }

        private async Task<Resource> GetListAsync(string path, CancellationToken token)
        {
            return await _diskApi.MetaInfo.GetInfoAsync(new ResourceRequest { Path = path }, token);
        }

        private async Task<Link> PublishAsync(string path, CancellationToken token)
        {
            return await _diskApi.MetaInfo.PublishFolderAsync(path, token);
        }

        private async Task DownloadAsync(Stream stream, string path, CancellationToken token, bool isAwait)
        {
            using (Stream diskStream = await _diskApi.Files.DownloadFileAsync(path, token))
            {
                await diskStream.CopyToAsync(stream, bufferSize: 81920, token).ConfigureAwait(isAwait);
            }
        }

        private async Task UploadAsync(string path, Stream stream, bool isOverwrite, CancellationToken token)
        {
            await _diskApi.Files.UploadFileAsync(path: path,
                                                 overwrite: isOverwrite,
                                                 file: stream,
                                                 cancellationToken: CancellationToken.None);

        }
    }
}
