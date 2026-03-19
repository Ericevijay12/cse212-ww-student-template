using System.Text.Json;

public static class SetsAndMaps
{
    // Problem 1: Find Pairs
    public static string[] FindPairs(string[] words)
    {
        var result = new List<string>();
        var seen = new HashSet<string>();
        foreach (var word in words)
        {
            string reversed = new string(new char[] { word[1], word[0] });
            if (seen.Contains(reversed))
            {
                result.Add($"{reversed} & {word}");
            }
            else
            {
                seen.Add(word);
            }
        }
        return result.ToArray();
    }

    // Problem 2: Summarize Degrees
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            if (fields.Length > 4) {
                string degree = fields[4].Trim();
                if (degrees.ContainsKey(degree))
                    degrees[degree]++;
                else
                    degrees[degree] = 1;
            }
        }
        return degrees;
    }

    // Problem 3: Anagrams
    public static bool IsAnagram(string word1, string word2)
    {
        string clean1 = word1.Replace(" ", "").ToLower();
        string clean2 = word2.Replace(" ", "").ToLower();

        if (clean1.Length != clean2.Length) return false;

        var counts = new Dictionary<char, int>();
        foreach (var c in clean1) {
            counts[c] = counts.GetValueOrDefault(c) + 1;
        }
        foreach (var c in clean2) {
            if (!counts.ContainsKey(c) || counts[c] == 0) return false;
            counts[c]--;
        }
        return true;
    }

    // Problem 5: Earthquake Summary
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        return featureCollection.Features
            .Select(f => $"{f.Properties.Place} - Mag {f.Properties.Mag}")
            .ToArray();
    }
}

// These classes are required for Problem 5 (Earthquake Data)
// They can sit right here at the bottom of the file.
public class FeatureCollection {
    public Feature[] Features { get; set; }
}
public class Feature {
    public Properties Properties { get; set; }
}
public class Properties {
    public double Mag { get; set; }
    public string Place { get; set; }
}
