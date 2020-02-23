create database DEALSONWHEELS;

create table DEALSONWHEELS.DealsOnWheels (BranchNo INT, Address text, totalRevenue int,
Constraint DOW_PK primary key (BranchNo));

 
create table DEALSONWHEELS.person(ssn int not null, Fname varchar(10) not null, Lname varchar(10),
constraint person_pk primary key(ssn));

create table DEALSONWHEELS.personaddress(ssn int not null, personAddress varchar(30), 
constraint person_pk primary key(ssn,personAddress),
constraint person_address_FK FOREIGN KEY(ssn) references person(ssn)
 ON UPDATE CASCADE
 ON DELETE CASCADE);
 
create table DEALSONWHEELS.employee(ssn int not null , salary numeric(9), working_hours int,  BranchNo INT,
constraint emp_PK primary key (ssn),
constraint emp_person_FK FOREIGN KEY(ssn) references person(ssn),
constraint emp_DoW_FK FOREIGN KEY(BranchNo) references DealsOnWheels(BranchNo)
ON DELETE CASCADE
ON UPDATE CASCADE
);

create table DEALSONWHEELS.customer(cars_bought numeric(4), payment int, ssn int not null,
constraint ssn_pk primary key(ssn),
constraint Cus_person_FK FOREIGN KEY(ssn) references person(ssn)
ON UPDATE CASCADE
ON DELETE CASCADE
);

create table DEALSONWHEELS.manager (mngr_ssn int, mgr_name text,
constraint mng_PK primary key (mngr_ssn),
constraint mngr_person_FK FOREIGN KEY(mngr_ssn) references employee(ssn)
ON UPDATE CASCADE
ON DELETE CASCADE);

create table DEALSONWHEELS.sales_person (cars_sold numeric(4), comission int, salesPersonSSN int, Mng_ssn int,
constraint ss_pk primary key (salesPersonSSN),
constraint Sperson_person_FK FOREIGN KEY(salesPersonSSN) references person(ssn),
constraint person_manager_FK FOREIGN KEY(Mng_ssn) references manager(mngr_ssn)
ON UPDATE CASCADE
ON DELETE CASCADE
);


create table DEALSONWHEELS.Cars(CarID numeric(10), yearr int ,price int ,carname text, category varchar(15),  BranchNo INT, bought_date int, ssn int not null,
constraint Cars_PK primary key (CarID),
constraint car_DoW_FK FOREIGN KEY(BranchNo) references DealsOnWheels(BranchNo),
constraint cars_foreign foreign key(ssn) references customer(ssn)
ON UPDATE CASCADE
ON DELETE CASCADE);


create table DEALSONWHEELS.Cars_specs(CarID numeric(10), power int , eng_size int, transmission text , eng_type text, speed int,
constraint Cars_pk1 primary key (CarID),
constraint cars_specs_FK foreign key (CarID) references Cars(CarID)
ON UPDATE CASCADE
ON DELETE CASCADE);

create table DEALSONWHEELS.supplier(supplierID numeric(15), sname varchar(15), country text, payment_due int, 
Constraint supplier_PK primary key (supplierID)
);

create table DealsONWHEELS.cars_supplied(supplierID numeric(15), carID numeric(10),
constraint primaryKey primary key(supplierID,carID),
constraint foreignKey foreign key (supplierID) references  supplier(supplierID),
constraint foreignKey2 foreign key (CarID) references cars(CarID)
ON UPDATE CASCADE
on delete cascade);

create table DEALSONWHEELS.supplierContact(supplierID numeric(15),contactno INT,SupplierAddress varchar(16), 
constraint supplier_key primary key(contactno,supplierID,SupplierAddress),
 constraint supplier_contact_FK FOREIGN KEY(supplierID) references supplier(supplierID)
 ON UPDATE CASCADE
 ON DELETE CASCADE);
 
 create table DEALSONWHEELS.bought_from(supplierID numeric(15), CarID numeric(10),
 constraint DOW_PK primary key(supplierID,carID),
 constraint DOW_supplier_FK foreign key (supplierID) references  supplier(supplierID) ,
 constraint DOW_cars_FK foreign key (CarID) references  Cars(CarID) 
 );


create table DEALSONWHEELS.login(username varchar(15), password1 varchar(15), phone numeric(11), primary key(username));

create table DEALSONWHEELS.credit_card(bankname VARCHAR(5), bankNo int,
constraint bank_no primary key (bankNo));


USE DEALSONWHEELS;
Create view  total_cars as 
Select count(CARID) as TotalCars, sum(price) as totalprice
From cars;

delimiter @
create trigger total_amount 
BEFORE DELETE ON dealsonwheels.cars
for each row
begin 
	if old.CARID is not null then
    update dealsonwheels
    set totalRevenue =  totalRevenue + old.price
    where branchNo=old.branchNo;
    end if;
    end@
 
 delimiter @
 create procedure carInfo(IN param1 int)
 begin
 select carname, yearr, power, eng_size, transmission, eng_type
 From cars natural join cars_specs
 where carID=param1;
 end;@
 
  delimiter @
 create procedure emmpInfo(IN param1 int)
 begin
 select ssn, fname, lname, salary, working_hours, BranchNo
 From person natural join employee
 where ssn=param1;
 end;@
 
 delimiter @
