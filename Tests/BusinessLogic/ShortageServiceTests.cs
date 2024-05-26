using BusinessLogic.Services;
using Data.Model;
using Data.Model.User;
using Data.Repository;
using static Tests.Generators.ShortageGenerator;

namespace Tests.BusinessLogic;

public class MockedShortageRepository(List<Shortage> testShortages) : IRepository<Shortage>
{
    private readonly List<Shortage> _shortages = new List<Shortage>(testShortages);

    public IEnumerable<Shortage> GetAll()
    {
        return _shortages;
    }

    public void Add(Shortage entity)
    {
        _shortages.Add(entity);
    }

    public void Remove(Shortage entity)
    {
        _shortages.Remove(entity);
    }
}

public class ShortageServiceTests
{
    private static Shortage GetShortage(Guid? id, byte priority = 5)
    {
        return new Shortage
        {
            Name = "Test",
            Title = "Test",
            Priority = priority,
            CreatedOn = DateTime.Now,
            ShortageCategory = ShortageCategory.Electronics,
            ShortageRoom = ShortageRoom.Bathroom,
            UserId = id ?? Guid.NewGuid()
        };
    }

    [Fact]
    public void AddShortage_Returns_True_If_Shortage_Created()
    {
        User regularUser = new User
        {
            Id = Guid.NewGuid(),
            Username = "username",
            Password = "password"
        };
        ShortageService shortageService = new ShortageService(new MockedShortageRepository([]));
        Shortage userCreatedShortage = GetShortage(regularUser.Id);
        bool result = shortageService.AddShortage(userCreatedShortage);
        Assert.True(result);
    }

    [Fact]
    public void AddShortage_Returns_False_If_Shortage_Exists()
    {
        User regularUser = new User
        {
            Id = Guid.NewGuid(),
            Username = "username",
            Password = "password"
        };
        Shortage userCreatedShortage = GetShortage(regularUser.Id);
        ShortageService shortageService = new ShortageService(new MockedShortageRepository([userCreatedShortage]));
        bool result = shortageService.AddShortage(userCreatedShortage);
        Assert.False(result);
    }

    [Fact]
    public void AddShortage_Returns_True_If_Shortage_Exist_But_Is_Lower_Priority()
    {
        User regularUser = new User
        {
            Id = Guid.NewGuid(),
            Username = "username",
            Password = "password"
        };
        Shortage userCreatedShortage = GetShortage(regularUser.Id);
        ShortageService shortageService = new ShortageService(new MockedShortageRepository([userCreatedShortage]));
        Shortage userCreatedShortageWithHigherPriority = GetShortage(regularUser.Id, 7);
        bool result = shortageService.AddShortage(userCreatedShortageWithHigherPriority);
        Assert.True(result);
    }

    [Fact]
    public void GetShortages_Returns_His_Own_Created_Shortages_For_Regular_User()
    {
        const int expectedResultWhenNoCreatedShortages = 0;
        const int expectedResultWhenCreatedShortage = 1;
        Guid id = Guid.NewGuid();
        User regularUser = new User
        {
            Id = id,
            Username = "username",
            Password = "password"
        };
        List<Shortage> shortages = GenerateShortages(10);
        ShortageService shortageService = new ShortageService(new MockedShortageRepository(shortages));
        List<Shortage> result = shortageService.GetShortages(regularUser, null).ToList();


        Assert.Equal(expectedResultWhenNoCreatedShortages, result.Count);

        Shortage userCreatedShortage = GetShortage(regularUser.Id);
        shortageService.AddShortage(userCreatedShortage);

        List<Shortage> resultAfterAddingShortage = shortageService.GetShortages(regularUser, null).ToList();

        Assert.Equal(expectedResultWhenCreatedShortage, resultAfterAddingShortage.Count);
    }

    [Fact]
    public void GetShortages_Returns_AllShortages_ForAdminUser()
    {
        const int expectedResultWhenNoCreatedShortages = 10;
        const int expectedResultWhenCreatedShortage = 11;
        User admin = new Admin
        {
            Id = Guid.NewGuid(),
            Username = "username",
            Password = "password"
        };
        List<Shortage> shortages = GenerateShortages(expectedResultWhenNoCreatedShortages);
        ShortageService shortageService = new ShortageService(new MockedShortageRepository(shortages));
        List<Shortage> result = shortageService.GetShortages(admin, null).ToList();

        Assert.Equal(expectedResultWhenNoCreatedShortages, result.Count);

        Shortage userCreatedShortage = GetShortage(admin.Id);
        shortageService.AddShortage(userCreatedShortage);
        List<Shortage> resultWhenAddedNewShortage = shortageService.GetShortages(admin, null).ToList();
        Assert.Equal(expectedResultWhenCreatedShortage, resultWhenAddedNewShortage.Count);
    }

    [Fact]
    public void DeleteShortage_Admin_Can_Delete_Any_Shortage()
    {
        const int expectedResultWhenNoCreatedShortages = 10;
        const int expectedResultWhenDeleteShortage = 9;
        User admin = new Admin
        {
            Id = Guid.NewGuid(),
            Username = "username",
            Password = "password"
        };
        List<Shortage> shortages = GenerateShortages(expectedResultWhenNoCreatedShortages);
        ShortageService shortageService = new ShortageService(new MockedShortageRepository(shortages));
        List<Shortage> result = shortageService.GetShortages(admin, null).ToList();
        Assert.Equal(expectedResultWhenNoCreatedShortages, result.Count);
        Shortage shortageToDelete = result.First(shortage => shortage.UserId != admin.Id);
        bool deleteResult = shortageService.DeleteShortage(admin, shortageToDelete);
        List<Shortage> resultAfterDeletion = shortageService.GetShortages(admin, null).ToList();
        Assert.True(deleteResult);
        Assert.Equal(expectedResultWhenDeleteShortage, resultAfterDeletion.Count);
    }

    [Fact]
    public void DeleteShortage_User_Can_Not_Delete_Any_Shortage()
    {
        const int expectedResultWhenNoCreatedShortages = 10;
        const int expectedResultWhenDeleteShortage = 10;
        User regularUser = new User
        {
            Id = Guid.NewGuid(),
            Username = "username",
            Password = "password"
        };
        User admin = new Admin
        {
            Id = Guid.NewGuid(),
            Username = "username",
            Password = "password"
        };
        List<Shortage> shortages = GenerateShortages(expectedResultWhenNoCreatedShortages);
        ShortageService shortageService = new ShortageService(new MockedShortageRepository(shortages));
        List<Shortage> shortagesInDatabase = shortageService.GetShortages(admin, null).ToList();
        Assert.Equal(expectedResultWhenNoCreatedShortages, shortagesInDatabase.Count);
        Shortage shortageToDelete = shortagesInDatabase.First();
        bool deleteResult = shortageService.DeleteShortage(regularUser, shortageToDelete);
        List<Shortage> shortagesInDatabaseAfterTryingToDelete = shortageService.GetShortages(admin, null).ToList();
        Assert.False(deleteResult);
        Assert.Equal(expectedResultWhenDeleteShortage, shortagesInDatabaseAfterTryingToDelete.Count);
    }
}