# NanoSurvey.API
Апи запускается при помощи команды docker-compose up

Данные хранящиеся в БД можно посмотреть в запросе
Запрос находится в папке Sql

Примеры обращений к ендпоинтам
1. http://localhost/api/survey/8ef9ea18-af28-41cd-b379-34f1f1b651ca/questions/99e48803-23ca-49c5-bac6-c33007af16bc
Данный запрос вернет содержание вопроса, а также все ответы к нему

2. http://localhost/api/surveys/8ef9ea18-af28-41cd-b379-34f1f1b651ca/results
В теле необходимо указать след примерные данные:
```
{
    "QuestionId":"99e48803-23ca-49c5-bac6-c33007af16bc",
    "AnswerId":"d8d0b781-4ee8-4dd2-b598-70b674741f1a",
    "UserId":"552a625c-5f72-4ad5-afb9-f230f7ef3b44"   
}
```
Запрос вернет id следующего вопроса анкеты и сохранит ответ пользователя, если след вопроса нет, он сохранит ответ пользователя и вернет NoContent 204 статус код.
Следующий является следующим для QuestionId в теле
