using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKIA.BLL.Common.Services.Emails
{
	public interface IEmailService
	{
		Task SendAsync(string from, string recipients, string subject, string body);
	}
}
