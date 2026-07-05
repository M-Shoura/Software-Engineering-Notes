using Twilio.Rest.Api.V2010.Account;

namespace IKIA.PL.SMS
{
	public interface ISmsService
	{
		public MessageResource Send(string to, string body);
	}
}
