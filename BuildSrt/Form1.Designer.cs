namespace BuildSrt;

partial class Form1
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        buttonBuildWav = new System.Windows.Forms.Button();
        openFileDialog = new System.Windows.Forms.OpenFileDialog();
        folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
        buttonConvertToScFile = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        buttonConvertToScDir = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // buttonBuildWav
        // 
        buttonBuildWav.Location = new System.Drawing.Point(104, 129);
        buttonBuildWav.Name = "buttonBuildWav";
        buttonBuildWav.Size = new System.Drawing.Size(205, 36);
        buttonBuildWav.TabIndex = 0;
        buttonBuildWav.Text = "1.选择视频文件转换为音频";
        buttonBuildWav.UseVisualStyleBackColor = true;
        buttonBuildWav.Click += buttonBuildWav_Click;
        // 
        // openFileDialog
        // 
        openFileDialog.RestoreDirectory = true;
        // 
        // buttonConvertToScFile
        // 
        buttonConvertToScFile.Location = new System.Drawing.Point(492, 139);
        buttonConvertToScFile.Name = "buttonConvertToScFile";
        buttonConvertToScFile.Size = new System.Drawing.Size(176, 36);
        buttonConvertToScFile.TabIndex = 1;
        buttonConvertToScFile.Text = "选择文件";
        buttonConvertToScFile.UseVisualStyleBackColor = true;
        buttonConvertToScFile.Click += buttonConvertToScFile_Click;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(492, 102);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(110, 24);
        label1.TabIndex = 2;
        label1.Text = "将字幕转换为简体中文";
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(104, 102);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(88, 17);
        label2.TabIndex = 3;
        label2.Text = "生成视频字幕并翻译";
        // 
        // buttonConvertToScDir
        // 
        buttonConvertToScDir.Location = new System.Drawing.Point(492, 196);
        buttonConvertToScDir.Name = "buttonConvertToScDir";
        buttonConvertToScDir.Size = new System.Drawing.Size(176, 36);
        buttonConvertToScDir.TabIndex = 4;
        buttonConvertToScDir.Text = "选择文件夹";
        buttonConvertToScDir.UseVisualStyleBackColor = true;
        buttonConvertToScDir.Click += buttonConvertToScDir_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(buttonConvertToScDir);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(buttonConvertToScFile);
        Controls.Add(buttonBuildWav);
        Text = "字幕生成器";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button buttonConvertToScDir;

    private System.Windows.Forms.Button buttonConvertToScFile;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Button buttonBuildWav;
    private System.Windows.Forms.OpenFileDialog openFileDialog;
    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;

    #endregion
}