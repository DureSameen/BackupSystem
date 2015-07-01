﻿using BackupSystem.WinApp.BackupSystemService;
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
        public static void Folder(string from, string to, DateTime logTime, string name ,EnumsBackupType backuptype,   long Schedule_DetailId  )
        {
            Log.Begin(name + ": Backup started ..." , Schedule_DetailId);


            try
            {
                if (!Directory.Exists(from))
                {
                    Log.Error(name + ": Source Folder does not exist or access denied to " + from, Schedule_DetailId);
                    throw new Exception("Source Folder does not exist or access denied to " + from);
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
                        Log.Error(name + ": " + ex.Message, Schedule_DetailId);
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
                       
                        Log.Error(name + ": "+ ex.Message  , Schedule_DetailId);
                    }
                });


                Log.End(name + ":  Backup completed successfully", Schedule_DetailId);
                
            }
            catch (Exception ex)
            {
                Log.Error(name + ": " + ex.Message, Schedule_DetailId);
                Log.End  (name + ":  Backup completed with errors", Schedule_DetailId);
                 
            }

             
        }
    }
}
