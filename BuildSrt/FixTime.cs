using System.Text;

namespace BuildSrt;

public abstract class FixTime
{
    /// <summary>
    /// 修复SRT文件中的时间戳。
    /// 将 "MM:ss,fff" 或 "HH:mm:ss,fff" 与 "MM:ss,fff" 混合的格式
    /// 统一修正为 "HH:mm:ss,fff" 格式。
    /// </summary>
    /// <param name="path">SRT文件的路径。</param>
    public static void FixSrtTime(string path)
    {
        // 1. 读取所有行到内存
        // 对于大多数SRT文件来说，一次性读入内存是高效且简单的
        var lines = File.ReadAllLines(path, Encoding.UTF8);
        var correctedLines = new List<string>(lines.Length);
        var hasChanges = false;

        // 2. 遍历每一行进行处理
        foreach (var line in lines)
        {
            // 时间戳行的明确特征是包含 "-->"
            if (line.Contains("-->"))
            {
                // 分割开始时间和结束时间
                var timeParts = line.Split(["-->"], StringSplitOptions.None);
                if (timeParts.Length == 2)
                {
                    var startTime = timeParts[0].Trim();
                    var endTime = timeParts[1].Trim();

                    // 修复开始和结束时间
                    var fixedStartTime = FixSingleTimestamp(startTime);
                    var fixedEndTime = FixSingleTimestamp(endTime);

                    // 重新组合成新行
                    var correctedLine = $"{fixedStartTime} --> {fixedEndTime}";

                    // 如果有变化，则记录下来
                    if (correctedLine != line)
                    {
                        hasChanges = true;
                    }

                    correctedLines.Add(correctedLine);
                }
                else
                {
                    // 格式异常，直接保留原行
                    correctedLines.Add(line);
                }
            }
            else
            {
                // 非时间戳行（序号、字幕、空行）直接保留
                correctedLines.Add(line);
            }
        }

        // 3. 如果文件内容有变动，则写回文件
        if (hasChanges)
        {
            File.WriteAllLines(path, correctedLines, Encoding.UTF8);
        }
    }

    /// <summary>
    /// 辅助函数：修复单个时间戳字符串
    /// </summary>
    /// <param name="timestamp">时间戳字符串，例如 "01:14,309" 或 "00:01:17,219"</param>
    /// <returns>修复后的时间戳，例如 "00:01:14,309"</returns>
    private static string FixSingleTimestamp(string timestamp)
    {
        // 正确的格式 "HH:mm:ss,fff" 有两个冒号
        // 错误的格式 "mm:ss,fff" 只有一个冒号
        if (timestamp.Count(c => c == ':') == 1)
        {
            // 在前面补上 "00:"
            return "00:" + timestamp;
        }

        // 如果格式正确，直接返回原字符串
        return timestamp;
    }
}