namespace BackEnd.API.Shared.Domain.Services.Communication;

public abstract class BaseResponse<T>
{
    public bool Success { get; protected set; }
    public string Message { get; protected set; }
    public T Resource { get; protected set; }
    
    protected BaseResponse(string message)
    {
        Success = false;
        Message = message;
        Resource = default;
    }

    protected BaseResponse(T resource)
    {
        Success = true;
        Message = string.Empty;
        Resource = resource;
    }
}