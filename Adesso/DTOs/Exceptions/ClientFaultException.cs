using System;
namespace Adesso.DTOs.Exceptions
{
	public class ClientFaultException : Exception
	{
		public ClientFaultException(string message):base(message)
		{
		}
	}
}

