namespace FitnessClub.Tests;

/// <summary>
/// Тесты выборки занятий по месяцу и залу.
/// </summary>
/// <param name="fixture">Фикстура с тестовыми данными.</param>
public class MonthlyTrainingTests(FitnessClubFixture fixture) : IClassFixture<FitnessClubFixture>
{
    /// <summary>
    /// Проверяет получение занятий текущего месяца для выбранного зала.
    /// </summary>
    [Fact]
    public void ShouldReturnCurrentMonthTrainingsForSelectedGym()
    {
        const int gymId = 1;

        int[] expectedSessionIds = [1, 2, 3];

        var actualSessionIds = fixture.Data.TrainingSessions
            .Where(session => session.Gym.Id == gymId &&
                session.StartsAt.Year == fixture.ReferenceTime.Year &&
                session.StartsAt.Month == fixture.ReferenceTime.Month)
            .Select(session => session.Id)
            .ToArray();

        Assert.Equal(expectedSessionIds, actualSessionIds);
    }
}