const fs = require("fs");
const sqlite3 = require("sqlite3").verbose();

// carrega SQL da pasta migrates
const sqlScript = fs.readFileSync("../../migrates/09092025_DepartmentAndPerson.sql", "utf8");

const db = new sqlite3.Database(":memory:");

db.serialize(() => {
  db.exec(sqlScript);

  const query = `
    SELECT d.Name AS Department, p.Name AS Person, p.Salary
    FROM Person p
    JOIN Department d ON p.DepartmentId = d.Id
    WHERE p.Salary = (
        SELECT MAX(p2.Salary)
        FROM Person p2
        WHERE p2.DepartmentId = p.DepartmentId
    );
  `;

  db.each(query, (err, row) => {
    if (err) throw err;

    const salary = row.Salary / 100;

    const salaryFormatted = salary.toLocaleString("pt-BR", {
      style: "currency",
      currency: "BRL"
    });

    console.log(`${row.Person} ganhou o maior salario ${salaryFormatted} no departamento ${row.Department}`);
  });
});
