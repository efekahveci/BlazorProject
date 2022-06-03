

using System.Text.Json.Serialization;

namespace BlazorProject.Common.Results;
public class ValidationResponseModel
{
    public IEnumerable<string> Errors { get; set; }

    [JsonIgnore]
    public string FlattenErrors => Errors != null ? string.Join(Environment.NewLine, Errors) : string.Empty;
    
}
