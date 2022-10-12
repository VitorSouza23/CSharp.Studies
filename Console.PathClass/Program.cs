using static System.Console;

WriteLine("Path fields");
WriteLine($"Directory separator based on OS: {Path.DirectorySeparatorChar}");
WriteLine($"Directory alternative separator based on OS: {Path.AltDirectorySeparatorChar}");
WriteLine($"Path string separator for environment variables based on OS: {Path.PathSeparator}");
WriteLine($"Volume separator based on OS: {Path.VolumeSeparatorChar}");

WriteLine();

WriteLine("Path static methods");
WriteLine($"Changing test.txt extension to test.pdf: {Path.ChangeExtension("test.txt", ".pdf")}");
WriteLine($"Combining BasePath/ with test.txt: {Path.Combine("BasePath", "test.txt")}");
WriteLine($"Check if the path BasePath/ ends with a directory separator: {Path.EndsInDirectorySeparator("BasePath/")}");
WriteLine($"Get the directory name in the path BasePath/Directory/test.txt: {Path.GetDirectoryName("BasePath/Directory/test.txt")}");
WriteLine($"Get file extension from BasePath/Directory/test.txt path: {Path.GetExtension("BasePath/Directory/test.txt")}");
WriteLine($"Get file name from BasePath/Directory/test.txt path: {Path.GetFileName("BasePath/Directory/test.txt")}");
WriteLine($"Get file name without extension from BasePath/Directory/test.txt path: {Path.GetFileNameWithoutExtension("BasePath/Directory/test.txt")}");
WriteLine($"Get full path from BasePath/Directory/test.txt: {Path.GetFullPath("BasePath/Directory/test.txt")}");
WriteLine($"Get invalid file names characters list: {string.Join(' ', Path.GetInvalidFileNameChars())}");
WriteLine($"Get invalid paths characters: {string.Join(' ', Path.GetInvalidPathChars())}");
WriteLine($"Get root path from BasePath/Directory/test.txt: {Path.GetPathRoot("BasePath/Directory/test.txt")}");
WriteLine($"Get random file name: {Path.GetRandomFileName()}");
WriteLine($"Get the relative path from BasePath/Directory/ and Directory/: {Path.GetRelativePath("BasePath/Directory/", "Directory/")}");
WriteLine($"Get the current user temp path: {Path.GetTempPath()}");
//WriteLine($"Create a temp file: {Path.GetTempFileName()}");
WriteLine($"Check if BasePath/Directory/test.txt has extension: {Path.HasExtension("BasePath/Directory/test.txt")}");
WriteLine($"Check if the BasePath/Directory/test.txt path is full qualified: {Path.IsPathFullyQualified("BasePath/Directory/test.txt")}");
WriteLine($"Check if the BasePath/Directory/test.txt path contains a root: {Path.IsPathRooted("BasePath/Directory/test.txt")}");
WriteLine($"Join BaseDirectory/ with Directory/test.txt: {Path.Join("BaseDirectory/", "Directory/test.txt")}");
WriteLine($"Trim BaseDirectory/Directory/ separator character: {Path.TrimEndingDirectorySeparator("BasePath/Directory/")}");
var destination = new Span<char>(new string(' ', 100).ToCharArray());
WriteLine($"Try to join the paths BaseDirectory/ and Directory/text.txt: Is successfully: {Path.TryJoin("BasePath/".AsSpan(), "Directory/test.txt".AsSpan(), destination, out var charsWritten)} - chars written: {charsWritten} - destination: {destination}");