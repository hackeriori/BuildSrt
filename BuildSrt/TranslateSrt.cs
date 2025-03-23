using OllamaSharp;

namespace BuildSrt;

public abstract class TranslateSrt
{
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
        await using var writer = new StreamWriter(newFilePath, append: true);

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
        for (var i = 0; i < entries.Count; i++)
        {
            // 跳过不在范围的条目
            if (i < startIndex || i > endIndex) continue;

            var entry = entries[i];
            // 忽略无效条目（至少包含序号、时间轴和内容）
            if (entry.Count < 3)
            {
                continue;
            }

            // 合并字幕内容
            var mergedContent = string.Join(" ", entry.Skip(2));
            var result = "";
            await foreach (var answerToken in chat.SendAsync(mergedContent))
                result += answerToken;
            // 构建显示文本（使用原始条目序号）
            var displayText = $"{entry[0]}/{entries.Count}\r\n{result}\r\n{mergedContent}\r\n";
            // 更新最近记录
            recentRecords.Insert(0, displayText);
            if (recentRecords.Count > 5)
                recentRecords.RemoveAt(5);

            // 更新文本框
            textBox.Text = string.Join("\r\n", recentRecords);

            // 写入文件
            await writer.WriteLineAsync(entry[0]); // 序号
            await writer.WriteLineAsync(entry[1]); // 时间轴
            await writer.WriteLineAsync(result);   // 翻译内容
            await writer.WriteLineAsync(mergedContent); // 原文
            await writer.WriteLineAsync();         // 空行分隔
        }
    }
}