# Nie działą!!!!
#napisane na szybko przez chat

class Employee:
    def __init__(self, name, age, salary):
        self.name = self.validate_name(name)
        self.age = self.validate_age(age)
        self.salary = self.validate_salary(salary)

    def validate_name(self, name):
        if not isinstance(name, str) or not name.strip():
            raise ValueError("Invalid name")
        return name

    def validate_age(self, age):
        if not isinstance(age, int) or age < 0:
            raise ValueError("Invalid age")
        return age

    def validate_salary(self, salary):
        if not isinstance(salary, (int, float)) or salary < 0:
            raise ValueError("Invalid salary")
        return salary

    def get_details(self):
        return f"Name: {self.name}, Age: {self.age}, Salary: {self.salary}"

import json

class EmployeesManager:
    def __init__(self):
        self.employees = []
        self.file_path = "employees.json"
        self.load_employees_from_file()

    def add_employee(self, employee):
        self.employees.append(employee)
        self.save_employees_to_file()

    def list_employees(self):
        for employee in self.employees:
            print(employee.get_details())

    def remove_employees_by_age_range(self, min_age, max_age):
        self.employees = [emp for emp in self.employees if not (min_age <= emp.age <= max_age)]
        self.save_employees_to_file()

    def find_employee_by_name(self, name):
        for employee in self.employees:
            if employee.name == name:
                return employee
        return None

    def update_salary_by_name(self, name, new_salary):
        employee = self.find_employee_by_name(name)
        if employee:
            employee.salary = new_salary
            self.save_employees_to_file()
            print(f"Updated salary for {employee.name}")
        else:
            print(f"Employee named {name} not found")

    def save_employees_to_file(self):
        with open(self.file_path, 'w') as file:
            json.dump([emp.__dict__ for emp in self.employees], file)

    def load_employees_from_file(self):
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

    def ensure_logged_in(self):
        if not self.logged_in:
            raise Exception("You must be logged in to perform this action")
    def add_new_employee(self, name, age, salary):
        new_employee = Employee(name, age, salary)
        self.manager.add_employee(new_employee)

    def display_all_employees(self):
        self.manager.list_employees()

    def remove_employees_in_age_range(self, min_age, max_age):
        self.manager.remove_employees_by_age_range(min_age, max_age)

    def update_employee_salary(self, name, new_salary):
        self.manager.update_salary_by_name(name, new_salary)



frontend = FrontendManager()
frontend.login("admin", "admin")  # Logowanie do systemu
frontend.add_new_employee("John Doe", 30, 50000)
frontend.add_new_employee("Jane Smith", 45, 60000)
frontend.display_all_employees()
frontend.update_employee_salary("John Doe", 55000)
frontend.display_all_employees()
frontend.remove_employees_in_age_range(40, 50)
frontend.display_all_employees()
