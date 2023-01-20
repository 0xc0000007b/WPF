using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using WpfApp2.ViewModels.Base;

namespace WpfApp2.ViewModels;

public class DirectoryViewModel : ViewModelBase
{
    private readonly DirectoryInfo _directoryInfo;

    public IEnumerable<DirectoryViewModel> SubDirectories
    {
        get
        {
            try
            {
               return _directoryInfo.EnumerateDirectories()
                    .Select(x => new DirectoryViewModel(x.FullName));
               
            }
            catch (UnauthorizedAccessException e)
            {
             Debug.WriteLine(e.ToString());
            }

            return Enumerable.Empty<DirectoryViewModel>();
        }
    } 
    public IEnumerable<FileViewModels> Files
    {

        get
        {
            try
            {
               return  _directoryInfo
                    .EnumerateFiles()
                    .Select(x => new FileViewModels(x.FullName));
                
            }
            catch (UnauthorizedAccessException e)
            {
               Debug.WriteLine(e.ToString());
            }

            return Enumerable.Empty<FileViewModels>();
        }
    }

    public IEnumerable<object> DirectoryItems 
    {
        get
        {

            try
            {
              return  SubDirectories.Cast<object>().Concat(Files);
            }
            catch (UnauthorizedAccessException e)
            {
               Debug.WriteLine(e.ToString());
            }

            return Enumerable.Empty<object>();
        }
    }     
    public string Name => _directoryInfo.Name;
    public string Path => _directoryInfo.FullName;
    public DateTime CreationDate => _directoryInfo.CreationTime;
    
    public DirectoryViewModel(string path)
    {
        _directoryInfo = new DirectoryInfo(path);
    }
}

public class FileViewModels : ViewModelBase
{
    private readonly FileInfo _fileInfo;

    public string Name => _fileInfo.Name;
    public string Path => _fileInfo.FullName;
    public DateTime CreationDate => _fileInfo.CreationTime;
    public FileViewModels(string path)
    {
        _fileInfo = new FileInfo(path);
    }
}