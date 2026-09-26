namespace FitnessClub.Tests;

/// <summary>
/// Тесты проверки доступности залов.
/// </summary>
/// <param name="fixture">Фикстура с тестовыми данными.</param>
public class GymAvailabilityTests(FitnessClubFixture fixture) : IClassFixture<FitnessClubFixture>
{
    /// <summary>
    /// Проверяет доступность выбранного зала в текущий момент времени.
    /// </summary>
    /// <param name="gymId">Идентификатор зала.</param>
    /// <param name="expectedAvailability">Ожидаемая доступность зала.</param>
    [Theory]
    [InlineData(2, false)]
    [InlineData(7, true)]
    public void ShouldDetermineGymAvailability(int gymId, bool expectedAvailability)
    {
        var now = fixture.ReferenceTime;

        var isAvailable = !fixture.Data.TrainingSessions.Any(session => 
            session.Gym.Id == gymId && session.EndsAt.HasValue && session.StartsAt <= now && now < session.EndsAt.Value);

        Assert.Equal(expectedAvailability, isAvailable);
    }
}