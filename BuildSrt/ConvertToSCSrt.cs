using System.Text;
using OpenCCNET;

namespace BuildSrt;

public abstract class ConvertToScSrt
{
    /// <summary>
    /// 将srt文件或文件夹内的srt文件转换为简体中文
    /// </summary>
    /// <param name="path">文件（夹）路径</param>
    public static void Convert(string path)
    {
        ZhConverter.Initialize();
        if (File.Exists(path) && Path.GetExtension(path).Equals(".srt", StringComparison.CurrentCultureIgnoreCase))
        {
            ConvertSingleSrtFile(path);
        }
        else if (Directory.Exists(path))
        {
            var srtFiles = Directory.GetFiles(path, "*.srt", SearchOption.AllDirectories);
            foreach (var file in srtFiles)
            {
                ConvertSingleSrtFile(file);
            }
        }
    }

    /// <summary>
    /// 将单个srt文件转换为简体中文
    /// </summary>
    /// <param name="filePath">文件路径</param>
    private static void ConvertSingleSrtFile(string filePath)
    {
        var content = File.ReadAllText(filePath, Encoding.UTF8);
        var simplifiedContent = ZhConverter.HantToHans(content);
        File.WriteAllText(filePath, simplifiedContent, Encoding.UTF8);
    }
}