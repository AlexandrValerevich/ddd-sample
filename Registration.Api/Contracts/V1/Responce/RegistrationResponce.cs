namespace Registration.Api.Contracts.V1.Responce;

public class RegistrationResponce
{
    public bool IsSuccsess { get; set; }
    public IEnumerable<string> Errors { get; set; } = new List<string>();
}
