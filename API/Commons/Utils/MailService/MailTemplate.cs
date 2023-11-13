using API.Data.DTOs.Mail;

namespace API.Commons.Utils
{
    /// <summary>
    /// Mail Template
    /// </summary>
    public class MailTemplate
    {
        /// <summary>
        /// Registration
        /// </summary>
        /// <param name="email"></param>
        /// <param name="confirmationLink"></param>
        /// <returns></returns>
        public static MailDataModel Registration(string email, string confirmationLink)
        {
            List<string> To = new List<string>() { email };
            string Subject = "e-CardLearn Registration Confirmation";

            string body = $"Dear {email},<br/><br/>"
                + "Thank you for registering with us. Please click on the below link to verify your email address and to activate your account.<br/><br/>"
                + $"<a href=\"{confirmationLink}\">Confirmation Link Here</a><br/><br/>"
                + "Regards,<br/>"
                + "e-CardLearn Team";
            return new MailDataModel(To, Subject, body);
        }

        /// <summary>
        /// Forgot Password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="confirmationLink"></param>
        /// <returns></returns>
        public static MailDataModel ForgotPassword(string email, string confirmationLink)
        {
            List<string> To = new List<string>() { email };
            string Subject = "e-CardLearn Forgot Password";

            string body = $"Dear {email},<br/><br/>"
                + "We have received a request to reset your password. Please click on the below link to reset your password.<br/><br/>"
                + $"<a href=\"{confirmationLink}\">Reset Password Link Here</a><br/><br/>"
                + "Regards,<br/>"
                + "e-CardLearn Team";

            return new MailDataModel(To, Subject, body);
        }

        /// <summary>
        /// Reset Password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public static MailDataModel ResetPassword(string email, string newPassword)
        {
            List<string> To = new List<string>() { email };
            string Subject = "e-CardLearn Reset Password";

            string body = $"Dear {email},<br/><br/>"
                + "Thank you for using our application. Here is your new password.<br/><br/>"
                + $"<h5>{newPassword}</h5><br/><br/>"
                + "Regards,<br/>"
                + "e-CardLearn Team";

            return new MailDataModel(To, Subject, body);
        }
    }
}
