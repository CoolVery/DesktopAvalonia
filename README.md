# DesktopAvalonia
![image](https://github.com/user-attachments/assets/5dd47f95-32a0-47cf-a601-90c763ceafee)
# Описание
Desktop - приложение, визуализирующее данные пользователей программы. Имеет:
1. Систему авторизации
2. Отображение данных в зависимости от роли пользователя
3. Функционал добавления, удаления, изменения данных пользователей
4. Фильтрация и сортировка данных пользователей
5. Запоминание данных при входе
![image](https://github.com/user-attachments/assets/3673fe08-0594-4016-8091-a82556ea020f)
# Демо
##### Авторизация
![image](https://github.com/user-attachments/assets/12e68744-afb1-474f-8264-1412bdd374aa)
##### Личный кабинет обычного пользователя
![image](https://github.com/user-attachments/assets/78aa3f73-bfd6-49a6-b093-fa768cbf352a)
##### Интерфейс администратора приложения
![image](https://github.com/user-attachments/assets/cfcc51fd-e386-4ba7-80b3-3b5943a6b016)
##### Фильтрации
![image](https://github.com/user-attachments/assets/33ed1eeb-1f4e-45d9-97ba-321a1f7c3cf8)
##### Создание пользователя 
![image](https://github.com/user-attachments/assets/0f72bcb9-c5b7-43a0-b8ed-630d9b13a564)
# Технологии в проекте
Основной стек технологий:
- Среда разработки: Visual Studio Community 2022
- Язык программирования: C#
- Основной фреймврок: Avalonia UI
Библиотеки проекта:
- Microsoft.EntityFrameworkCore.Tools, Npgsql.EntityFrameworkCore.PostgreSQL, Microsoft.EntityFrameworkCore.Tools - Позволяют работать с PostgreSQL БД
- CommunityToolkit.mvvm - Позволяет упростить работу с фреймврок Avalonia Mvvm
- Newtonsoft.Json - Позволяет обрабатывать и создавать JSON
# Особенности проекта
1. Кэширование входа - Пользователь пройдет авторизацию только 1 раз, после чего система автоматически будет производить вход
2. Использование серверной части в виде API
3. Возможность выбора изображения фотографии пользователя
4. Несколько возможностей фильтрации и сортировки данных
5. Шифрование пароля в БД
# Техническое описание проекта
### Процесс установки приложения:
1. Откройте Visual Studio Community 2022
2. Через функцию "Клонирование проекта" создать проект. Ссылка: https://github.com/CoolVery/DesktopAvalonia.git
3. После клонирования можно запустить приложение через кнопку "Запустить без отладки"
### Планируемые дополнения
1. Улучшение дизайна
2. Добавление масштабируемости окна
3. Усовершенствование безопасности авторизации
