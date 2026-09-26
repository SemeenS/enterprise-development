namespace FitnessClub.Domain.Entities;

/// <summary>
/// Специализация тренера.
/// </summary>
public class Specialization
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Название специализации.
    /// </summary>
    public required string Name { get; init; }
}