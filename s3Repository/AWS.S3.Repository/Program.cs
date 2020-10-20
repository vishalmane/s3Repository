using System;

namespace AWS.S3.Repository
{
    class Program
    {
        private const string bucketName = "myfirsts3buckettest1231";
        static IS3Service s3Service = null;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            s3Service = new S3Service();
            s3Service.CreateBucket(bucketName).Wait();
            s3Service.AddObject(bucketName,@"C:\Users\maneevis\Documents\Personal\ShlokPhoto\_U4A9589.JPG", "MyfirstObject").Wait();
        }


    }

}

