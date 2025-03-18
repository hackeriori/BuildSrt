using Microsoft.Extensions.Configuration;

namespace BuildSrt;

public partial class Form1 : Form
{
    private readonly IConfigurationRoot _configuration;
    private string? _wavPath;
    private string? _srtPath;

    public Form1()
    {
        InitializeComponent();
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appSettings.json", optional: false);
        _configuration = builder.Build();
        // 获取模型列表
        var whisperPath = _configuration["AppSettings:whisperPath"];
        var directory = Path.Combine(Path.GetDirectoryName(whisperPath)!, "models");
        if (!Directory.Exists(directory)) return;
        var files = Directory.GetFiles(directory, "*.bin");
        foreach (var file in files)
        {
            comboBoxModel.Items.Add(Path.GetFileName(file));
        }

        // 将名称为ggml-large-v3.bin的模型设置为默认值
        comboBoxModel.SelectedItem = comboBoxModel.Items.Cast<string>().FirstOrDefault(x => x == "ggml-large-v3.bin");
    }

    private void buttonBuildWav_Click(object sender, EventArgs e)
    {
        openFileDialog.Filter = "视频文件|*.mp4;*.avi;*.mkv;*.mov;*.wmv|所有文件|*.*";
        openFileDialog.Title = "选择视频文件";
        if (openFileDialog.ShowDialog() != DialogResult.OK) return;
        var ffmpegPath = _configuration["AppSettings:ffmpegPath"];
        if (string.IsNullOrEmpty(ffmpegPath) || !File.Exists(ffmpegPath))
        {
            MessageBox.Show("未找到ffmpeg");
            return;
        }

        _ = BuildWavFromMovieShellAsync(openFileDialog.FileName, ffmpegPath);
    }

    private async Task BuildWavFromMovieShellAsync(string fileName, string ffmpegPath)
    {
        _wavPath = await BuildWav.BuildWavFromMovieAsync(fileName, ffmpegPath);
    }

    private void buttonConvertToScFile_Click(object sender, EventArgs e)
    {
        openFileDialog.Filter = "字幕文件|*.srt";
        openFileDialog.Title = "选择字幕文件";
        if (openFileDialog.ShowDialog() != DialogResult.OK) return;
        ConvertToScSrt.Convert(openFileDialog.FileName);
        MessageBox.Show("转换完成");
    }

    private void buttonConvertToScDir_Click(object sender, EventArgs e)
    {
        if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;
        ConvertToScSrt.Convert(folderBrowserDialog.SelectedPath);
        MessageBox.Show("转换完成");
    }

    private void buttonGetSrt_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(_wavPath))
        {
            openFileDialog.Filter = "音频文件|*.wav";
            openFileDialog.Title = "选择音频文件";
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            _wavPath = openFileDialog.FileName;
        }

        var whisperPath = _configuration["AppSettings:whisperPath"];
        if (string.IsNullOrEmpty(whisperPath) || !File.Exists(whisperPath))
        {
            MessageBox.Show("未找到whisper.cpp");
            return;
        }

        if (string.IsNullOrEmpty(comboBoxModel.SelectedItem as string))
        {
            MessageBox.Show("未选择模型");
            return;
        }

        var modelPath = Path.Combine(Path.GetDirectoryName(whisperPath)!, "models",
            (comboBoxModel.SelectedItem as string)!);

        int? offsetTime = null;
        if (numericUpDownStartHour.Value != 0 || numericUpDownStartMinute.Value != 0 ||
            numericUpDownStartSecond.Value != 0)
            offsetTime = ((int)numericUpDownStartHour.Value * 3600 + (int)numericUpDownStartMinute.Value * 60 +
                          (int)numericUpDownStartSecond.Value) * 1000;
        int? duration = null;
        if (numericUpDownEndHour.Value != 0 || numericUpDownEndMinute.Value != 0 || numericUpDownEndSecond.Value != 0)
        {
            duration = ((int)numericUpDownEndHour.Value * 3600 + (int)numericUpDownEndMinute.Value * 60 +
                        (int)numericUpDownEndSecond.Value) * 1000;
            if (offsetTime != null)
                duration -= offsetTime;
        }

        _ = GetSrtFromWavShellAsync(_wavPath, whisperPath, modelPath, numericUpDownET.Value,
            numericUpDownTPI.Value, offsetTime, duration, textBoxLG.Text);
    }

    private async Task GetSrtFromWavShellAsync(string wavPath, string whisperPath, string modelPath,
        decimal? entropyThreshold, decimal? temperatureInc, int? offsetTime, int? duration, string? language)
    {
        _srtPath = await GetSrt.GetSrtFromWavAsync(wavPath, whisperPath, modelPath, entropyThreshold, temperatureInc,
            offsetTime, duration, language);
    }

    private void buttonTranslate_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(_srtPath))
        {
            openFileDialog.Filter = "字幕文件|*.srt";
            openFileDialog.Title = "选择字幕文件";
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            _srtPath = openFileDialog.FileName;
        }

        var model = _configuration["AppSettings:model"];
        if (string.IsNullOrEmpty(model))
        {
            MessageBox.Show("未配置模型");
            return;
        }

        var prompt = _configuration["AppSettings:prompt"];
        if (string.IsNullOrEmpty(prompt))
        {
            MessageBox.Show("未配置提示词");
            return;
        }

        _ = TranslateSrt.TranslateSrtAsync(_srtPath, textBoxSuffix.Text, model, prompt, textBoxResult);
    }

    private void buttonSelectSrt_Click(object sender, EventArgs e)
    {
        openFileDialog.Filter = "字幕文件|*.srt";
        openFileDialog.Title = "选择字幕文件";
        if (openFileDialog.ShowDialog() != DialogResult.OK) return;
        _srtPath = openFileDialog.FileName;
    }
}