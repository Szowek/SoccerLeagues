namespace SoccerLeagues.Other

{
    public static class VisualStudioProvider
    {
        public static DirectoryInfo TryGetSolutionDirectoryInfo(string currentPath = null)
        {
            var directory = new DirectoryInfo(
                currentPath ?? Directory.GetCurrentDirectory());
            while (directory != null && !directory.GetFiles("*.db").Any())
            {
                directory = directory.Parent;
            }
            return directory;
        }
    }
}
