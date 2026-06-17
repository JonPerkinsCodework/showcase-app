namespace Utopia.Api.Requests
{
    public record CreateTaskRequest(
        Guid ProjectId,
        string Title,
        string? Description
    );
}
