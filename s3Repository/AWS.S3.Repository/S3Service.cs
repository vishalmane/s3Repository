using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;
using System;
using System.Threading.Tasks;

namespace AWS.S3.Repository
{
    public class S3Service : IS3Service
    {
        private IAmazonS3 s3Client;
        private IAwsClientManager awsClientManager = null;
        public S3Service()
        {
            awsClientManager = new AwsClientManager();
            s3Client = awsClientManager.GetAmazonS3Client();
        }
        public async Task<bool> CreateBucket(string name)
        {
            try
            {
                if (!(await AmazonS3Util.DoesS3BucketExistAsync(s3Client, name)))
                {
                    var putBucketRequest = new PutBucketRequest
                    {
                        BucketName = name,
                        UseClientRegion = true,
                    };

                    PutBucketResponse putBucketResponse = await s3Client.PutBucketAsync(putBucketRequest);
                }
                return true;

            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when writing an object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
            }
            return false;
        }
        public async Task<string> FindBucketLocationAsync(string bucketName)
        {
            string bucketLocation;
            var request = new GetBucketLocationRequest()
            {
                BucketName = bucketName
            };
            GetBucketLocationResponse response = await s3Client.GetBucketLocationAsync(request);
            bucketLocation = response.Location.ToString();
            return bucketLocation;
        }

        public async Task<bool> AddObject(string bucketName,string filePath, string myKey)
        {
            var response = await s3Client.PutObjectAsync(new PutObjectRequest
            {
                FilePath = filePath,
                Key = myKey,
                BucketName= bucketName                
            });
            return true;
        }
    }

}

