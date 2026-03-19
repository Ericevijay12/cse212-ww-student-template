using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// Problem 1: Find symmetric pairs of 2-character words in O(n) time.
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        var result = new List<string>();
        var seen = new HashSet<string>();
        foreach (var word in words)
        {
            // Reverse the 2-character word
            string reversed = new string(new char[] { word[1], word[0] });

            // If we've already seen the reverse, it's a symmetric pair
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

    /// <summary>
    /// Problem 2: Summarize degrees from a census file.
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // The degree information is in column 4 (index 4)
            if (fields.Length > 4)
            {
                string degree = fields[4].Trim();
                if (degrees.ContainsKey(degree))
                    degrees[degree]++;
                else
                    degrees[degree] = 1;
            }
        }
        return degrees;
    }

    /// <summary>
    /// Problem 3: Determine if two words are anagrams using a dictionary.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // Ignore spaces and case
        string clean1 = word1.Replace(" ", "").ToLower();
        string clean2 = word2.Replace(" ", "").ToLower();

        if (clean1.Length != clean2.Length) return false;

        var counts = new Dictionary<char, int>();
        foreach (var c in clean1)
        {
            counts[c] = counts.GetValueOrDefault(c) + 1;
        }

        foreach (var c in clean2)
        {
            if (!counts.ContainsKey(c) || counts[c] == 0) return false;
            counts[c]--;
        }
        return true;
    }

    /// <summary>
    /// Problem 5: Fetch and summarize daily earthquake data from USGS.
    /// </summary>
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

        // Format: "Place - Mag Magnitude"
        return featureCollection.Features
            .Select(f => $"{f.Properties.Place} - Mag {f.Properties.Mag}")
            .ToArray();
    }
}

// These classes support Problem 5: JSON Deserialization
public class FeatureCollection
{
    public Feature[] Features { get; set; }
}

public class Feature
{
    public Properties Properties { get; set; }
}

public class Properties
{
    public double Mag { get; set; }
    public string Place { get; set; }
}
