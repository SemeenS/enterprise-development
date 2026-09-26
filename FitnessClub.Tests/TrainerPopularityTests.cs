namespace FitnessClub.Tests;

/// <summary>
/// Тесты определения популярности тренеров.
/// </summary>
/// <param name="fixture">Фикстура с тестовыми данными.</param>
public class TrainerPopularityTests(FitnessClubFixture fixture) : IClassFixture<FitnessClubFixture>
{
    /// <summary>
    /// Проверяет получение пяти тренеров с наибольшим количеством записей на занятия.
    /// </summary>
    [Fact]
    public void ShouldReturnFiveMostPopularTrainers()
    {
        int[] expectedTrainerIds = [11, 12, 13, 14, 15];

        var actualTrainerIds = fixture.Data.TrainingSessions
            .GroupBy(session => session.Trainer)
            .OrderByDescending(group => group.Count())
            .Take(5)
            .Select(group => group.Key.Id)
            .ToArray();

        Assert.Equal(expectedTrainerIds, actualTrainerIds);
    }
}