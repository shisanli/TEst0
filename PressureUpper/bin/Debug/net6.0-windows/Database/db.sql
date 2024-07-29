drop table if exists Doctor;
drop table if exists Patient;
drop table if exists TestRecord;
drop table if exists TestRecordItem;

create table Doctor(
	ID integer primary key AUTOINCREMENT not null,
	AccountNum text,
	Password text,
	Name text,
	Sex text,
	Department text,
	CreateTime DATETIME,
	OperationNum integer,
	IsAdmin integer,
	IsDeleted integer,
	Mark text
);
create table Patient(
	ID integer primary key AUTOINCREMENT not null,
	Name text,
	MedicalRecordNum text,
	Sex text,
	Weight real,
	Height real,
	Age integer,
	DoctorID integer,
	Doctor text,
	AnesthesiologistID integer,
	Anesthesiologist text,
	EnterTime DATETIME,
	Score real,
	MedicalHistory text,
	DrugAllergy text,
	DiagnosticResult text,
	OtherInformation text,
	IsDeleted integer,
	Mark text,
	foreign key (DoctorID) references Doctor(ID),
	foreign key (AnesthesiologistID) references Doctor(ID)
);
create table TestRecord(
	ID integer primary key AUTOINCREMENT not null,
	Name text,
	Weight real,
	Height real,
	Age integer,
	Sex text,
	MedicalRecordNum text,
	EnterTime DATETIME,
	OperationDate DATETIME,
	BegainTime DATETIME,
	EndTime DATETIME,
	OperationPart text,
	DoctorID integer,
	Doctor text,
	HardwareNumber integer,
	Left integer,
	Right integer,
	OnePath text,
	TwoPath text,
	ReportPath text,
	Mark text,
	foreign key (DoctorID) references Doctor(ID)
);
create table TestRecordItem(
	ID integer primary key AUTOINCREMENT not null,
	RecordID integer,
	RoundNum integer,
	Angle integer,
	Inside real,
	Outside real,
	RecordTime DATETIME,
	ResultantForce real,
	ForceDifference real,
	EvaluationIndex  text,
	Mark text,
	foreign key (RecordID) references TestRecord(ID)
);


