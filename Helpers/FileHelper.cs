namespace MyUtils.Helpers;

/// <summary>
/// Static helper methods for file and directory operations.
/// </summary>
public static class FileHelper
{
    /// <summary>Returns a human-readable file size. E.g. "1.23 MB"</summary>
    public static string FormatFileSize(long bytes)
    {
        string[] sizes = ["B", "KB", "MB", "GB", "TB"];
        int order = 0;
        double len = bytes;
        while (len >= 1024 && order < sizes.Length - 1) { order++; len /= 1024; }
        return $"{len:0.##} {sizes[order]}";
    }

    /// <summary>Returns the file extension in lowercase without the dot. E.g. "pdf"</summary>
    public static string GetExtension(string filePath) => Path.GetExtension(filePath).TrimStart('.').ToLowerInvariant();

    /// <summary>Checks if a file extension matches any of the allowed types.</summary>
    /// <param name="filePath">The path of the file to check.</param>
    /// <param name="allowedExtensions">The allowed file extensions.</param>
    /// <returns>True if the file extension is allowed; otherwise, false.</returns>
    public static bool IsAllowedExtension(string filePath, params string[] allowedExtensions)
    {
        string ext = GetExtension(filePath);
        return allowedExtensions.Any(e => e.TrimStart('.').Equals(ext, StringComparison.InvariantCultureIgnoreCase));
    }

    /// <summary>Checks whether a file is an image by extension.</summary>
    public static bool IsImage(string filePath) => IsAllowedExtension(filePath, "jpg", "jpeg", "png", "gif", "bmp", "webp", "svg");

    /// <summary>Checks whether a file is a document by extension.</summary>
    public static bool IsDocument(string filePath) => IsAllowedExtension(filePath, "pdf", "doc", "docx", "xls", "xlsx", "ppt", "pptx", "txt");

    /// <summary>Ensures a directory exists; creates it if not.</summary>
    public static void EnsureDirectoryExists(string directoryPath)
    {
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
    }

    /// <summary>Reads all text from a file safely, returning null if file not found.</summary>
    public static async Task<string?> ReadAllTextSafeAsync(string filePath)
    {
        return !File.Exists(filePath) ? null : await File.ReadAllTextAsync(filePath);
    }

    /// <summary>Writes text to a file, creating directories if needed.</summary>
    public static async Task WriteAllTextAsync(string filePath, string content)
    {
        EnsureDirectoryExists(Path.GetDirectoryName(filePath)!);
        await File.WriteAllTextAsync(filePath, content);
    }

    /// <summary>Deletes a file if it exists (no exception if missing).</summary>
    public static void DeleteIfExists(string filePath)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }

    /// <summary>Generates a unique filename with a timestamp prefix to avoid collisions.</summary>
    public static string GenerateUniqueFileName(string originalFileName)
    {
        string ext = Path.GetExtension(originalFileName);
        string name = Path.GetFileNameWithoutExtension(originalFileName);
        return $"{name}_{DateTime.UtcNow:yyyyMMddHHmmssfff}{ext}";
    }

    /// <summary>Gets all files in a directory matching an extension filter.</summary>
    public static IEnumerable<string> GetFilesByExtension(string directory, string extension) =>
        Directory.Exists(directory)
            ? Directory.EnumerateFiles(directory, $"*.{extension.TrimStart('.')}", SearchOption.AllDirectories)
            : [];

    /// <summary>Copies a file to a destination, overwriting if it exists.</summary>
    public static void CopyFile(string source, string destination)
    {
        EnsureDirectoryExists(Path.GetDirectoryName(destination)!);
        File.Copy(source, destination, overwrite: true);
    }

    /// <summary>Returns true if the file size is within the allowed limit in MB.</summary>
    public static bool IsWithinSizeLimit(string filePath, double maxSizeMb)
    {
        FileInfo info = new(filePath);
        return info.Exists && info.Length <= maxSizeMb * 1024 * 1024;
    }

    /// <summary>Returns true if a stream size is within the allowed limit in MB.</summary>
    public static bool IsWithinSizeLimit(Stream stream, double maxSizeMb) => stream.Length <= maxSizeMb * 1024 * 1024;
}
