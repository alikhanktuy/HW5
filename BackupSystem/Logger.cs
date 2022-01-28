using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace BackupSystem
{
    internal class Logger
    {
        FileSystemWatcher watcher;
        bool enabled = true;
        private string _sourceDirectory;
        private string _logDirectory;
        public Logger(string SourceDir, string LogDir)
        {
            _sourceDirectory = SourceDir;
            _logDirectory = LogDir;
        }
        public void Run()
        {
            using (watcher = new FileSystemWatcher(_sourceDirectory, "*.txt"))
            {
                watcher.NotifyFilter = NotifyFilters.LastAccess
                    | NotifyFilters.LastWrite
                    | NotifyFilters.DirectoryName
                    | NotifyFilters.FileName
                    | NotifyFilters.CreationTime;
                watcher.IncludeSubdirectories = true;
                watcher.Deleted += OnHandlerDT;
                watcher.Created += OnHandlerDT;
                watcher.Changed += OnHandlerDT;
                watcher.Renamed += OnHandlerDT;
                watcher.EnableRaisingEvents = true;
                while (enabled)
                    Thread.Sleep(1000);
            }
        }
        private void OnHandlerDT(object sender, FileSystemEventArgs e)
        {
            var date = DateTime.Now;
            var newDir = _logDirectory + PrintDT(date);
            Restore.DirectoryCopy(_sourceDirectory, newDir, true);
        }
        public static string PrintDT(DateTime date)
        {
            var res = date.Day + "." + date.Month + "." + date.Year + "_"
                + date.Hour + "h" + date.Minute + "m" + date.Second + "s";
            return res;
        }
    }
}
