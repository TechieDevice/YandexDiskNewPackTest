
namespace YandexDiskApp
{
    partial class mainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.getListButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.pathToFile = new System.Windows.Forms.TextBox();
            this.loadButton = new System.Windows.Forms.Button();
            this.pathInDisk = new System.Windows.Forms.TextBox();
            this.resultBox = new System.Windows.Forms.TextBox();
            this.uploadButton = new System.Windows.Forms.Button();
            this.downloadButton = new System.Windows.Forms.Button();
            this.publishButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // getListButton
            // 
            this.getListButton.Location = new System.Drawing.Point(495, 144);
            this.getListButton.Name = "getListButton";
            this.getListButton.Size = new System.Drawing.Size(146, 29);
            this.getListButton.TabIndex = 0;
            this.getListButton.Text = "Список файлов";
            this.getListButton.UseVisualStyleBackColor = true;
            this.getListButton.Click += new System.EventHandler(this.getListButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "Загрузить файл...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Путь до файла в облаке";
            // 
            // pathToFile
            // 
            this.pathToFile.Location = new System.Drawing.Point(191, 73);
            this.pathToFile.Name = "pathToFile";
            this.pathToFile.Size = new System.Drawing.Size(450, 27);
            this.pathToFile.TabIndex = 2;
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(39, 72);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(146, 28);
            this.loadButton.TabIndex = 3;
            this.loadButton.Text = "Путь до файла";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // pathInDisk
            // 
            this.pathInDisk.Location = new System.Drawing.Point(219, 23);
            this.pathInDisk.Name = "pathInDisk";
            this.pathInDisk.Size = new System.Drawing.Size(422, 27);
            this.pathInDisk.TabIndex = 4;
            // 
            // resultBox
            // 
            this.resultBox.Location = new System.Drawing.Point(39, 230);
            this.resultBox.Multiline = true;
            this.resultBox.Name = "resultBox";
            this.resultBox.ReadOnly = true;
            this.resultBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultBox.Size = new System.Drawing.Size(602, 375);
            this.resultBox.TabIndex = 5;
            // 
            // uploadButton
            // 
            this.uploadButton.Location = new System.Drawing.Point(39, 144);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(146, 29);
            this.uploadButton.TabIndex = 6;
            this.uploadButton.Text = "Загрузить";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(191, 144);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(146, 29);
            this.downloadButton.TabIndex = 7;
            this.downloadButton.Text = "Скачать";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // publishButton
            // 
            this.publishButton.Location = new System.Drawing.Point(343, 144);
            this.publishButton.Name = "publishButton";
            this.publishButton.Size = new System.Drawing.Size(146, 29);
            this.publishButton.TabIndex = 8;
            this.publishButton.Text = "Открыть доступ";
            this.publishButton.UseVisualStyleBackColor = true;
            this.publishButton.Click += new System.EventHandler(this.publishButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Результаты запроса";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(228, 207);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(397, 17);
            this.progressBar.TabIndex = 10;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 633);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.publishButton);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.uploadButton);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.pathInDisk);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.pathToFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.getListButton);
            this.Name = "mainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getListButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pathToFile;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.TextBox pathInDisk;
        private System.Windows.Forms.TextBox resultBox;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Button publishButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

