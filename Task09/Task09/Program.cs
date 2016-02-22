using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task09
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"H:\programm\TestTask9";
            Console.WriteLine("1:Режим отслеживания");
            Console.WriteLine("2:Режим бекапа");
            char k = Console.ReadKey(true).KeyChar;
            if (k == '1')
            {
                Console.WriteLine("Запущен режим отслеживания");
                AddEvent(path);
                Console.ReadLine();
            }
            else if (k == '2')
            {
                DateTime backUpTimeParse;
                DirectoryInfo dirInfo = new DirectoryInfo(@"H:\programm\TMPFILES\");
                DirectoryInfo[] dirs = dirInfo.GetDirectories();

                Console.WriteLine("Доступное время бекапа:");
                foreach (DirectoryInfo dir in dirs)
                {
                    Console.WriteLine(dir.CreationTime);
                }

                Console.WriteLine("Введите дату бекапа DD.MM.YYYY hh:mm:ss");
                string backUpTime = Console.ReadLine();
                if (!DateTime.TryParse(backUpTime,out backUpTimeParse))
                {
                    Console.WriteLine("Время введено неправильно");
                    Console.WriteLine();
                    Main(args);
                }
                BackUp(backUpTimeParse, path);
                Console.WriteLine("Бекап Завершен");
            }
            else
            {
                Console.WriteLine("Введено неверное значение");
                Console.WriteLine();
                Main(args);
            }
        }

        static private void AddEvent(string path)
        {
            FileSystemWatcher watcher = new FileSystemWatcher(path,"*.txt");
            watcher.IncludeSubdirectories = true;
            watcher.Created += new FileSystemEventHandler(FileChanged);
            watcher.Changed += new FileSystemEventHandler(FileChanged);
            watcher.Deleted += new FileSystemEventHandler(FileChanged);
            watcher.Renamed += FileChanged;
            watcher.EnableRaisingEvents = true;
        }

        private static void BackUp(DateTime backUpTime,string path)
        {
            string backUpFolderPath = "";
            DateTime backUpFolderTime = new DateTime(1, 1, 1);
            DirectoryInfo dirInfo = new DirectoryInfo(@"H:\programm\TMPFILES\");
            DirectoryInfo[] dirs = dirInfo.GetDirectories();

            foreach(DirectoryInfo dir in dirs)
            {
                if ((dir.CreationTime < backUpTime)&&(dir.CreationTime > backUpFolderTime))
                {
                    backUpFolderPath = dir.FullName;
                    backUpFolderTime = dir.CreationTime;
                }
            }
            Directory.Delete(path, true);
            DirectoryCopy(backUpFolderPath, path, true);
        }

        private static void FileChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("CHANGED ON {0}",e.Name);
            DirectoryCopy(@"H:\programm\TestTask9", @"H:\programm\TMPFILES\" + DateTime.Now.ToString("hh.mm.ss"),true);
            Console.WriteLine("COPY DONE {0}", e.Name);
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);
            }

            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
    }
}
