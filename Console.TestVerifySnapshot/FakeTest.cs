using Moq;

namespace Console.TestVerifySnapshot;

[UsesVerify]
public class FakeTest
{
    [Fact]
    public Task Test_Fake_Customer()
    {
        //Arrange
        Mock<IFakeService> fakeservice = new();
        fakeservice
            .Setup(q => q.Create(It.IsAny<string>(), It.IsAny<long>()))
            .Returns(new Customer(new Guid("0bde7ebb-ba8e-4d3a-bbec-1aae99db8d45"), "Test", new DateTime(2000, 1, 1), 1547));

        //Act
        var customer = fakeservice.Object.Create(It.IsAny<string>(), It.IsAny<long>());

        //Assert
        return Verify(customer);
    }
}