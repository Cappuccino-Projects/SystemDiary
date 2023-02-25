# CHANGELOGS

## version - 0.0.1.51 - 25 февраля 2023 - [letnull19a](https://github.com/letnull19A)

### Добавлено

+ Добавлено решение Cappuccino.SystemDiary.Factories
+ Добавлено решение Cappuccino.SystemDiary.Core.Test
+ Добавлено свойство Users - рекомендовано к использованию (IDataBaseContext)
+ Добавлено свойство UserRoles - рекомендовано к использованию (IDataBaseContext)
+ Добавлено свойство UserStates - рекомендовано к использованию (IDataBaseContext)
+ Добавлено свойство Groups - рекомендовано к использованию (IDataBaseContext)
+ Добавлено свойство GroupStates - рекомендовано к использованию (IDataBaseContext)
+ Добавлено свойство News - рекомендовано к использованию (IDataBaseContext)
+ Добавлено свойство NewsStates - рекомендовано к использованию (IDataBaseContext)
+ Добавлено свойство Disciplines - рекомендовано к использованию (IDataBaseContext)
+ Добавлено свойство DisciplineStates - рекомендовано к использованию (IDataBaseContext)
+ Добавлено свойство Marks - рекомендовано к использованию (IDataBaseContext)
+ Добавлено свойство MarkStates - рекомендовано к использованию (IDataBaseContext)
+ Добавлено свойство JournalMarks - рекомендовано к использованию (IDataBaseContext)
+ Добавлено свойство JournalStates - рекомендовано к использованию (IDataBaseContext)
+ Добавлено свойство Journals - рекомендовано к использованию (IDataBaseContext)
+ Добавлено свойство Timetables - рекомендовано к использованию (IDataBaseContext)
+ Добавлено свойство TimeTableLessons - рекомендовано к использованию (IDataBaseContext)
+ Добавлено свойство Cabinets - рекомендовано к использованию (IDataBaseContext)
+ Добавлено свойство RefreshTokens - рекомендовано к использованию (IDataBaseContext)
+ Добавлено свойство UserContacts - рекомендовано к использованию (IDataBaseContext)

### Багофикс

### Изменения

+ Переустановка пакетов NuGet

### Рефакторинг

+ Cappuccino.SystemDiary.DataBaseMock переименован в Cappuccino.SystemDiary.DataBaseInMemory
+ GetCabinets() - помечен как устаревший
+ GetDisciplines() - помечен как устаревший
+ GetDisciplineStates() - помечен как устаревший
+ GetGroups() - помечен как устаревший
+ GetGroupStates() - помечен как устаревший
+ GetJournalMarks() - помечен как устаревший
+ GetJournals() - помечен как устаревший
+ GetJournalStates() - помечен как устаревший
+ GetMarks() - помечен как устаревший
+ GetMarkStates() - помечен как устаревший
+ GetNews() - помечен как устаревший
+ GetNewsStates() - помечен как устаревший
+ GetRefreshTokens() - помечен как устаревший
+ GetTimeTableLessons() - помечен как устаревший
+ GetTimeTables() - помечен как устаревший
+ GetUserContacts() - помечен как устаревший
+ GetUserRoles() - помечен как устаревший
+ GetUsers() - помечен как устаревший
+ GetUserStates() - помечен как устаревший

## version - 0.0.1.50 - 19 февраля 2023 - [letnull19a](https://github.com/letnull19A)

### Добавлено

+ Добавлено решение Cappuccino.SystemDiary.Factories
+ UserFactory

### Багофикс

### Рефакторинг

+ Перенос фабрик из DataBaseContext в отдельное решение Factories
+ Функции получения Get* помечены как deprecated и к использованию не рекомендуются
+ В IDataBaseContext добавлены свойства, новый способ работы с полями

## version - 0.0.1.49 - 16 февраля 2023 - [letnull19a](https://github.com/letnull19A)

### Добавлено

+ Добавлено решение Cappuccino.SystemDiary.DataBaseMock
+ Добавлена новая директория MOCKED

### Багофикс

### Рефакторинг

+ Изменено пространство имён WebAPI -> Cappuccino.SystemDiary.WebAPI