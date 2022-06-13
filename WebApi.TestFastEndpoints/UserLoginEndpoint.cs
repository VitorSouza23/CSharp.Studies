namespace TestFestEndpoints.Logins;

public class UserLoginEndpoint : Endpoint<LoginRequest>
{
    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        if (req.UserName == "admin" && req.Password == "admin")
        {
            var jwtToken = JWTBearer.CreateToken(
                signingKey: "TokenSigningKey1",
                expireAt: DateTime.UtcNow.AddDays(1),
                claims: new[] { ("UserName", req.UserName), ("UserID", "001") },
                roles: new[] { "Admin", "Management" },
                permissions: new[] { "ManageInventory", "ManageUsers" });

            await SendAsync(new
            {
                req.UserName,
                Token = jwtToken,
            }, cancellation: ct);
        }
        else
        {
            ThrowError("The supplied credentials are invalid!");
        }
    }
}