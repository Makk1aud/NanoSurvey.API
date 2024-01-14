CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

create table Users
(
	user_id uuid Primary Key default uuid_generate_v4 (),
	first_name varchar(30) Not Null,
	last_name varchar(40) Null,
	email varchar(40) Not Null Unique
);

create table Surveys
(
	survey_id uuid Primary Key default uuid_generate_v4 (),
	title varchar(100) Not Null,
	creation_date timestamp Not Null
);

create table Questions
(
	question_id uuid Primary Key default uuid_generate_v4 (),
	survey_id uuid Not Null references Surveys(survey_id) On Delete Cascade,
	content varchar(100) Not Null
);

create table Answers
(
	answer_id uuid Primary Key default uuid_generate_v4 (),
	question_id uuid Not Null references Questions(question_id) On Delete Cascade,
	content varchar(100) Not Null
);

create table Results
(
	result_id uuid Primary Key default uuid_generate_v4 (),
	question_id uuid Not Null,
	answer_id uuid Not Null,
	user_id uuid Not Null,
	Constraint FK_questionId_Result_Question Foreign key (question_id) references Questions(question_id),
	Constraint FK_answerId_Resutl_Answer Foreign key (answer_id) references Answers(answer_id),
	Constraint FK_userId_Result_User Foreign key (user_id) references Users(user_id)
);

create table Interviews
(
	interview_id uuid Primary Key default uuid_generate_v4 (),
	survey_id uuid Not Null,
	user_id uuid Not Null,
	passing_date timestamp Not Null,
	Constraint FK_surveyId_Interview_Survey Foreign key (survey_id) references Surveys(survey_id),
	Constraint FK_userId_Interview_User Foreign key (user_id) references Users(user_id)
);

CREATE INDEX user_id_Results_idx ON Results(user_id);

CREATE UNIQUE INDEX user_id_Interview_idx ON Interviews(user_id);

INSERT INTO public.surveys(
	survey_id, title, creation_date)
	VALUES ('8ef9ea18-af28-41cd-b379-34f1f1b651ca', 'Анкета про животных', '2000-10-12');
    
INSERT INTO public.questions(
	question_id, survey_id, content)
	VALUES ('a626cef2-8089-4b81-8590-c21c5c8f57ab', '8ef9ea18-af28-41cd-b379-34f1f1b651ca', 'Сколько вам лет?'),
    ('bec68027-deff-4197-b0cc-c063418dd03a', '8ef9ea18-af28-41cd-b379-34f1f1b651ca', 'Какой ваш любимый цвет?'),
	('99e48803-23ca-49c5-bac6-c33007af16bc', '8ef9ea18-af28-41cd-b379-34f1f1b651ca', 'В какой стране вы живете?');
    
INSERT INTO public.answers(
	answer_id, question_id, content)
	VALUES ('7a9bd957-07a0-4f04-b60d-93f599561ac2', 'a626cef2-8089-4b81-8590-c21c5c8f57ab', 'Меньше 12'),
	('93c4881b-0d15-44f7-8353-f9a4e40831f6', 'a626cef2-8089-4b81-8590-c21c5c8f57ab', 'Больше 18'),
	('de06c29b-2318-40f3-b3b5-926cbafc95b2', 'a626cef2-8089-4b81-8590-c21c5c8f57ab', 'Больше 40');
    
INSERT INTO public.answers(
	answer_id, question_id, content)
	VALUES ('7fe5944f-93b9-47e0-ab90-467f6bed18d2', 'bec68027-deff-4197-b0cc-c063418dd03a', 'Красный'),
	('1570ab2e-c314-48d1-a375-3a2c24f1d26e', 'bec68027-deff-4197-b0cc-c063418dd03a', 'Зеленый'),
	('06681146-bdd2-4d73-b312-2e21d84de665', 'bec68027-deff-4197-b0cc-c063418dd03a', 'Желтый');
    
INSERT INTO public.answers(
	answer_id, question_id, content)
	VALUES ('d8d0b781-4ee8-4dd2-b598-70b674741f1a', '99e48803-23ca-49c5-bac6-c33007af16bc', 'Россия'),
	('48181764-2e67-42f7-b1ec-eee97f4bec43', '99e48803-23ca-49c5-bac6-c33007af16bc', 'Великобритания'),
	('40b0436b-a751-421b-8e5d-f09df5e68504', '99e48803-23ca-49c5-bac6-c33007af16bc', 'Албания');
    
INSERT INTO public.users(
	user_id, first_name, last_name, email)
	VALUES ('552a625c-5f72-4ad5-afb9-f230f7ef3b44', 'Андрей', 'Наседкин', 'nasedkin@mail.ru');
