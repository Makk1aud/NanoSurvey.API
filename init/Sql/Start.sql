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


