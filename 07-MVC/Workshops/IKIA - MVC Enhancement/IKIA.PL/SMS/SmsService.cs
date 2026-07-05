using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;


namespace IKIA.PL.SMS
{
	public class SmsService : ISmsService
	{
		private TwilioSettings _options;

		public SmsService(IOptions<TwilioSettings> options)
        {
            _options = options.Value;
        }
        public MessageResource Send(string to, string body)
		{
			TwilioClient.Init(_options.AccountSID, _options.AuthToken);

			var result = MessageResource.Create(
				body: body,
				from: new Twilio.Types.PhoneNumber(_options.PhoneNumber),
				to: to
				);

			return result;
		}
	}
}
