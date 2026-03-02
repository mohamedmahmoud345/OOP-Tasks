namespace Task_01.Classes.HelperMethods;

public record class Result(bool IsSuccess, string Message)
{
    public static Result Success(string Message = "Success") => new Result(true, Message);
    public static Result Failure(string Message) => new Result(false, Message);
}
