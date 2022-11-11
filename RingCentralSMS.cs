using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RingCentral;

namespace ConsoleApp2
{
    internal class RingCentralSMS
    {

        const string SMS_RECIPIENT = "<ENTER PHONE NUMBER>";
        static RestClient restClient;
        public async void SendSms()
        {
            try
            {
                restClient = new RestClient(
                     "fliYl5-JRfKmBX-LSMg2qw",
                     "ETm9sakbTCq6P5ZmKcTsqQ64g9-T0cSEK_rWZnnVQAug",
                      false);
                Console.WriteLine("get new token");
               var r= await restClient.Authorize(
                    "+19493925104",
                     "101",
                     ".Net@osius12");
                Console.WriteLine(r.ToString());
                await read_extension_phone_number();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        static private async Task read_extension_phone_number()
        {
            var resp = await restClient.Restapi().Account().Extension().PhoneNumber().Get();
            foreach (var record in resp.records)
            {
                foreach (var feature in record.features)
                {
                    if (feature == "SmsSender")
                    {
                        send_sms(record.phoneNumber).Wait();
                        goto LoopEnd;
                    }
                }
            }
        LoopEnd:
            Console.WriteLine("\nDone.");
        }

        static private async Task send_sms(string fromNumber)
        {
            var parameters = new CreateSMSMessage();
            parameters.from = new MessageStoreCallerInfoRequest
            {
                phoneNumber = fromNumber
            };
            parameters.to = new MessageStoreCallerInfoRequest[] { new MessageStoreCallerInfoRequest {
                    phoneNumber = Environment.GetEnvironmentVariable("SMS_RECIPIENT")
                } };
            parameters.text = "Hello World!";

            var resp = await restClient.Restapi().Account().Extension().Sms().Post(parameters);
            Console.WriteLine("SMS sent. Message status: " + resp.messageStatus);
        }
    }
}
