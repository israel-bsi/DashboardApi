namespace DashboardApi;

public class Logger
{
    public static void Log(string message)
    {
        var directory = "D:\\Logs\\";
        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory);
        var formatdate = DateTime.Now.ToShortDateString().Replace("/", "-");
        var path = $"D:\\Logs\\{formatdate}.txt";
        using var sw = new StreamWriter(path, true);
        sw.WriteLine($"{DateTime.Now} - {message}");
    }
}