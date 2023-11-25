namespace API.Data.DTOs.Cloudinary
{
    /// <summary>
    /// Cloudinary Settings Model
    /// </summary>
    public class CloudinarySettingsModel
    {
        /// <summary>
        /// Cloud
        /// </summary>
        public string? Cloud { get; set; }

        /// <summary>
        /// Api key
        /// </summary>
        public string? ApiKey { get; set; }

        /// <summary>
        /// Api secret
        /// </summary>
        public string? ApiSecret { get; set; }
    }
}
