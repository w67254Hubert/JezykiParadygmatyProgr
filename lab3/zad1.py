class Employee:
    def __init__(self, name,age,salary):
        self.name=name
        self.age=age
        self.salary=salary

    def getDetails(self):
        return f"Name: {self.name}, Age: {self.age}, Salary: {self.salary}"


class EmployeesManager:
    def __init__(self):
        self.employees = []

    def addEmployee(self, employee):
        self.employees.append(employee)

    def listEmployees(self):
        for employee in self.employees:
            print(employee.getDetails())

    def removeEmployeesEge(self, min_age, max_age):
        ageemployees=[]
        for emp in self.employees:
            if not min_age <= emp.age <= max_age:
                ageemployees.append(emp)
        self.employees = ageemployees

    def findEmployeeByName(self, name):
        for employee in self.employees:
            if employee.name == name:
                return employee
        return None

    def updateSalaryByName(self, name, new_salary):
        employee = self.findEmployeeByName(name)
        if employee:
            employee.salary = new_salary
            print(f"Updated salary for {employee.name}")
        else:
            print(f"Employee named {name} not found")

class FrontendManager:
    def __init__(self):
        self.manager = EmployeesManager()

    def addNewEmployee(self, name, age, salary):
        new_employee = Employee(name, age, salary)
        self.manager.addEmployee(new_employee)

    def displayAllEmployees(self):
        self.manager.listEmployees()

    def removeEmployeesInAgeRange(self, min_age, max_age):
        self.manager.removeEmployeesEge(min_age, max_age)

    def updateEmployeeSalary(self, name, new_salary):
        self.manager.updateSalaryByName(name, new_salary)

# Przykład użycia:
frontend = FrontendManager()
frontend.addNewEmployee("John Doe", 30, 50000)
frontend.addNewEmployee("Jane Smith", 45, 60000)
frontend.displayAllEmployees()
frontend.updateEmployeeSalary("John Doe", 55000)
frontend.displayAllEmployees()
frontend.removeEmployeesInAgeRange(40, 50)
frontend.displayAllEmployees()
