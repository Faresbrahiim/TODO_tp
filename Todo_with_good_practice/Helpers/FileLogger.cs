namespace Todo_with_good_practice.Helpers
{
    public static class FileLogger
    {
        private static  string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Journalisation");
        private static  string FilePath = Path.Combine(FolderPath, "AuthLog.txt");

        static FileLogger()
        {
            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);

            if (!File.Exists(FilePath))
                File.Create(FilePath).Dispose();
        }

        public static void Log(string message)
        {
            string logLine = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
            File.AppendAllText(FilePath, logLine + Environment.NewLine);
        }
    }
}
