#SystemDiary
SystemDiary - проект команды Cappuccino

## Предназначение:

SystemDiary - программное обеспечение предназначенное для оптимизации учемного процесса учащихся техникумов, и работы сотрудников.

## Технологии разработки:

### Backend

Разработан на языке высокого уровня C# (Си шарп). На нём написан API сервер и взаимодействие с базой данных.
Для базы данных используется MSSQL.
Backend работает на ASP .NET Core 6 версии. Ещё использовались библиотеки и фреймворки:
- EntityFramework - позволяет работать с коллекциями базы данных с инструментарием LINQ
- System.IdentityModel.Tokens.Jwt - модуль дающий возможность работать с JWT (JSON Web Token) для аунтификации пользователя в приложении
- Swagger - модуль для тестиования API контроллеров приложения
- NUnit - фреймворк для проведения Unit тестов модулей

### Frontend

Для работы frontend-приложения использовались:
- ReactJS - основной фреймворк для frontend
- Redux - глобальный объект хронящий в себе состояния и позволяющий отслеживать изменения состояний сущности
- Redux-toolkit - дополнения для Redux заточенные для работы с React и упрощабщие работу с сосотяниями Redux
- React-router-dom - библиотека для маршрутеризации и перенаправлениями в React
- React-dom - библиотера для работы с dom деревом в React
- Typescript - препроцессор для Javascript и компиляции дополнительных модулей
- SASS - препроцессор для css

## Ситемные требования

### Общие

- Видеокарта не требуется

### Минимальные

- 4Гб опреативной памяти
- 4 ядерный процессор на 2.8Ггц
- Пространство на диске 120Гб
- SSD/SSD m2 не требуется
- Сетевая карта с пропускной способностью 1Гб/с

### Рекомендуемые

- 16Гб опреативной памяти
- 4 ядерный процессор на 3.1Ггц
- Пространство на диске 1024Гб
- SSD/SSD m2 обязательно
- Сетевая карта с пропускной способностью 1Гб/с и выше

## Программные требования

- Операционная система Windows 8 и выше, Windows Server 2019, Операционные системы симейства Linux Ubuntu 18 и выше
- .NET Core 6 и выше
- NodeJS версии 16 и выше
- npm 8.19.2 и выше

## Поддержка браузеров

| Браузеры  | Chrome | Opera | Mozilla | IE  | Edge | Safari |
|-----------|--------|------ |---------|-----|----- |--------|
| Поддержка | ✅ Да  | ✅ Да| ✅ Да      | ❌ Нет | ✅ Да   | ✅ Да     |

## Разработчики

[⚽ Бибис](https://vk.com/detskiy_pogreb73)
[🎈 Somniknight | Анастасия Павловна](https://vk.com/naturalovnet)
[🎨 Sunflow1e](https://vk.com/sunflow1e)
[🔋 Oooval](https://vk.com/oooo.o.oooo)
[💾 LetNull19A](https://vk.com/letnull19a)
