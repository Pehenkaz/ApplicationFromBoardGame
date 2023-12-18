using BoardGameCampaign.DataAccess;
using BoardGameCampaign.DataAccess.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace BoardGameCampaign.UnitTests.Repository;

[TestFixture]
[Category("Intedration")]
public class PlayerRepositoryTest : RepositoryTestsBaseClass
{
	[Test]
	public void GetAllPlayersTest()
	{
        //prepare
        using var context = DbContextFactory.CreateDbContext();
		var players = new PlayerEntity[]
		{
			new PlayerEntity()
			{
				Login = "testLogin1",
				Password = "******1",
				FirstName = "Name1",
				SecondName = "SecondName1",
				Patronymic = "Patronymic1",
				Age = 22,
				ExternalId = Guid.NewGuid()
			},
			new PlayerEntity()
			{
                Login = "testLogin2",
                Password = "******2",
                FirstName = "Name2",
                SecondName = "SecondName2",
                Patronymic = "Patronymic2",
                Age = 20,
                ExternalId = Guid.NewGuid()
            }
		};
		context.Players.AddRange(players);
		context.SaveChanges();

        //execute
        var repository = new Repository<PlayerEntity>(DbContextFactory);
        var actualPlayers = repository.GetAll();

        //assert        
        actualPlayers.Should().BeEquivalentTo(players);
    }

    [Test]
    public void GetAllPlayersWithFilterTest()
    {
        //prepare
        using var context = DbContextFactory.CreateDbContext();
        var players = new PlayerEntity[]
        {
            new PlayerEntity()
            {
                Login = "testLogin1",
                Password = "******1",
                FirstName = "Name1",
                SecondName = "SecondName1",
                Patronymic = "Patronymic1",
                Age = 22,
                ExternalId = Guid.NewGuid()
            },
            new PlayerEntity()
            {
                Login = "testLogin2",
                Password = "******2",
                FirstName = "Name2",
                SecondName = "SecondName2",
                Patronymic = "Patronymic2",
                Age = 20,
                ExternalId = Guid.NewGuid()
            }
        };
        context.Players.AddRange(players);
        context.SaveChanges();

        //execute
        var repository = new Repository<UserEntity>(DbContextFactory);
        var actualPlayers = repository.GetAll(x => x.FirstName == "Name1").ToArray();

        //assert
        actualPlayers.Should().BeEquivalentTo(players.Where(x => x.FirstName == "Name1"));
    }

    [Test]
    public void SaveNewPlayerTest()
    {
        //prepare
        using var context = DbContextFactory.CreateDbContext();

        //execute
        var player = new PlayerEntity()
        {
            Login = "testLogin1",
            Password = "******1",
            FirstName = "Name1",
            SecondName = "SecondName1",
            Patronymic = "Patronymic1",
            Age = 22,
            ExternalId = Guid.NewGuid()
        };
        var repository = new Repository<UserEntity>(DbContextFactory);
        repository.Save(player);

        //assert
        var actualPlayer = context.Players.SingleOrDefault();
        actualPlayer.Should().BeEquivalentTo(player, options => options.Excluding(x => x.Id)
            .Excluding(x => x.ModificationTime)
            .Excluding(x => x.CreationTime)
            .Excluding(x => x.ExternalId));
        actualPlayer.Id.Should().NotBe(default);
        actualPlayer.ModificationTime.Should().NotBe(default);
        actualPlayer.CreationTime.Should().NotBe(default);
        actualPlayer.ExternalId.Should().NotBe(Guid.Empty);
    }

    [Test]
    public void UpdatePlayerTest()
    {
        //prepare
        using var context = DbContextFactory.CreateDbContext();
        var player = new PlayerEntity()
        {
            Login = "testLogin1",
            Password = "******1",
            FirstName = "Name1",
            SecondName = "SecondName1",
            Patronymic = "Patronymic1",
            Age = 22,
            ExternalId = Guid.NewGuid()
        };
        context.Players.Add(player);
        context.SaveChanges();

        //execute
        player.FirstName = "new Name1";
        player.SecondName = "new SecondName1";
        player.Patronymic = "new Patronymic1";
        var repository = new Repository<PlayerEntity>(DbContextFactory);
        repository.Save(player);

        //assert
        var actualPlayer = context.Players.SingleOrDefault();
        actualPlayer.Should().BeEquivalentTo(player);
    }

    [Test]
    public void DeletePlayerTest()
    {
        //prepare
        using var context = DbContextFactory.CreateDbContext();
        var player = new PlayerEntity()
        {
            Login = "testLogin1",
            Password = "******1",
            FirstName = "Name1",
            SecondName = "SecondName1",
            Patronymic = "Patronymic1",
            Age = 22,
            ExternalId = Guid.NewGuid()
        };
        context.Players.Add(player);
        context.SaveChanges();

        //execute
        var repository = new Repository<PlayerEntity>(DbContextFactory);
        repository.Delete(player);

        //assert
        context.Players.Count().Should().Be(0);
    }

    [Test]
    public void GetByPlayerTest()
    {
        //prepare
        using var context = DbContextFactory.CreateDbContext();
        var players = new PlayerEntity[]
        {
            new PlayerEntity()
            {
                Login = "testLogin1",
                Password = "******1",
                FirstName = "Name1",
                SecondName = "SecondName1",
                Patronymic = "Patronymic1",
                Age = 22,
                ExternalId = Guid.NewGuid()
            },
            new PlayerEntity()
            {
                Login = "testLogin2",
                Password = "******2",
                FirstName = "Name2",
                SecondName = "SecondName2",
                Patronymic = "Patronymic2",
                Age = 20,
                ExternalId = Guid.NewGuid()
            }
        };
        context.Players.AddRange(players);
        context.SaveChanges();

        // positive case
        //execute
        var repository = new Repository<PlayerEntity>(DbContextFactory);
        var actualUser = repository.GetById(players[0].Id);
        //assert
        actualUser.Should().BeEquivalentTo(players[0]);

        // negative case
        //execute
        actualUser = repository.GetById(players[players.Length - 1].Id + 10);
        //assert
        actualUser.Should().BeNull();
    }

    [SetUp]
    public void SetUp()
    {
        CleanUp();
    }

    [TearDown]
    public void TearDown()
    {
        CleanUp();
    }

    public void CleanUp()
    {
        using(var context = DbContextFactory.CreateDbContext())
        {
            context.Players.RemoveRange(context.Players);
            context.SaveChanges();
        }
    }
}