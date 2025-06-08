
# 🧠 Object-Oriented Analysis & Design Study Guide

---

## 🧱 Object-Oriented Principles

### 🔒 Encapsulation
- Bundles data and methods operating on that data into a single unit (class).
- Hides internal state using access modifiers (e.g., `private`, `protected`).
- Provides controlled access via getters/setters.

### 👨‍👩‍👧‍👦 Inheritance
- Mechanism for creating new classes from existing ones.
- Promotes code reuse by inheriting attributes and methods.
- Enables polymorphism.
```java
class Animal {
    void makeSound() { System.out.println("Sound"); }
}

class Dog extends Animal {
    void makeSound() { System.out.println("Bark"); }
}
```

### 🌫 Abstraction
- Hides complex implementation details.
- Shows only the necessary features to the user.
- Achieved through abstract classes and interfaces.

### 🌀 Polymorphism
- Ability of different objects to respond to the same method in different ways.
- Types:
  - Compile-time (method overloading)
  - Runtime (method overriding)

---

## 🧩 Composition & Aggregation

### 🔧 Composition
- Strong relationship: "has-a" and *owns*.
- If the container is destroyed, so are the components.
```java
class Engine {}
class Car {
    private Engine engine = new Engine(); // Composition
}
```

### 🧲 Aggregation
- Weak relationship: "has-a" but *does not own*.
- Components can exist independently.
```java
class Department {}
class University {
    private List<Department> departments; // Aggregation
}
```

---

## 🧭 SOLID Principles

### 1. **SRP – Single Responsibility Principle**
- A class should have only one reason to change.
- Promotes high cohesion.

### 2. **OCP – Open/Closed Principle**
- Software entities should be open for extension but closed for modification.
- Use interfaces and abstract classes to extend behavior.

### 3. **LSP – Liskov Substitution Principle**
- Subtypes must be substitutable for their base types.
- No surprises when replacing a superclass object with a subclass.

### 4. **ISP – Interface Segregation Principle**
- No client should be forced to depend on methods it does not use.
- Favor many small, specific interfaces.

### 5. **DIP – Dependency Inversion Principle**
- High-level modules should not depend on low-level modules.
- Both should depend on abstractions.
- Use interfaces and dependency injection.

---

## 🎭 Design Patterns

### 🏛 Facade Pattern
- Provides a simplified interface to a complex subsystem.
```java
class ComputerFacade {
    void start() {
        // hides complex startup steps
    }
}
```

### 👤 Singleton Pattern
- Ensures only one instance of a class exists and provides a global access point.
```java
class Singleton {
    private static Singleton instance;
    private Singleton() {}
    public static Singleton getInstance() {
        if (instance == null) instance = new Singleton();
        return instance;
    }
}
```

### 🧠 Strategy Pattern
- Allows selecting an algorithm's behavior at runtime.
- Encapsulates algorithms in separate classes.
```java
interface Strategy {
    void execute();
}

class Context {
    private Strategy strategy;
    void setStrategy(Strategy s) { strategy = s; }
    void run() { strategy.execute(); }
}
```

### 🕹 Command Pattern
- Encapsulates a request as an object, thereby allowing for parameterization and queuing.
```java
interface Command {
    void execute();
}

class LightOnCommand implements Command {
    void execute() { /* turn on light */ }
}
```

### 👀 Observer Pattern
- Allows a subject to notify a list of observers automatically of any state changes.
```java
interface Observer { void update(); }

class Subject {
    private List<Observer> observers;
    void notifyObservers() {
        for (Observer o : observers) o.update();
    }
}
```

---

## 💉 Dependency Injection (DI)

- A design pattern that allows removing hard-coded dependencies.
- Objects receive their dependencies from an external source (inversion of control).

### Types:
- Constructor Injection
- Setter Injection
- Interface Injection

### Example (Constructor Injection):
```java
class Service {}
class Client {
    private Service service;
    public Client(Service service) {
        this.service = service;
    }
}
```
