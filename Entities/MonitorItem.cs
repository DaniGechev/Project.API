namespace Project.API.Entities;

public class MonitorItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string TargetUrl { get; set; } = string.Empty;
    public string? OwnerId { get; set; }
}
