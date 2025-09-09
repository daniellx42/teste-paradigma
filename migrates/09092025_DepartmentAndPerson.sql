CREATE TABLE Department (
    Id INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL
);

CREATE TABLE Person (
    Id INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Salary INT, -- armazenado em centavos (ex: 1000 = R$ 10,00), modo mais seguro de trabalhar com valores monetarios em geral, mas dependendo do caso poderiamos usar FLOAT ou DECIMAL
    DepartmentId INT,
    FOREIGN KEY (DepartmentId) REFERENCES Department(Id)
);

INSERT INTO Department (Id, Name) VALUES
(1, 'TI'),
(2, 'Vendas');

INSERT INTO Person (Id, Name, Salary, DepartmentId) VALUES
(1, 'Joe', 70000, 1),
(2, 'Henry', 80000, 2),
(3, 'Sam', 60000, 2),
(4, 'Max', 90000, 1);