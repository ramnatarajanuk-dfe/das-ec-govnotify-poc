using Notify.Client;
using Notify.Models;
using Notify.Models.Responses;
using System.Net.Http;
using System.Net.Mail;

namespace GovNotifyPOC
{
    /// <summary>
    /// 
    /// </summary>
    public class StartUp
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            try
            {
                var client = new NotificationClient("ecgovnotifyservicetestkey-41c70660-9bd1-412c-a662-3378c8268372-818c948b-eb9e-45bc-b096-0eba51120cf4");
                string templateId = "2d88acf9-13ac-49e5-a36a-6f55c1d87c8e";
                byte[] documentContents = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "sample.csv"));

                Dictionary<String, dynamic> personalisation = new Dictionary<String, dynamic>
                {
                    {"fname", "Ram"},
                    {"lname", "Natarajan"},
                    {"region", "North East"},
                    {"extractiondate", "16/11/2023 15:12:00"},
                    {"securelink", NotificationClient.PrepareUpload(documentContents,true, true, "1 week")}
                };

                // EmailNotificationResponse response = client.SendEmail(emailAddress, templateId, personalisation, reference, emailReplyToId);

                EmailNotificationResponse response = client.SendEmail(
                            emailAddress: "ram.natarajan@education.gov.uk",
                            templateId: templateId,
                            personalisation
                        );
            }
            catch (Notify.Exceptions.NotifyClientException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}