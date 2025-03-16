using Microsoft.Extensions.Configuration;

namespace BuildSrt;

public partial class Form1 : Form
{
    private readonly IConfigurationRoot _configuration;
    private string? _wavPath;

    public Form1()
    {
        InitializeComponent();
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appSettings.json", optional: false);
        _configuration = builder.Build();
    }

    private async void buttonBuildWav_Click(object sender, EventArgs e)
    {
        openFileDialog.Filter = "视频文件|*.mp4;*.avi;*.mkv;*.mov;*.wmv|所有文件|*.*";
        openFileDialog.Title = "选择视频文件";
        if (openFileDialog.ShowDialog() != DialogResult.OK) return;
        var ffmpegPath = _configuration["AppSettings:ffmpegPath"];
        _wavPath = await BuildWav.BuildWavFromMovieAsync(openFileDialog.FileName, ffmpegPath);
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
}