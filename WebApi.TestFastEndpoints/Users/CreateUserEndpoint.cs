namespace TestFestEndpoints.Users;

public class CreateUserEndpoint : Endpoint<CreateUserRequest, CreateUserResponse, UserMapping>
{
    private readonly ILogger<CreateUserEndpoint> _logger;

    public CreateUserEndpoint(ILogger<CreateUserEndpoint> logger)
    {
        _logger = logger;
    }

    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("users/create");
        Roles("Admin", "Management");
    }

    public override async Task HandleAsync(CreateUserRequest req, CancellationToken ct)
    {
        User user = Map.ToEntity(req);
        CreateUserResponse response = Map.FromEntity(user);

        _logger.LogInformation("Creating user: {UserName}", response.FullName);

        await SendAsync(response, cancellation: ct);
    }
}