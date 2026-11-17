using GenerativeAI;

namespace Google.Modelos.Gemini;

public class GeminiService
{
    private readonly GenerativeModel _model;

    public async Task<string> GetResponseAsync(string prompt)
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));

        try
        {
            var response = await _model.GenerateContentAsync(prompt, cts.Token);
            return response.Text;
        }
        catch (OperationCanceledException)
        {
            return "The request timed out.";
        }
        catch (Exception ex)
        {
            return $"An error occurred: {ex.Message}";
        }
    }

    public GeminiService(string apiKey)
    {
        var GoogleAi = new GoogleAi(apiKey);
        _model = GoogleAi.CreateGenerativeModel("gemma-3-27b-it");
    }
}
