using BackupSystem.WinApp.BackupSystemService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupSystem.WinApp.Models
{
   public static class Backup
    {
        public static void Folder(string from, string to, DateTime logTime, string name ,EnumsBackupType backuptype  )
        {
           // Log.Info("Backup started", from, to, logTime);

            try
            {
                if (!Directory.Exists(from))
                {
                    throw new Exception("Folder does not exist or access denied to " + from);
                }

                if ((backuptype == EnumsBackupType.Incremental_Backup))
                {    if (! Directory.Exists (to))
                        Directory.CreateDirectory(to);

                        to = to + "\\" + name + "-" + logTime.ToString("MM-dd-yyyy");

                        Directory.CreateDirectory(to);
                    

                }
                else  if (! Directory.Exists (to))
                {
                    Directory.CreateDirectory(to);
                }
                 

                string[] directories = Directory.GetDirectories(from, "*.*", SearchOption.AllDirectories);

                Parallel.ForEach(directories, dirPath =>
                {
                    try
                    {
                        Directory.CreateDirectory(dirPath.Replace(from, to));
                    }
                    catch (Exception ex)
                    {
                        //Log.Error(ex.Message, from, to, logTime);
                    }
                });

                string[] files = Directory.GetFiles(from, "*.*", SearchOption.AllDirectories);

                Parallel.ForEach(files, filePath =>
                {
                    try
                    {
                        //Replace File.Copy to FileStream to prevent source file lock
                        //File.Copy(filePath, filePath.Replace(from, to));

                        using (FileStream source = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            using (FileStream dest = new FileStream(filePath.Replace(from, to), FileMode.Create, FileAccess.ReadWrite))
                            {
                                source.CopyTo(dest);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                       // Log.Error(ex.Message, from, to, logTime);
                    }
                });

               

               // Log.Info("Backup completed successfully", from, to, logTime);
            }
            catch (Exception ex)
            {
               // 'Log.Error(ex.Message, from, to, logTime);
                //'Log.Info("Backup completed with errors", from, to, logTime);
            }

            //'Log.Clear();
        }
    }
}
