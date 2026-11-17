using System.Text;

namespace Alura.ScreenSound.Modelos;

public static class PromptBuilder
{
    public static string BuildBasicPrompt(string introduction, List<string> lines)
    {
        StringBuilder prompt = new StringBuilder();
        prompt.AppendLine(introduction);

        foreach (string line in lines)
        {
            prompt.AppendLine(line);
        }

        return prompt.ToString();
    }
}
