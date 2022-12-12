using Microsoft.AspNetCore.Mvc;
using System.IO.Compression;

namespace aspnetcore.Services
{
    public class ZipFiles: IZipFiles
    {


        private static byte[] byteFile;
        public async Task<ActionResult> CompressFilesAsync()
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
                //Create an archive and store the stream in memory.
                using (var zipArchive = new ZipArchive(compressedFileStream, ZipArchiveMode.Create))
                {
                    //Create a zip entry for each attachment
                    var zipEntry = zipArchive.CreateEntry("File.txt");

                    //Get the stream of the attachment
                    using (var originalFileStream = new MemoryStream(byteFile))
                    using (var zipEntryStream = zipEntry.Open())
                    {
                        //Copy the attachment stream to the zip entry stream
                        originalFileStream.CopyTo(zipEntryStream);
                    }
                }


                try
                {
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
