namespace BuildSrt;

using System.Diagnostics;

public abstract class BuildWav
{
    /// <summary>
    /// 输入视频文件，输出wav文件
    /// </summary>
    /// <param name="moviePath">视频文件路径</param>
    /// <param name="ffmpegPath">ffmpeg路径</param>
    /// <returns>返回是否返回成功</returns>
    public static async Task<string?> BuildWavFromMovieAsync(string moviePath, string ffmpegPath)
    {
        var directory = Path.GetDirectoryName(moviePath);
        if (string.IsNullOrEmpty(directory) || string.IsNullOrEmpty(ffmpegPath))
            return null;
        var newPath = Path.Combine(directory, $"{Path.GetFileNameWithoutExtension(moviePath)}.wav");
        using var process = new Process();
        process.StartInfo = new ProcessStartInfo
        {
            FileName = ffmpegPath,
            Arguments = $"-i \"{moviePath}\" -ar 16000 -ac 1 -c:a pcm_s16le \"{newPath}\" -y",
            UseShellExecute = true,
            CreateNoWindow = false
        };
        try
        {
            process.Start();
            await process.WaitForExitAsync();
            return process.ExitCode == 0 ? newPath : null;
        }
        catch (Exception)
        {
            return null;
        }
    }
}