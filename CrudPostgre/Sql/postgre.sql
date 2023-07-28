create table Departament(
    DepartamentId serial,
    DepartamentName varchar(500)
)

insert into Departament(DepartamentName) values ('IT')
insert into Departament(DepartamentName) values ('Support')

select * from departament

create table Employee(
    EmployeeId serial,
    EmployeeName varchar(500),
    Departament varchar(500),
    DateOfJoing timestamp,
    PhotoFileName varchar(500)
);

insert into Employee (EmployeeName, Departament, DateOfJoing, PhotoFileName) values ('Bob', 'IT', now(), 'anonymous.png')
insert into Employee (EmployeeName, Departament, DateOfJoing, PhotoFileName) values ('Wesley', 'IT', now(), 'wesley.png')

select * from Employee