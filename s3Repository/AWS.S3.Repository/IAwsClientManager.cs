using Amazon.S3;

namespace AWS.S3.Repository
{
    interface IAwsClientManager
    {
        IAmazonS3 GetAmazonS3Client();
    }

}