create trigger revenueTot
after update ON dealsonwheels.employee
for each row
begin 
	if old.ssn is not null then
    update dealsonwheels
    set totalRevenue =  totalRevenue+ old.salary - new.salary
    where branchNo=new.branchNo;
    end if;
    end@
    
 delimiter @
create trigger revenueTotinst
after insert ON dealsonwheels.employee
for each row
begin 
	if new.ssn is not null then
    update dealsonwheels
    set totalRevenue =  totalRevenue - new.salary
    where branchNo=new.branchNo;
    end if;
    end@

 delimiter @
 create procedure carSearchAtt(IN param1 varchar(30), IN param2 varchar(30))
 begin
 select CarID,carname, category, yearr, power, eng_size, transmission, eng_type
 From cars natural join cars_specs
 where category=param1 and transmission=param2;
 end;@
 
 


insert INTO  DealsOnWheels VALUES(1, "DUBAI", "100000");

INSERT into DealsOnWheels values (2, "SHARJAH" , "100000");

INSERT INTO person values(1,"Farrukh","Rashid");
INSERT INTO person values(2,"Ziad","Siddique");
INSERT INTO person values(3,"Rosheen","Naeem");
INSERT INTO person values(4,"Sohaib","Bari");
INSERT INTO person values(5,"Haleema","Sadia");
INSERT INTO person values(6,"Khadija","Kamran");
INSERT INTO person values(7,"Maheer","Farooq");
INSERT INTO person values(8,"Mohammad","Qaiser");
INSERT INTO person values(9,"Hamza","Khurshid");
INSERT INTO person values(10,"Nadir","Ali");

INSERT INTO personaddress values(1,"Dubai");
INSERT INTO personaddress values(1,"Islamabad");
INSERT INTO personaddress values(2,"AbuDhabi");
INSERT INTO personaddress values(2,"Islamabad");
INSERT INTO personaddress values(3,"Faislabad");
INSERT INTO personaddress values(3,"Islamabad");
INSERT INTO personaddress values(4,"Saudi Arab");
INSERT INTO personaddress values(4,"Islamabad");
INSERT INTO personaddress values(5,"Kashmir");
INSERT INTO personaddress values(5,"Islamabad");
INSERT INTO personaddress values(6,"Lahore");
INSERT INTO personaddress values(6,"Islamabad");
INSERT INTO personaddress values(7,"Kashmir");
INSERT INTO personaddress values(7,"Islamabad");
INSERT INTO personaddress values(8,"Lahore");
INSERT INTO personaddress values(8,"Islamabad");
INSERT INTO personaddress values(9,"Bahawalpur");
INSERT INTO personaddress values(9,"Islamabad");
INSERT INTO personaddress values(10,"Sialkot");
INSERT INTO personaddress values(10,"Islamabad");

INSERT INTO employee values(1,1000,8,1);
INSERT INTO employee values(2,1000,8,2);
INSERT INTO employee values(3,1000,8,2);
INSERT INTO employee values(4,1000,8,2);
INSERT INTO employee values(5,1000,8,1);
INSERT INTO employee values(6,1000,8,1);
INSERT INTO employee values(7,1000,8,1);
INSERT INTO employee values(8,1000,8,2);
INSERT INTO employee values(9,1000,8,2);
INSERT INTO employee values(10,1000,8,2);

INSERT INTO CUSTOMER values(3,10000,1);
INSERT INTO CUSTOMER values(2,9000,2);
INSERT INTO CUSTOMER values(4,1000,3);
INSERT INTO CUSTOMER values(6,0,4);
INSERT INTO CUSTOMER values(3,10000,5);
INSERT INTO CUSTOMER values(2,9000,6);
INSERT INTO CUSTOMER values(4,1000,7);
INSERT INTO CUSTOMER values(6,0,8);
INSERT INTO CUSTOMER values(3,10000,9);
INSERT INTO CUSTOMER values(2,9000,10);


INSERT INTO manager VALUES(6,"Khadija");
INSERT INTO manager VALUES(9,"Hamza");


INSERT INTO sales_person values(2,1000,5,6);
INSERT INTO sales_person VALUES(3,1500,7,6);
INSERT INTO sales_person VALUES(4,2000,8,9);
insert into sales_person values(3,1500,10,9);

insert into cars values(21,2014,1500000,"lamborginicars","manual",1,2,3);
insert into cars values(22,2012,2000000,"Bugatti Veyron","manual",2,2,6);
insert into cars values(23,2015,3000000,"Rolls Royce","manual",2,4,7);

insert into cars_specs values(21,450,6000,"bugatti","v12",320);
insert into cars_specs values (22,650,7000,"bugatti","v12",360);
insert into cars_specs values(23,450,5000,"bugatti","v12",320);

insert into supplier values (1,"John","Italy",2000);
insert into suppliercontact values(1,8836623,"italy");
insert into cars_supplied values(1,21);
insert into cars_supplied values(1,22);
insert into cars_supplied values(1,23);




insert into DEALSONWHEELS.credit_card Values('hbl', '4406');






insert into DEALSONWHEELS.login Values('rosheen', '1234', '32143');
