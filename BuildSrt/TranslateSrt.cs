using System.Text.RegularExpressions;
using OllamaSharp;

namespace BuildSrt;

public abstract partial class TranslateSrt
{
    [GeneratedRegex(@"<think>[\s\S]*?</think>\s*", RegexOptions.IgnoreCase, "zh-CN")]
    private static partial Regex ThinkRegexType1();

    [GeneratedRegex(@"^<think>\s*", RegexOptions.IgnoreCase, "zh-CN")]
    private static partial Regex ThinkRegexType2();

    /// <summary>
    /// 翻译字幕
    /// </summary>
    /// <param name="srtPath">原字幕路径</param>
    /// <param name="suffix">新字幕文件后缀名</param>
    /// <param name="model">ollama使用的模型名称</param>
    /// <param name="prompt">ollama的提示词</param>
    /// <param name="textBox">显示结果的文本框</param>
    /// <param name="startLine">起始处理的字幕条目序号</param>
    /// <param name="endLine">结束处理的字幕条目序号</param>
    public static async Task TranslateSrtAsync(string srtPath, string suffix, string model, string prompt,
        TextBox textBox, int startLine = 1, int endLine = -1)
    {
        var directory = Path.GetDirectoryName(srtPath);
        if (string.IsNullOrEmpty(directory))
            return;
        var ollama = new OllamaApiClient(new Uri("http://localhost:11434"))
        {
            SelectedModel = model
        };
        var chat = new Chat(ollama, prompt);

        // 读取原始字幕文件的所有行
        var lines = await File.ReadAllLinesAsync(srtPath);

        // 分割为独立的字幕条目
        var entries = new List<List<string>>();
        var currentEntry = new List<string>();

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                if (currentEntry.Count <= 0) continue;
                entries.Add(currentEntry);
                currentEntry = [];
            }
            else
            {
                currentEntry.Add(line);
            }
        }

        // 处理最后一个条目
        if (currentEntry.Count > 0)
        {
            entries.Add(currentEntry);
        }

        // 生成新文件路径
        var newFilePath = Path.Combine(directory, $"{Path.GetFileNameWithoutExtension(srtPath)}.{suffix}.srt");
        var existingEntries = new List<List<string>>();
        if (File.Exists(newFilePath))
        {
            var oldLines = await File.ReadAllLinesAsync(newFilePath);
            var temp = new List<string>();
            foreach (var line in oldLines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    if (temp.Count <= 0) continue;
                    existingEntries.Add(temp);
                    temp = [];
                }
                else
                {
                    temp.Add(line);
                }
            }

            if (temp.Count > 0)
                existingEntries.Add(temp);
        }

        // 定义参数转换
        var startIndex = Math.Max(0, startLine - 1);
        var endIndex = endLine == -1 ? entries.Count - 1 : Math.Min(entries.Count - 1, endLine - 1);

        // 检查范围是否有效
        if (startIndex > endIndex || startIndex >= entries.Count)
        {
            throw new ArgumentException("起始行或结束行超出有效范围。");
        }

        // 定义最近记录
        var recentRecords = new List<string>();
        for (var i = startIndex; i <= endIndex; i++)
        {
            var entry = entries[i];
            // 忽略无效条目（至少包含序号、时间轴和内容）
            if (entry.Count < 3)
            {
                continue;
            }

            // 插入新的记录
            recentRecords.Insert(0, "");
            if (recentRecords.Count > 5)
                recentRecords.RemoveAt(5);

            // 合并字幕内容
            var mergedContent = string.Join(" ", entry.Skip(2));
            var result = "";
            await foreach (var answerToken in chat.SendAsync(mergedContent))
            {
                result += answerToken;
                // 更新最近记录
                recentRecords[0] = $"{entry[0]}/{entries.Count}\r\n{result}\r\n{mergedContent}\r\n";
                // 更新文本框
                await textBox.InvokeAsync(() => { textBox.Text = string.Join("\r\n", recentRecords); });
            }

            // 过滤掉 <think> 和 </think> 之间的内容
            result = ThinkRegexType1().Replace(result, "");
            result = ThinkRegexType2().Replace(result, "");
            // 删除多余的回车符
            result = result.Trim();

            // 更新最近记录
            recentRecords[0] = $"{entry[0]}/{entries.Count}\r\n{result}\r\n{mergedContent}\r\n";
            // 更新文本框
            await textBox.InvokeAsync(() => { textBox.Text = string.Join("\r\n", recentRecords); });

            // 构造新的条目：序号、时间轴、译文、原文
            var newEntry = new List<string>
            {
                entry[0], // 序号
                entry[1], // 时间轴
                result, // 翻译
                mergedContent // 原文
            };

            if (i < existingEntries.Count)
                existingEntries[i] = newEntry; // 覆盖
            else
                existingEntries.Insert(i, newEntry); // 插入
        }

        // 4. 全量写回（覆盖模式）
        await using var writer = new StreamWriter(newFilePath, append: false);
        foreach (var e in existingEntries)
        {
            foreach (var line in e)
                await writer.WriteLineAsync(line);
            await writer.WriteLineAsync(); // 空行分隔
        }

        await writer.FlushAsync();
    }
}