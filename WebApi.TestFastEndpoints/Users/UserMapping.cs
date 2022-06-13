namespace TestFestEndpoints.Users;

public class UserMapping : Mapper<CreateUserRequest, CreateUserResponse, User>
{
    public override User ToEntity(CreateUserRequest r)
    {
        return new(r.FirstName ?? "", r.LastName ?? "", r.Age);
    }

    public override CreateUserResponse FromEntity(User e)
    {
        return new()
        {
            FullName = e.FullName,
            IsOver18 = e.IsOver18()
        };
    }
}