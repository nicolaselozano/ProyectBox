using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Amazon.Runtime;
using Microsoft.Extensions.Configuration;

[Route("api/[controller]")]
[ApiController]
public class AWSS3Controller : ControllerBase
{
        private readonly IAmazonS3 _amazonS3;
        private readonly string bucket;
        public AWSS3Controller(IAmazonS3 amazonS3, IConfiguration configuration)
        {
            _amazonS3 = amazonS3;

            var awsConfig = configuration.GetSection("AWS");
            var accessKeyId = awsConfig["AccessKeyId"];
            var secretKey = awsConfig["SecretKey"];
            var region = Amazon.RegionEndpoint.SAEast1;
            bucket = awsConfig["bucketName"];

            var amazonS3Config = new AmazonS3Config
            {
                ServiceURL = $"https://s3.{region.SystemName}.amazonaws.com",
                RegionEndpoint = region,
            };

            _amazonS3 = new AmazonS3Client(new BasicAWSCredentials(accessKeyId, secretKey), amazonS3Config);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromBody] FileUploadModel model)
        {
            var key = model.FileName;
            var content = model.Content;

            try
            {
                var putObjectRequest = new PutObjectRequest
                {
                    BucketName = bucket,
                    Key = key,
                    ContentBody = content
                };

                await _amazonS3.PutObjectAsync(putObjectRequest);

                return Ok(new { Message = "Archivo subido exitosamente a S3." });
            }
            catch (AmazonS3Exception ex)
            {
                return BadRequest(new { Message = $"Error al subir el archivo a S3: {ex.Message}" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = $"Error inesperado: {ex.Message}" });
            }
        }

}

public class FileUploadModel
{
    public string FileName { get; set; }
    public string Content { get; set; }
}
