using System.Text;

namespace BuildSrt;

using System.Diagnostics;

public abstract class GetSrt
{
    /// <summary>
    /// 从音频文件中获取字幕
    /// </summary>
    /// <param name="wavPath">音频路径</param>
    /// <param name="whisperPath">whisper路径</param>
    /// <param name="modelPath">whisper模型名称</param>
    /// <param name="entropyThreshold">解码器失败阈值，增加可提高识别率，默认值2.4</param>
    /// <param name="temperatureInc">温度增量，减少利于断句，默认值0.2，范围 0-1</param>
    /// <param name="offsetTime">开始时间</param>
    /// <param name="duration">持续时间</param>
    /// <param name="language">默认值en，自动检测可用 'auto'</param>
    public static async Task GetSrtFromWavAsync(string wavPath, string whisperPath, string modelPath,
        decimal? entropyThreshold, decimal? temperatureInc, int? offsetTime, int? duration, string? language)
    {
        var directory = Path.GetDirectoryName(wavPath);
        if (string.IsNullOrEmpty(directory))
            return;
        var wavName = Path.GetFileNameWithoutExtension(wavPath);
        var newPath = Path.Combine(directory, wavName);
        var newSrtIndex = 1;
        while (File.Exists(newPath + ".srt"))
        {
            newPath = Path.Combine(directory, $"{wavName}{newSrtIndex++}");
        }

        using var process = new Process();
        var arguments = $"-m \"{modelPath}\" -sow -fa -osrt";
        if (entropyThreshold != null)
            arguments += $" -et {entropyThreshold}";
        if (temperatureInc != null)
            arguments += $" -tpi {temperatureInc}";
        if (offsetTime != null)
            arguments += $" -ot {offsetTime}";
        if (duration != null)
            arguments += $" -d {duration}";
        if (string.IsNullOrEmpty(language))
            arguments += $" -l {language}";
        arguments += $" -of \"{newPath}\" \"{wavPath}\"";
        process.StartInfo = new ProcessStartInfo
        {
            FileName = whisperPath,
            Arguments = arguments,
            UseShellExecute = true,
            CreateNoWindow = false,
        };
        try
        {
            process.Start();
            await process.WaitForExitAsync();
        }
        catch (Exception)
        {
            // ignored
        }
    }
}