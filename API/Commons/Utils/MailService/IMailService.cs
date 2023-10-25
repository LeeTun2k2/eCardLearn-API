using API.Data.DTOs.Mail;

namespace API.Commons.Utils
{
    /// <summary>
    /// Mail service interface
    /// </summary>
    public interface IMailService
    {
        /// <summary>
        /// Send mail
        /// </summary>
        /// <param name="mailData"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<bool> SendAsync(MailDataModel mailData, CancellationToken ct);
    }
}
