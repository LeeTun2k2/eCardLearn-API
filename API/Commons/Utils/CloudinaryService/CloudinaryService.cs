using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.Extensions.Options;
using API.Data.DTOs.Cloudinary;
using API.Data.DTOs.Mail;

namespace API.Commons.Utils.CloudinaryService
{
    /// <summary>
    /// Cloudinary Service
    /// </summary>
    public class CloudinaryService : ICloudinaryService
    {
        private readonly CloudinarySettingsModel _settings;
        private Cloudinary cloudinary;
        /// <summary>
        /// Constructor
        /// </summary>
        public CloudinaryService(IOptions<CloudinarySettingsModel> settings)
        {
            _settings = settings.Value;
            Account account = new Account(_settings.Cloud, _settings.ApiKey, _settings.ApiSecret);
            cloudinary = new Cloudinary(account);
        }

        /// <summary>
        /// Get file url
        /// </summary>
        /// <param name="publicId"></param>
        /// <returns></returns>
        public string GetUrl(string publicId)
        {
            return $"https://res.cloudinary.com/{_settings.Cloud}/image/upload/{publicId}";
        }

        /// <summary>
        /// Upload file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task<(bool, string)> Upload(IFormFile file)
        {
            string uniqueIdentifier = Guid.NewGuid().ToString();
            string fileName = $"{DateTime.Now:yyyyMMddHHmmss}_{uniqueIdentifier}_{file.FileName}";
            string publicId = $"{DateTime.Now:yyyyMMddHHmmss}_{uniqueIdentifier}";

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(fileName, file.OpenReadStream()),
                PublicId = publicId,
            };
            var uploadResult = await cloudinary.UploadAsync(uploadParams);

            if (uploadResult != null)
            {
                return (true, uploadResult.PublicId);
            }

            return (false, string.Empty);
        }

        /// <summary>
        /// Remove file
        /// </summary>
        /// <param name="publicId"></param>
        /// <returns></returns>
        public async Task<(bool, string)> Remove(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);

            var result = await cloudinary.DestroyAsync(deleteParams);

            if (result != null)
            {
                if (result.Result == "ok")
                    return (true, "Image removed successfully.");
            }

            return (false, string.Empty);
        }
    }
}
