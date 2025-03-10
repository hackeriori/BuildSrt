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
        SuspendLayout();
        // 
        // buttonBuildWav
        // 
        buttonBuildWav.Location = new System.Drawing.Point(194, 128);
        buttonBuildWav.Name = "buttonBuildWav";
        buttonBuildWav.Size = new System.Drawing.Size(106, 36);
        buttonBuildWav.TabIndex = 0;
        buttonBuildWav.Text = "选择视频文件转换为音频";
        buttonBuildWav.UseVisualStyleBackColor = true;
        buttonBuildWav.Click += buttonBuildWav_Click;
        // 
        // openFileDialog
        // 
        openFileDialog.Filter = "视频文件|*.mp4;*.avi;*.mkv;*.mov;*.wmv|所有文件|*.*";
        openFileDialog.RestoreDirectory = true;
        openFileDialog.Title = "选择视频文件";
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(buttonBuildWav);
        Text = "字幕生成器";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button buttonBuildWav;
    private System.Windows.Forms.OpenFileDialog openFileDialog;

    #endregion
}