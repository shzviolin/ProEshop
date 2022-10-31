using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEshop.Services.Contracts.Identity;

public interface ISmsSender
{
	#region BaseClass
	Task<bool> SendSmsAsync(string number,string message);
	#endregion
	#region CustomMethod

	#endregion
}
