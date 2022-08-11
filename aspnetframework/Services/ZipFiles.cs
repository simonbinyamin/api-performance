using System;
using System.IO.Compression;

namespace aspnetframework.Services
{
    public class ZipFiles: IZipFiles
    {


        public string CompressFiles()
        {
            Guid _id = Guid.NewGuid();
            using (ZipArchive zip = ZipFile.Open(@"c:\testcase-output\"+_id+".zip", ZipArchiveMode.Create))
            {
                zip.CreateEntryFromFile(@"c:\testcase\something.txt", "data/path/something.txt");
                zip.CreateEntryFromFile(@"c:\testcase\something2.txt", "data/path/something2.txt");
            }
            return "";
            //return Path.ChangeExtension(sourceFileName, ".zip");
        }
    }
}


