using System.Text.Json;

namespace LegacyGifts.App.Utility;

public static class ImportMapFactory
{
    private class ImportMap
    {
        public Dictionary<string, string>? imports { get; init; }
    }

    public static string GetImportMap(string webRootPath, string assemblyVersionWithTimestamp)
    {
        var importMapPath = Path.Combine(webRootPath, "import-map.json");
        
        if (!File.Exists(importMapPath))
        {
            return JsonSerializer.Serialize(new { imports = new Dictionary<string, string>() });
        }

        var importMapJson = File.ReadAllText(importMapPath);
        var importMap = JsonSerializer.Deserialize<ImportMap>(importMapJson);

        if (importMap?.imports != null)
        {
            foreach (var import in importMap.imports)
            {
                importMap.imports[import.Key] = $"{import.Value}?{assemblyVersionWithTimestamp}";
            }
        }

        return JsonSerializer.Serialize(importMap);
    }
}
