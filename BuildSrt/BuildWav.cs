namespace BuildSrt;

using System.Diagnostics;

public abstract class BuildWav
{
    /// <summary>
    /// 输入视频文件，输出wav文件
    /// </summary>
    /// <param name="moviePath"></param>
    /// <returns>返回是否返回成功</returns>
    public static async Task<bool> BuildWavFromMovieAsync(string moviePath)
    {
        var directory = Path.GetDirectoryName(moviePath);
        if (string.IsNullOrEmpty(directory))
            return false;

        var newPath = Path.Combine(directory, $"{Path.GetFileNameWithoutExtension(moviePath)}.wav");

        using var process = new Process();
        process.StartInfo = new ProcessStartInfo
        {
            FileName = "D:\\Programe\\ffmpeg\\ffmpeg.exe",
            Arguments = $"-i \"{moviePath}\" -ar 16000 -ac 1 -c:a pcm_s16le \"{newPath}\" -y",
            UseShellExecute = true,
            CreateNoWindow = false
        };

        try
        {
            process.Start();
            await process.WaitForExitAsync();
            return process.ExitCode == 0;
        }
        catch (Exception)
        {
            return false;
        }
    }
}