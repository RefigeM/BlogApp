namespace BlogApp.BL.Exceptions;

public interface IBaseException
{
	 int Code { get; }
	 string ErrorMessage { get; }
}
