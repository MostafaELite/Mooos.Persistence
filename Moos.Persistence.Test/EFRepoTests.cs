using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moos.Persistence.Repos;
using Moos.Persistence.Test.TestContext;

namespace Moos.Persistence.Test;

public class EFRepoTests
{
    private ServiceProvider provider;

    [SetUp]
    public void Setup()
    {
        var services = new ServiceCollection();
        services.AddScoped<DbContext, OrderContext>();
        //services.AddScoped(typeof(IncludableRepository<,>));
        provider = services.BuildServiceProvider();
    }

    [Test]
    public async Task EFRepoTest()
    {
        //var repo = provider.GetService<IncludableRepository<Order, int>>()!;
        //await repo.Add(new Order(1, DateTime.Today, null));
        //await repo.Add(new Order(2, DateTime.Today.AddDays(-5), null));
        //repo.Commit();

        //var orders = await repo.GetAll();
        //Assert.That(orders.Length, Is.EqualTo(2));
        var q = new IncludableRepository<ServiceProvider, int, int>(null);

    }

    [TearDown]
    public async Task AfterTest() => await provider.DisposeAsync();
}