# Лабораторная работа №1

Учебный проект по дисциплине «Разработка корпоративных систем» на платформе .NET 10.

## Описание проекта

Проект представляет предметную область **фитнес-клуба**.

Система содержит информацию о клиентах, тренерах, специализациях тренеров, залах и записях клиентов на персональные занятия.

В рамках лабораторной работы реализованы LINQ-запросы для получения необходимой информации по предметной области.

---

## Технологический стек

- Платформа: .NET 10.0
- Язык программирования: C#
- Фреймворк тестирования: xUnit v3
- Continuous Integration: GitHub Actions
- Формат решения: SLNX

---

## Структура лабораторной работы

```text
enterprise-development/
├── .github/
│   └── workflows/
│       └── dotnet-ci.yml              # конфигурация GitHub Actions
│
├── docs/
│   └── test_results.png               # результаты выполнения unit-тестов
│
├── FitnessClub.Domain/
│   ├── Data/
│   │   └── FitnessClubDataSeeder.cs   # подготовка тестовых данных
│   │
│   ├── Entities/
│   │   ├── Client.cs                  # модель клиента
│   │   ├── Gym.cs                     # модель зала
│   │   ├── Person.cs                  # базовый класс клиента и тренера
│   │   ├── Specialization.cs          # специализация тренера
│   │   ├── Trainer.cs                 # модель тренера
│   │   └── TrainingSession.cs         # запись клиента на занятие
│   │
│   ├── Enums/
│   │   └── Gender.cs                  # перечисление пола
│   │
│   └── FitnessClub.Domain.csproj
│
├── FitnessClub.Tests/
│   ├── ClientSubscriptionTests.cs     # клиенты с истёкшими абонементами
│   ├── FitnessClubFixture.cs          # общие тестовые данные
│   ├── GymAvailabilityTests.cs        # проверка доступности залов
│   ├── MonthlyTrainingTests.cs        # занятия текущего месяца
│   ├── TrainerExperienceTests.cs      # выборка тренеров по стажу
│   ├── TrainerPopularityTests.cs      # пять наиболее популярных тренеров
│   └── FitnessClub.Tests.csproj
│
├── FitnessClub.slnx                   # файл решения
└── README.md                          # документация лабораторной работы
```

## Реализованные запросы

1. Получение всех тренеров со стажем работы не менее 5 лет.
2. Проверка доступности выбранного зала в текущий момент времени.
3. Получение клиентов с истёкшим абонементом с сортировкой по ФИО.
4. Получение занятий за текущий месяц в выбранном зале.
5. Получение пяти наиболее популярных тренеров.

---

## Запуск и тестирование

### Предварительные требования

- .NET 10.0 SDK

### Клонирование репозитория

```bash
git clone https://github.com/SemeenS/enterprise-development.git
cd enterprise-development
```

### Восстановление зависимостей

```bash
dotnet restore ./FitnessClub.slnx
```

### Сборка проекта

```bash
dotnet build ./FitnessClub.slnx --no-restore --configuration Release
```

### Запуск unit-тестов

```bash
dotnet test ./FitnessClub.slnx --no-build --configuration Release --verbosity normal
```
