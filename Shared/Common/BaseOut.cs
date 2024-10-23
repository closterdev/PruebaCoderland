namespace Shared.Common;

public class BaseOut
{
    public string Message { get; set; } = string.Empty;
    public Result Result { get; set; }
    public string ResultAsString => Result.ToString();
}