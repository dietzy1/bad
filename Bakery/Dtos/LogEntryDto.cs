//We need to add this somewhere idk DTO? Models to filter out shit


namespace Bakery.Dtos;


public class LogEntryDto
{

    public string? UserName { get; set; }

    public string? HttpMethod { get; set; }

    public string? Endpoint { get; set; }

    public DateTime? Timestamp { get; set; }
}