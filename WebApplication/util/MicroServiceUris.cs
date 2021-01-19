using System;

namespace WebApplication.util
{
    public class MicroServiceUris : IDisposable
    {
        public string AccountServiceUrl { get; set; }
        public string AppointmentServiceUrl { get; set; }
        public string FeedbackServiceUrl { get; set; }
        public string SearchServiceUrl { get; set; }

        public void Dispose()
        {
            
        }

        public string GetUris()
        {
            return
                $"WEB_APP_ACCOUNT_URL: {AccountServiceUrl ?? ""} \n WEB_APP_APPOINTMENT_URL: {AppointmentServiceUrl ?? ""} \n WEB_APP_FEEDBACK_URL: {FeedbackServiceUrl ?? ""} \n WEB_APP_SEARCH_URL: {SearchServiceUrl ?? ""}";
        }
    }
}