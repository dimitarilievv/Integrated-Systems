Потребно е да се постави проект за ASP.NET Core апликација со Onion Architecture и да се имплементира само Domain и Web слојот за следните ентитети со атрибути:

Student (Name, Surname, DateOfBirth, Index, EnrollmentYear)

Сите атрибути освен EnrollmentYear се задолжителни

Course (Name, Semester)

Lecture (Name, Date)

Enrollment (DateEnrolled, ReEnrolled)

При тоа, потребно е соодветно да се конфигурира DbContext за работа со SQL Server база на податоци и да се креира иницијална шема во база. Да се креираат контролери и погледи со CRUD операции за Student, Course и Lecture. Контролерите и погледите од Web слојот, иницијално може да се креираат со scaffolding функционалност.

Дополнително, потребно е да се имплементира custom апликациски корисник (CoursesApplicationUser), што покрај основните податоци, ќе чува податоци и за датумот на раѓање, името и презимето на корисникот.

ER Дијаграм со релации е даден во продолжение:

Student ↔ Enrollment → 1:N

Enrollment ↔ Course → N:1

Lecture ↔ Course → 1:N
