namespace ETicaretWEBUI.Core.Result;

using System.Text.Json.Serialization;

public class ApiResult<T>
{
    public T Data { get; set; }

    public string mesaj { get; set; }

    [JsonIgnore]
    public int StatusCode { get; set; }

    public HataBilgisi HataBilgsi { get; set; }
}