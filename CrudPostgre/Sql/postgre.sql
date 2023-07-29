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
--------------------------------------------------------------------------------

create or replace function read_employee()

returns setof Employee language sql as $$
    select * from Employee;
$$;

select * from read_employee();

--------------------------------------------------------------------------------
create or replace procedure create_employee(
   	EmployeeName varchar(500), 
	Departament varchar(500), 
	PhotoFileName varchar(500)
)
language plpgsql    
as $$
begin
    
	insert into Employee (EmployeeName, Departament, DateOfJoing, PhotoFileName) 
				  values (EmployeeName, Departament, now(), PhotoFileName);
    
    commit;
end;$$

call create_employee('Daisy', 'TI', 'daisy.png')

--------------------------------------------------------------------------------

create or replace procedure update_employee(
   	_EmployeeId int, 
	_EmployeeName varchar(500), 
	_Departament varchar(500), 
	_PhotoFileName varchar(500)
)
language plpgsql    
as $$
begin
    
	update Employee set
		EmployeeName = _EmployeeName, 
		Departament = _Departament, 
		PhotoFileName = _PhotoFileName
	where EmployeeId = _EmployeeId;
    
    commit;
end;$$

call create_employee(1, 'Daisy', 'TI', 'daisy.png')

--------------------------------------------------------------------------------

create or replace function read_by_id_employee(_EmployeeId int)

returns setof Employee language sql as $$
    select * from Employee where EmployeeId = _EmployeeId;
$$;

select * from read_by_id_employee(1);

--------------------------------------------------------------------------------
create or replace procedure delete_employee(
   	_EmployeeId int
)
language plpgsql    
as $$
begin
    
	delete from Employee where EmployeeId = _EmployeeId;
    
    commit;
end;$$

call delete_employee(3)