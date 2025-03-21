﻿using OllamaSharp;

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
    public static async Task TranslateSrtAsync(string srtPath, string suffix, string model, string prompt,
        TextBox textBox)
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

        // 构建处理后的新内容
        var newLines = new List<string>();
        // 定义一个变量用于存储最近的 5 条记录
        var recentRecords = new List<string>();
        foreach (var entry in entries)
        {
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
            // 构建显示文本
            var displayText = $"{entry[0]}/{entries.Count}\r\n{result}\r\n{mergedContent}\r\n";
            // 将新内容添加到 recentRecords 的最前面
            recentRecords.Insert(0, displayText);
            // 确保 recentRecords 只保留最近的 5 条记录
            if (recentRecords.Count > 5)
                recentRecords.RemoveAt(recentRecords.Count - 1);
            // 更新 textBox 的内容
            textBox.Text = string.Join("\r\n", recentRecords);

            // 添加处理后的条目
            newLines.Add(entry[0]); // 序号
            newLines.Add(entry[1]); // 时间轴
            newLines.Add(result); // 翻译后的内容
            newLines.Add(mergedContent); // 合并后的原文
            newLines.Add(""); // 条目间空行
        }

        // 移除末尾多余的空行
        if (newLines.Count > 0 && string.IsNullOrEmpty(newLines.Last()))
        {
            newLines.RemoveAt(newLines.Count - 1);
        }

        // 生成新文件路径（原文件名加_merged）
        var newFilePath = Path.Combine(directory, $"{Path.GetFileNameWithoutExtension(srtPath)}.{suffix}.srt");

        // 写入处理后的内容
        await File.WriteAllLinesAsync(newFilePath, newLines);
    }
}