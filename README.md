# Notes
[Тестовое задание](https://docs.yandex.ru/docs/view?url=ya-disk-public%3A%2F%2FX8%2BNZzrjrsW1DHi9w71eCC05f4uZeSq82bJtCFbxEY19MUwYrug9TQ0gkQUFvEtE%2FCH%2B%2BsnE5duAiqM%2FEjDILQ%3D%3D&name=%D0%A2%D0%B5%D1%81%D1%82%D0%BE%D0%B2%D0%BE%D0%B5%20%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5%20%D0%B4%D0%BB%D1%8F%20%D1%83%D1%87%D0%B0%D1%81%D1%82%D0%BD%D0%B8%D0%BA%D0%B0%20%D0%B8%D0%BD%D1%82%D0%B5%D0%BD%D1%81%D0%B8%D0%B2%D0%B0%20Backend%20%D0%B8%20WEB.pdf&nosw=1) от компании Simbirsoft для прохождения весеннего интенсива.

## Стек технологий

- Backend
  - Язык программирования C#
  - Фреймворк ASP.NET Core
  - PostgreSQL в качестве СУБД

- Frontend
  - Blazor
  - Bootstrap

## Используемые инструменты

- Visual Studio 2022
- Docker - для развёртывания и управления приложениями
- pgAdmin 4 - для работы с базой данных

***

Библиотека                                                  |Задача
:-----------------------------------------------------------|:---------------------------------------------------------------
`Npgsql.EntityFrameworkCore.PostgreSQL`                     | для работы с базой данных
`Microsoft.AspNetCore.ApiAuthorization.IdentityServer`      | типы для использования IdentityServer
`Microsoft.AspNetCore.Identity.UI`                          | для отрисовки страниц с авторизацией и аутентификацией
`AutoMapper`                                                | для проецирования одного объекта на другой
`AutoMapper.Extensions.Microsoft.DependencyInjection`       | для добавления AutoMapper в DI
`Microsoft.Extensions.Http`                                 | для настройки и извлечения именованных HttpClients 
`Microsoft.AspNetCore.Components.WebAssembly.Authentication`| типы для защиты приложений Blazor WASM
`Blazored.Toast`                                            | для уведомления пользователей о результате операций
`Microsoft.VisualStudio.Azure.Containers.Tools.Targets`     | для построения, отладки и развертывания контейнерных приложений

## Развертывание окружения

Для развертывания окружения необходимо клонировать репозиторий и запустить проект docker-compose
