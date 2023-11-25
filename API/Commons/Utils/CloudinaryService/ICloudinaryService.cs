namespace API.Commons.Utils.CloudinaryService
{
    /// <summary>
    /// Cloudinary service interface
    /// </summary>
    public interface ICloudinaryService
    {
        /// <summary>
        /// Get file url
        /// </summary>
        /// <param name="publicId"></param>
        /// <returns></returns>
        string GetUrl(string publicId);

        /// <summary>
        /// Upload File
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        Task<(bool, string)> Upload(IFormFile file);

        /// <summary>
        /// Remove File
        /// </summary>
        /// <param name="publicId"></param>
        /// <returns></returns>
        Task<(bool, string)> Remove(string publicId);
    }
}
