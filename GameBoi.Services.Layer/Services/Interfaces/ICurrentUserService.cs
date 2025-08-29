namespace GameBoi.Services.Layer.Services.Interfaces
{
    public interface ICurrentUserService
    {
        int? UserId { get; }
        string? Username { get; }
        string? Email { get; }
    }
}
