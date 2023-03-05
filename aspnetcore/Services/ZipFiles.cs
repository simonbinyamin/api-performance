using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO.Compression;

namespace aspnetcore.Services
{
    public class ZipFiles: IZipFiles
    {


        private static byte[] byteFile;
        public async Task<ActionResult> CompressFiles()
        {
            Guid _id = Guid.NewGuid();

            if (byteFile == null)
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    byteFile = await httpClient.GetByteArrayAsync(@"http://localhost:3333/file/00.txt");

                }
            }

            using (var compressedFileStream = new MemoryStream())
            {
                //using (ZipArchive zipArchive = ZipFile.Open(@"c:\testcase-output\" + _id + ".zip", ZipArchiveMode.Create))
                using (var zipArchive = new ZipArchive(compressedFileStream, ZipArchiveMode.Create))
                {
                    var zipEntry = zipArchive.CreateEntry("File.txt");

                    using (var originalFileStream = new MemoryStream(byteFile))
                    using (var zipEntryStream = zipEntry.Open())
                    {
                        originalFileStream.CopyTo(zipEntryStream);
                    }
                }


                try
                {
                    Debug.WriteLine("My current thread is: " + Thread.CurrentThread.ManagedThreadId);
                    return new FileContentResult(compressedFileStream.ToArray(), "application/zip") { FileDownloadName = _id + ".zip" };

                }
                catch (FileNotFoundException)
                {
                    return new NotFoundResult();
                }

            }

        }
    }
}
