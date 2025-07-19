
namespace LiquorStore.Common.Responses;

public class Response<T>
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
    public Dictionary<string, string> Errors { get; set; }

    public Response() { }
    public Response(T data, string message = "Operación exitosa")
    {
        Message = message;
        Data = data;
        Success = true;
        Errors = new();
    }

    public Response(Dictionary<string, string>? errors, string message = "Ocurrió un error.")
    {
        Errors = errors ?? new();
        Message = message;
        Success = false;
    }
}
