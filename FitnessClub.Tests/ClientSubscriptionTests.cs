namespace FitnessClub.Tests;

/// <summary>
/// Тесты выборки клиентов по состоянию абонемента.
/// </summary>
/// <param name="fixture">Фикстура с тестовыми данными.</param>
public class ClientSubscriptionTests(FitnessClubFixture fixture) : IClassFixture<FitnessClubFixture>
{
    /// <summary>
    /// Проверяет выборку клиентов с истёкшим абонементом с сортировкой по ФИО.
    /// </summary>
    [Fact]
    public void ShouldReturnClientsWithExpiredSubscriptionsOrderedByName()
    {
        string[] expectedNames =
        [
            "Андреев Алексей Сергеевич",
            "Беляева Мария Олеговна",
            "Васильев Дмитрий Игоревич",
            "Громова Елена Павловна",
            "Денисов Павел Андреевич"
        ];

        var today = DateOnly.FromDateTime(fixture.ReferenceTime);

        var actualNames = fixture.Data.Clients
            .Where(client => client.SubscriptionEndDate < today)
            .OrderBy(client => client.FullName)
            .Select(client => client.FullName)
            .ToArray();

        Assert.Equal(expectedNames, actualNames);
    }
}