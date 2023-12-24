using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class FilesName
{
    public static List<string> GetFilesNames(string path, string extension) 
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        FileInfo[] infos = dir.GetFiles("*" + extension);
        List<string> names = new List<string>();

        foreach (FileInfo file in infos)
        {
            var name = file.Name.ToString();
            name = name.Replace(extension, "");
            names.Add(name);
        }

        return names;
    } 
}
