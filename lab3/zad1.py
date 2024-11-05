class Employee:
    def __init__(self, name,age,salary):
        self.name=name
        self.age=age
        self.salary=salary

    def get_details(self):
        return f"Name: {self.name}, Age: {self.age}, Salary: {self.salary}"


class EmployeesManager:
    def __init__(self):
        self.employees = []

    def add_employee(self, employee):
        self.employees.append(employee)

    def list_employees(self):
        for employee in self.employees:
            print(employee.get_details())

    def remove_employees_by_age_range(self, min_age, max_age):
        ageemployees=[]
        for emp in self.employees:
            if not min_age <= emp.age <= max_age:
                ageemployees.append(emp)
        self.employees = ageemployees

    def find_employee_by_name(self, name):
        for employee in self.employees:
            if employee.name == name:
                return employee
        return None

    def update_salary_by_name(self, name, new_salary):
        employee = self.find_employee_by_name(name)
        if employee:
            employee.salary = new_salary
            print(f"Updated salary for {employee.name}")
        else:
            print(f"Employee named {name} not found")

class FrontendManager:
    def __init__(self):
        self.manager = EmployeesManager()

    def add_new_employee(self, name, age, salary):
        new_employee = Employee(name, age, salary)
        self.manager.add_employee(new_employee)

    def display_all_employees(self):
        self.manager.list_employees()

    def remove_employees_in_age_range(self, min_age, max_age):
        self.manager.remove_employees_by_age_range(min_age, max_age)

    def update_employee_salary(self, name, new_salary):
        self.manager.update_salary_by_name(name, new_salary)

# Przykład użycia:
frontend = FrontendManager()
frontend.add_new_employee("John Doe", 30, 50000)
frontend.add_new_employee("Jane Smith", 45, 60000)
frontend.display_all_employees()
frontend.update_employee_salary("John Doe", 55000)
frontend.display_all_employees()
frontend.remove_employees_in_age_range(40, 50)
frontend.display_all_employees()
