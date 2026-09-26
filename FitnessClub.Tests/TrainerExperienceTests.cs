namespace FitnessClub.Tests;

/// <summary>
/// Тесты выборки тренеров по стажу работы.
/// </summary>
/// <param name="fixture">Фикстура с тестовыми данными.</param>
public class TrainerExperienceTests(FitnessClubFixture fixture) : IClassFixture<FitnessClubFixture>
{
    /// <summary>
    /// Проверяет выборку тренеров со стажем не менее пяти лет.
    /// </summary>
    [Fact]
    public void ShouldReturnTrainersWithAtLeastFiveYearsExperience()
    {
        string[] expectedNames =
        [
            "Соколов Артём Викторович",
            "Крылова Наталья Сергеевна",
            "Попов Максим Ильич",
            "Лебедева Дарья Александровна",
            "Новиков Артур Валерьевич",
            "Павлова Светлана Юрьевна"
        ];

        var actualNames = fixture.Data.Trainers
            .Where(trainer => trainer.WorkExperience >= 5)
            .Select(trainer => trainer.FullName)
            .ToArray();

        Assert.Equal(expectedNames, actualNames);
    }
}