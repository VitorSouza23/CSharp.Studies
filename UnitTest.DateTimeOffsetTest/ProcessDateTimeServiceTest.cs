using System;
using Console.DateTimeOffsetTest;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace UnitTest.DateTimeOffsetTest;

public class ProcessDateTimeServiceTest
{
    private readonly IProcessDateTimeService _processDateTimeService;
    private readonly IDateTimeOffisetProvider _dateTimeOffsetProvider;

    public ProcessDateTimeServiceTest()
    {
        _dateTimeOffsetProvider = Substitute.For<IDateTimeOffisetProvider>();
        _processDateTimeService = new ProcessDateTimeService(_dateTimeOffsetProvider);
    }

    [Fact]
    public void Shoud_Return_Dawn()
    {
        //Arrange
        _dateTimeOffsetProvider.Now.Returns(new DateTimeOffset(2022, 1, 1, 3, 0, 0, TimeSpan.Zero));

        //Act
        string result = _processDateTimeService.GetNowPeriodName();

        //Assert
        result.Should().Be("Dawn");
    }

    [Fact]
    public void Shoud_Return_Morning()
    {
        //Arrange
        _dateTimeOffsetProvider.Now.Returns(new DateTimeOffset(2022, 1, 1, 7, 0, 0, TimeSpan.Zero));

        //Act
        string result = _processDateTimeService.GetNowPeriodName();

        //Assert
        result.Should().Be("Morning");
    }

    [Fact]
    public void Shoud_Return_Afternon()
    {
        //Arrange
        _dateTimeOffsetProvider.Now.Returns(new DateTimeOffset(2022, 1, 1, 13, 0, 0, TimeSpan.Zero));

        //Act
        string result = _processDateTimeService.GetNowPeriodName();

        //Assert
        result.Should().Be("Afternon");
    }

    [Fact]
    public void Shoud_Return_Night()
    {
        //Arrange
        _dateTimeOffsetProvider.Now.Returns(new DateTimeOffset(2022, 1, 1, 19, 0, 0, TimeSpan.Zero));

        //Act
        string result = _processDateTimeService.GetNowPeriodName();

        //Assert
        result.Should().Be("Night");
    }
}