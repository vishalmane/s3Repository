using System.Threading.Tasks;

namespace AWS.S3.Repository
{
    interface IS3Service
    {
        Task<bool> CreateBucket(string name);
        Task<bool> AddObject(string bucketName,string filePath, string myKey);
    }

}

