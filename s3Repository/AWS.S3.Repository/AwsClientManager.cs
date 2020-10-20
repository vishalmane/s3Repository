using Amazon;
using Amazon.S3;

namespace AWS.S3.Repository
{
    public class AwsClientManager : IAwsClientManager
    {
        private readonly object s3Lock = new object();
        private readonly object s3Lock1 = new object();
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.APSouth1;
        private static readonly string assessKey = "****";
        private static readonly string secretAssessKey = "***";

        private static IAmazonS3 s3Client;
        public IAmazonS3 GetAmazonS3Client()
        {
            if (s3Client == null)
            {
                lock (s3Lock)
                {
                    if (s3Client == null)
                    {
                        lock (s3Lock1)
                        {
                            s3Client = new AmazonS3Client(assessKey, secretAssessKey, bucketRegion);
                        }

                    }
                }
            }
            return s3Client;
        }
    }

}

