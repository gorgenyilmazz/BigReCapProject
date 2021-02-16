CREATE TABLE "Users" (
"Id" int PRIMARY KEY IDENTITY(1,1) NOT NULL,
"FirstName" nvarchar (30) NOT NULL,
"LastName" nvarchar(30) NULL,
"Email" nvarchar(80) NOT NULL,
"Password"  varbinary(150) not null
)
CREATE TABLE "Customers" (
"UserId" int FOREIGN KEY REFERENCES Users("Id") NOT NULL,
"CompanyName" nvarchar(100) NULL
)
CREATE TABLE "Rentals" (
"Id" int PRIMARY KEY IDENTITY(1,1) NOT NULL,
"CarId" int FOREIGN KEY REFERENCES Cars("Id") NOT NULL,
"CustomerId" int FOREIGN KEY REFERENCES Customers("UserId") NOT NUll,
"RentDate" datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
"ReturnDate" datetime NULL DEFAULT NULL
)