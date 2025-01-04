using Microsoft.AspNetCore.Http;

namespace BlogApp.BL.Exceptions.Common;

public class NotFoundException<T> : Exception, IBaseException
{
	public int Code => StatusCodes.Status409Conflict;

	public string ErrorMessage { get; }
	public NotFoundException() : base(typeof(T).Name + "not found")
	{
		ErrorMessage = typeof(T).Name + "not found";
	}
	public NotFoundException(string msg) : base(msg)
	{
		ErrorMessage = msg;
	}


}
