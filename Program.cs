using ConsoleApp2;

// PATH PARAMETERS
using ConsoleApp2;
using RingCentral;
using Xunit;

/* For ringcentral Setup https://developers.ringcentral.com/library/getting-started.html#CreateYourApp*/
using (var rc = new RestClient(
                      "fliYl5-JRfKmBX-LSMg2qw",
                     "ETm9sakbTCq6P5ZmKcTsqQ64g9-T0cSEK_rWZnnVQAug",
                      "https://platform.devtest.ringcentral.com"
                  ))
{
    var r = await rc.Authorize(
        "+19493925104",
                     "101",
                     ".Net@osius12"
    );
    Console.WriteLine("Hi");
    Console.WriteLine(r);
    var restApi = await rc.Restapi().Get();
    await read_user_message_store(rc);
    await send_sms("+19493925104", rc);
    // await read_extension_phone_number(rc);
    Assert.Equal("v1.0", restApi.uriString);
}

static async Task read_extension_phone_number(RestClient restClient)
{
    var resp = await restClient.Restapi().Account().Extension().PhoneNumber().Get();
    foreach (var record in resp.records)
    {
        foreach (var feature in record.features)
        {
            if (feature == "SmsSender")
            {
                send_sms(record.phoneNumber, restClient).Wait();
            }
        }
    }
    Console.WriteLine("\nDone.");
}

static async Task send_sms(string fromNumber, RestClient restClient)
{
    var parameters = new CreateSMSMessage();
    parameters.from = new MessageStoreCallerInfoRequest
    {
        phoneNumber = "19493925104"
    };
    parameters.to = new MessageStoreCallerInfoRequest[] { new MessageStoreCallerInfoRequest {
                    phoneNumber = "+12816525680"
                } };
    parameters.text = "Hello World!";
    var requestBody = new
    {
        text = "Hello, World!",
        from = new { phoneNumber = "19493925104" },
        to = new object[] { new { phoneNumber = "919381665067" } }
    };
    var resp = await restClient.Restapi().Account().Extension().Sms().Post(parameters);
    Console.WriteLine("SMS sent. Message status: " + resp.messageStatus);
}
static async Task read_user_message_store(RestClient restClient)
{
    var parameters = new ListMessagesParameters();
    parameters.messageType = (new string[] { "SMS" });
    var response = await restClient.Restapi().Account().Extension().MessageStore().List(parameters);

    Console.WriteLine(response);
}