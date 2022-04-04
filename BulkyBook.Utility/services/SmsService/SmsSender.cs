using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace BulkyBook.Utility;
public class SmsSender : ISmsSender
{
    private readonly TwilioSetting _twilioSetting;

    public SmsSender(IOptions<TwilioSetting> twilioSetting)
    {
        _twilioSetting = twilioSetting.Value;
    }

    public async Task SendSMSAsync(string phoneNumber, string message)
    {
        TwilioClient.Init(_twilioSetting.AccountSID, _twilioSetting.AuthToken);
        try
        {
            var SMS = MessageResource.Create(
                body: message,
                from: new Twilio.Types.PhoneNumber(_twilioSetting.PhoneNumber),
                to  : new Twilio.Types.PhoneNumber("+2"+phoneNumber)
                );
        }
        catch (Exception)
        {
        }
    }
}
