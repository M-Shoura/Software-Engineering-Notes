namespace IKIA.PL.Emails
{
	public interface INewEmailService
	{
		public void SendEmail(string to, string subject, string body);
	}
}
