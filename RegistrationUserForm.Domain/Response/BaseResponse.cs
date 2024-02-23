using AutorizationUserForm.Domain.Enum;

namespace AutorizationUserForm.Domain.Response;

public class BaseResponse<T>:IBaseResponse<T>
{
    public string Description { get; set; }
    public StausCode StatusCode { get; init; }
    public T Data { get; set; }
}

public interface IBaseResponse<T>
{
    string Description { get;}
    StausCode StatusCode { get;}
    T Data { get; }
}

