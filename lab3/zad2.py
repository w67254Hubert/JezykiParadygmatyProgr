# Nie działą!!!!
#napisane na szybko przez chat

class Employee:
    def __init__(self, name, age, salary):
        self.name = self.validateName(name)
        self.age = self.validateAge(age)
        self.salary = self.validateSalary(salary)

    def validateName(self, name):
        if not isinstance(name, str) or not name.strip():
            raise ValueError("Invalid name")
        return name

    def validateAge(self, age):
        if not isinstance(age, int) or age < 0:
            raise ValueError("Invalid age")
        return age

    def validateSalary(self, salary):
        if not isinstance(salary, (int, float)) or salary < 0:
            raise ValueError("Invalid salary")
        return salary

    def getDetails(self):
        return f"Name: {self.name}, Age: {self.age}, Salary: {self.salary}"

import json

class EmployeesManager:
    def __init__(self):
        self.employees = []
        self.file_path = "employees.json"
        self.loadEmployeesFromFile()

    def addmployee(self, employee):
        self.employees.append(employee)
        self.saveEmployeesToFile()

    def listEmployees(self):
        for employee in self.employees:
            print(employee.getDetails())

    def removeEmployeesByAgeRange(self, min_age, max_age):
        ageemployees=[]
        for emp in self.employees:
            if not min_age <= emp.age <= max_age:
                ageemployees.append(emp)
        self.employees = ageemployees        
        self.saveEmployeesToFile()

    def findEmployeeByName(self, name):
        for employee in self.employees:
            if employee.name == name:
                return employee
        return None

    def updateSalaryByName(self, name, new_salary):
        employee = self.findEmployeeByName(name)
        if employee:
            employee.salary = new_salary
            self.saveEmployeesToFile()
            print(f"Updated salary for {employee.name}")
        else:
            print(f"Employee named {name} not found")

    def saveEmployeesToFile(self):
        with open(self.file_path, 'w') as file:
            json.dump([emp.__dict__ for emp in self.employees], file)

    def loadEmployeesFromFile(self):
        try:
            with open(self.file_path, 'r') as file:
                employees_data = json.load(file)
                self.employees = [Employee(**data) for data in employees_data]
        except FileNotFoundError:
            self.employees = []

class FrontendManager:
    def __init__(self):
        self.manager = EmployeesManager()
        self.admin_username = "admin"
        self.admin_password = "admin"
        self.logged_in = False

    def login(self, username, password):
        if username == self.admin_username and password == self.admin_password:
            self.logged_in = True
            print("Login successful")
        else:
            print("Invalid credentials")

    def ensureLoggedIn(self):
        if not self.logged_in:
            raise Exception("You must be logged in to perform this action")
    def addNewEmployee(self, name, age, salary):
        new_employee = Employee(name, age, salary)
        self.manager.addmployee(new_employee)

    def displayAllEmployees(self):
        self.manager.listEmployees()

    def removeEmployeesInAgeRange(self, min_age, max_age):
        self.manager.removeEmployeesByAgeRange(min_age, max_age)

    def updateEmployeeSalary(self, name, new_salary):
        self.manager.updateSalaryByName(name, new_salary)



frontend = FrontendManager()
frontend.login("admin", "admin")  # Logowanie do systemu
frontend.addNewEmployee("John Doe", 30, 50000)
frontend.addNewEmployee("Jane Smith", 45, 60000)
frontend.displayAllEmployees()
frontend.updateEmployeeSalary("John Doe", 55000)
frontend.displayAllEmployees()
frontend.removeEmployeesInAgeRange(40, 50)
frontend.displayAllEmployees()
