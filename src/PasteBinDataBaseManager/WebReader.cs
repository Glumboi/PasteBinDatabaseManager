namespace PasteBinDatabaseManager;

public class WebReader
{
    public static async Task<IEnumerable<string>> ReadFromUrl(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            using (HttpResponseMessage response = await client.GetAsync(url))
            {
                // Read the response content as a string
                string content = await response.Content.ReadAsStringAsync();

                // Split the string into an array of lines
                string[] lines = content.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                // Output the lines to the console
                return lines;
            }
        }
    }
}