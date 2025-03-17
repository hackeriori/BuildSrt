﻿namespace BuildSrt;

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
        buttonGetSrt = new System.Windows.Forms.Button();
        label3 = new System.Windows.Forms.Label();
        numericUpDownStartHour = new System.Windows.Forms.NumericUpDown();
        numericUpDownStartMinute = new System.Windows.Forms.NumericUpDown();
        numericUpDownStartSecond = new System.Windows.Forms.NumericUpDown();
        label4 = new System.Windows.Forms.Label();
        label5 = new System.Windows.Forms.Label();
        label6 = new System.Windows.Forms.Label();
        label7 = new System.Windows.Forms.Label();
        label8 = new System.Windows.Forms.Label();
        label9 = new System.Windows.Forms.Label();
        numericUpDownEndSecond = new System.Windows.Forms.NumericUpDown();
        numericUpDownEndMinute = new System.Windows.Forms.NumericUpDown();
        numericUpDownEndHour = new System.Windows.Forms.NumericUpDown();
        label10 = new System.Windows.Forms.Label();
        comboBoxModel = new System.Windows.Forms.ComboBox();
        label11 = new System.Windows.Forms.Label();
        label12 = new System.Windows.Forms.Label();
        numericUpDownET = new System.Windows.Forms.NumericUpDown();
        label13 = new System.Windows.Forms.Label();
        numericUpDownTPI = new System.Windows.Forms.NumericUpDown();
        label14 = new System.Windows.Forms.Label();
        label15 = new System.Windows.Forms.Label();
        label16 = new System.Windows.Forms.Label();
        textBoxLG = new System.Windows.Forms.TextBox();
        label17 = new System.Windows.Forms.Label();
        buttonSelectWav = new System.Windows.Forms.Button();
        buttonSelectSrt = new System.Windows.Forms.Button();
        buttonTranslate = new System.Windows.Forms.Button();
        textBoxSuffix = new System.Windows.Forms.TextBox();
        label18 = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)numericUpDownStartHour).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDownStartMinute).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDownStartSecond).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDownEndSecond).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDownEndMinute).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDownEndHour).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDownET).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDownTPI).BeginInit();
        SuspendLayout();
        // 
        // buttonBuildWav
        // 
        buttonBuildWav.Location = new System.Drawing.Point(104, 58);
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
        buttonConvertToScFile.Location = new System.Drawing.Point(104, 297);
        buttonConvertToScFile.Name = "buttonConvertToScFile";
        buttonConvertToScFile.Size = new System.Drawing.Size(176, 36);
        buttonConvertToScFile.TabIndex = 1;
        buttonConvertToScFile.Text = "选择文件";
        buttonConvertToScFile.UseVisualStyleBackColor = true;
        buttonConvertToScFile.Click += buttonConvertToScFile_Click;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(104, 260);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(110, 24);
        label1.TabIndex = 2;
        label1.Text = "将字幕转换为简体中文";
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(104, 28);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(88, 17);
        label2.TabIndex = 3;
        label2.Text = "生成视频字幕并翻译";
        // 
        // buttonConvertToScDir
        // 
        buttonConvertToScDir.Location = new System.Drawing.Point(104, 354);
        buttonConvertToScDir.Name = "buttonConvertToScDir";
        buttonConvertToScDir.Size = new System.Drawing.Size(176, 36);
        buttonConvertToScDir.TabIndex = 4;
        buttonConvertToScDir.Text = "选择文件夹";
        buttonConvertToScDir.UseVisualStyleBackColor = true;
        buttonConvertToScDir.Click += buttonConvertToScDir_Click;
        // 
        // buttonGetSrt
        // 
        buttonGetSrt.Location = new System.Drawing.Point(443, 313);
        buttonGetSrt.Name = "buttonGetSrt";
        buttonGetSrt.Size = new System.Drawing.Size(205, 36);
        buttonGetSrt.TabIndex = 6;
        buttonGetSrt.Text = "2.识别音频生成字幕";
        buttonGetSrt.UseVisualStyleBackColor = true;
        buttonGetSrt.Click += buttonGetSrt_Click;
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(443, 28);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(60, 23);
        label3.TabIndex = 7;
        label3.Text = "开始时间";
        // 
        // numericUpDownStartHour
        // 
        numericUpDownStartHour.Location = new System.Drawing.Point(443, 54);
        numericUpDownStartHour.Name = "numericUpDownStartHour";
        numericUpDownStartHour.Size = new System.Drawing.Size(53, 23);
        numericUpDownStartHour.TabIndex = 8;
        // 
        // numericUpDownStartMinute
        // 
        numericUpDownStartMinute.Location = new System.Drawing.Point(522, 54);
        numericUpDownStartMinute.Name = "numericUpDownStartMinute";
        numericUpDownStartMinute.Size = new System.Drawing.Size(49, 23);
        numericUpDownStartMinute.TabIndex = 9;
        // 
        // numericUpDownStartSecond
        // 
        numericUpDownStartSecond.Location = new System.Drawing.Point(594, 54);
        numericUpDownStartSecond.Name = "numericUpDownStartSecond";
        numericUpDownStartSecond.Size = new System.Drawing.Size(54, 23);
        numericUpDownStartSecond.TabIndex = 10;
        // 
        // label4
        // 
        label4.Location = new System.Drawing.Point(501, 54);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(15, 23);
        label4.TabIndex = 11;
        label4.Text = "时";
        // 
        // label5
        // 
        label5.Location = new System.Drawing.Point(575, 54);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(20, 23);
        label5.TabIndex = 12;
        label5.Text = "分";
        // 
        // label6
        // 
        label6.Location = new System.Drawing.Point(654, 54);
        label6.Name = "label6";
        label6.Size = new System.Drawing.Size(20, 23);
        label6.TabIndex = 13;
        label6.Text = "秒";
        // 
        // label7
        // 
        label7.Location = new System.Drawing.Point(654, 113);
        label7.Name = "label7";
        label7.Size = new System.Drawing.Size(20, 23);
        label7.TabIndex = 20;
        label7.Text = "秒";
        // 
        // label8
        // 
        label8.Location = new System.Drawing.Point(575, 113);
        label8.Name = "label8";
        label8.Size = new System.Drawing.Size(20, 23);
        label8.TabIndex = 19;
        label8.Text = "分";
        // 
        // label9
        // 
        label9.Location = new System.Drawing.Point(501, 113);
        label9.Name = "label9";
        label9.Size = new System.Drawing.Size(15, 23);
        label9.TabIndex = 18;
        label9.Text = "时";
        // 
        // numericUpDownEndSecond
        // 
        numericUpDownEndSecond.Location = new System.Drawing.Point(594, 113);
        numericUpDownEndSecond.Name = "numericUpDownEndSecond";
        numericUpDownEndSecond.Size = new System.Drawing.Size(54, 23);
        numericUpDownEndSecond.TabIndex = 17;
        // 
        // numericUpDownEndMinute
        // 
        numericUpDownEndMinute.Location = new System.Drawing.Point(522, 113);
        numericUpDownEndMinute.Name = "numericUpDownEndMinute";
        numericUpDownEndMinute.Size = new System.Drawing.Size(49, 23);
        numericUpDownEndMinute.TabIndex = 16;
        // 
        // numericUpDownEndHour
        // 
        numericUpDownEndHour.Location = new System.Drawing.Point(443, 113);
        numericUpDownEndHour.Name = "numericUpDownEndHour";
        numericUpDownEndHour.Size = new System.Drawing.Size(53, 23);
        numericUpDownEndHour.TabIndex = 15;
        // 
        // label10
        // 
        label10.Location = new System.Drawing.Point(443, 87);
        label10.Name = "label10";
        label10.Size = new System.Drawing.Size(60, 23);
        label10.TabIndex = 14;
        label10.Text = "结束时间";
        // 
        // comboBoxModel
        // 
        comboBoxModel.FormattingEnabled = true;
        comboBoxModel.Location = new System.Drawing.Point(509, 154);
        comboBoxModel.Name = "comboBoxModel";
        comboBoxModel.Size = new System.Drawing.Size(202, 25);
        comboBoxModel.TabIndex = 21;
        // 
        // label11
        // 
        label11.Location = new System.Drawing.Point(443, 156);
        label11.Name = "label11";
        label11.Size = new System.Drawing.Size(60, 23);
        label11.TabIndex = 22;
        label11.Text = "选择模型";
        // 
        // label12
        // 
        label12.Location = new System.Drawing.Point(443, 199);
        label12.Name = "label12";
        label12.Size = new System.Drawing.Size(92, 23);
        label12.TabIndex = 23;
        label12.Text = "解码器失败阈值";
        // 
        // numericUpDownET
        // 
        numericUpDownET.DecimalPlaces = 2;
        numericUpDownET.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
        numericUpDownET.Location = new System.Drawing.Point(541, 199);
        numericUpDownET.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
        numericUpDownET.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
        numericUpDownET.Name = "numericUpDownET";
        numericUpDownET.Size = new System.Drawing.Size(54, 23);
        numericUpDownET.TabIndex = 24;
        numericUpDownET.Value = new decimal(new int[] { 24, 0, 0, 65536 });
        // 
        // label13
        // 
        label13.Location = new System.Drawing.Point(476, 240);
        label13.Name = "label13";
        label13.Size = new System.Drawing.Size(59, 23);
        label13.TabIndex = 25;
        label13.Text = "温度增量";
        // 
        // numericUpDownTPI
        // 
        numericUpDownTPI.DecimalPlaces = 2;
        numericUpDownTPI.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
        numericUpDownTPI.Location = new System.Drawing.Point(542, 239);
        numericUpDownTPI.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
        numericUpDownTPI.Name = "numericUpDownTPI";
        numericUpDownTPI.Size = new System.Drawing.Size(53, 23);
        numericUpDownTPI.TabIndex = 26;
        numericUpDownTPI.Value = new decimal(new int[] { 2, 0, 0, 65536 });
        // 
        // label14
        // 
        label14.Location = new System.Drawing.Point(601, 240);
        label14.Name = "label14";
        label14.Size = new System.Drawing.Size(83, 23);
        label14.TabIndex = 27;
        label14.Text = "减少利于断句";
        // 
        // label15
        // 
        label15.Location = new System.Drawing.Point(601, 199);
        label15.Name = "label15";
        label15.Size = new System.Drawing.Size(110, 23);
        label15.TabIndex = 28;
        label15.Text = "增加可提高识别率";
        // 
        // label16
        // 
        label16.Location = new System.Drawing.Point(476, 276);
        label16.Name = "label16";
        label16.Size = new System.Drawing.Size(59, 23);
        label16.TabIndex = 29;
        label16.Text = "识别语言";
        // 
        // textBoxLG
        // 
        textBoxLG.Location = new System.Drawing.Point(541, 274);
        textBoxLG.Name = "textBoxLG";
        textBoxLG.Size = new System.Drawing.Size(53, 23);
        textBoxLG.TabIndex = 30;
        textBoxLG.Text = "en";
        // 
        // label17
        // 
        label17.Location = new System.Drawing.Point(601, 276);
        label17.Name = "label17";
        label17.Size = new System.Drawing.Size(117, 23);
        label17.TabIndex = 31;
        label17.Text = "自动检测可用 \'auto\'";
        // 
        // buttonSelectWav
        // 
        buttonSelectWav.Location = new System.Drawing.Point(104, 100);
        buttonSelectWav.Name = "buttonSelectWav";
        buttonSelectWav.Size = new System.Drawing.Size(205, 36);
        buttonSelectWav.TabIndex = 32;
        buttonSelectWav.Text = "1.选择已有音频文件";
        buttonSelectWav.UseVisualStyleBackColor = true;
        buttonSelectWav.Click += buttonSelectWav_Click;
        // 
        // buttonSelectSrt
        // 
        buttonSelectSrt.Location = new System.Drawing.Point(104, 143);
        buttonSelectSrt.Name = "buttonSelectSrt";
        buttonSelectSrt.Size = new System.Drawing.Size(205, 36);
        buttonSelectSrt.TabIndex = 33;
        buttonSelectSrt.Text = "1.选择已有字幕文件";
        buttonSelectSrt.UseVisualStyleBackColor = true;
        buttonSelectSrt.Click += buttonSelectSrt_Click;
        // 
        // buttonTranslate
        // 
        buttonTranslate.Location = new System.Drawing.Point(443, 399);
        buttonTranslate.Name = "buttonTranslate";
        buttonTranslate.Size = new System.Drawing.Size(205, 36);
        buttonTranslate.TabIndex = 34;
        buttonTranslate.Text = "3.翻译字幕内容";
        buttonTranslate.UseVisualStyleBackColor = true;
        buttonTranslate.Click += buttonTranslate_Click;
        // 
        // textBoxSuffix
        // 
        textBoxSuffix.Location = new System.Drawing.Point(505, 365);
        textBoxSuffix.Name = "textBoxSuffix";
        textBoxSuffix.Size = new System.Drawing.Size(143, 23);
        textBoxSuffix.TabIndex = 35;
        textBoxSuffix.Text = "中英.ZH";
        // 
        // label18
        // 
        label18.Location = new System.Drawing.Point(442, 367);
        label18.Name = "label18";
        label18.Size = new System.Drawing.Size(61, 23);
        label18.TabIndex = 36;
        label18.Text = "字幕后缀";
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 470);
        Controls.Add(label18);
        Controls.Add(textBoxSuffix);
        Controls.Add(buttonTranslate);
        Controls.Add(buttonSelectSrt);
        Controls.Add(buttonSelectWav);
        Controls.Add(label17);
        Controls.Add(textBoxLG);
        Controls.Add(label16);
        Controls.Add(label15);
        Controls.Add(label14);
        Controls.Add(numericUpDownTPI);
        Controls.Add(label13);
        Controls.Add(numericUpDownET);
        Controls.Add(label12);
        Controls.Add(label11);
        Controls.Add(comboBoxModel);
        Controls.Add(label7);
        Controls.Add(label8);
        Controls.Add(label9);
        Controls.Add(numericUpDownEndSecond);
        Controls.Add(numericUpDownEndMinute);
        Controls.Add(numericUpDownEndHour);
        Controls.Add(label10);
        Controls.Add(label6);
        Controls.Add(label5);
        Controls.Add(label4);
        Controls.Add(numericUpDownStartSecond);
        Controls.Add(numericUpDownStartMinute);
        Controls.Add(numericUpDownStartHour);
        Controls.Add(label3);
        Controls.Add(buttonGetSrt);
        Controls.Add(buttonConvertToScDir);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(buttonConvertToScFile);
        Controls.Add(buttonBuildWav);
        Text = "字幕生成器";
        ((System.ComponentModel.ISupportInitialize)numericUpDownStartHour).EndInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDownStartMinute).EndInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDownStartSecond).EndInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDownEndSecond).EndInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDownEndMinute).EndInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDownEndHour).EndInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDownET).EndInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDownTPI).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.TextBox textBoxSuffix;
    private System.Windows.Forms.Label label18;

    private System.Windows.Forms.Button buttonTranslate;

    private System.Windows.Forms.Button buttonSelectSrt;

    private System.Windows.Forms.Button buttonSelectWav;

    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.TextBox textBoxLG;
    private System.Windows.Forms.Label label17;

    private System.Windows.Forms.NumericUpDown numericUpDownTPI;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Label label15;

    private System.Windows.Forms.Label label13;

    private System.Windows.Forms.NumericUpDown numericUpDownET;

    private System.Windows.Forms.Label label12;

    private System.Windows.Forms.ComboBox comboBoxModel;
    private System.Windows.Forms.Label label11;

    private System.Windows.Forms.NumericUpDown numericUpDownStartMinute;
    private System.Windows.Forms.NumericUpDown numericUpDownStartSecond;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.NumericUpDown numericUpDownEndSecond;
    private System.Windows.Forms.NumericUpDown numericUpDownEndMinute;
    private System.Windows.Forms.NumericUpDown numericUpDownEndHour;
    private System.Windows.Forms.Label label10;

    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.NumericUpDown numericUpDownStartHour;

    private System.Windows.Forms.Button buttonGetSrt;

    private System.Windows.Forms.Button buttonConvertToScDir;

    private System.Windows.Forms.Button buttonConvertToScFile;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Button buttonBuildWav;
    private System.Windows.Forms.OpenFileDialog openFileDialog;
    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;

    #endregion
}