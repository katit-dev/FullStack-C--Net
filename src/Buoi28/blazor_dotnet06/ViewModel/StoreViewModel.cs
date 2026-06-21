//Viewmodel(ViewModel) - DTO (BE)

using System.Text.Json.Serialization;
public class StoreViewModel
{
    
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("alias")]
    public string Alias { get; set; } = string.Empty;

    [JsonPropertyName("latitude")]
    public string Latitude { get; set; } = string.Empty;

    // Giữ đúng key JSON là "longtitude" dù từ đúng chính tả là "longitude"
    [JsonPropertyName("longtitude")]
    public string Longtitude { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("image")]
    public string Image { get; set; } = string.Empty;

    [JsonPropertyName("deleted")]
    public bool Deleted { get; set; }
}