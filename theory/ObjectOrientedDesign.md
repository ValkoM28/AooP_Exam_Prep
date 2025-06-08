
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

**Definition**: A class should have only one reason to change, meaning it should have only one job or responsibility.

**Why**: Mixing responsibilities makes classes harder to maintain, test, and reuse.

**Example**:
```java
// ❌ Violates SRP
class Report {
    String content;
    void generate() { /* logic to generate report */ }
    void print() { /* logic to print report */ }
    void saveToFile() { /* logic to save report */ }
}

// ✅ Follows SRP
class Report {
    String content;
}

class ReportGenerator {
    void generate(Report r) { /* generation logic */ }
}

class ReportPrinter {
    void print(Report r) { /* printing logic */ }
}

class ReportSaver {
    void saveToFile(Report r) { /* saving logic */ }
}
```

---

### 2. **OCP – Open/Closed Principle**

**Definition**: Software entities (classes, modules, functions) should be **open for extension** but **closed for modification**.

**Why**: Encourages you to extend behaviors without changing existing code, reducing the risk of introducing bugs.

**Example**:
```java
// ❌ Violates OCP
class NotificationService {
    void send(String type) {
        if (type.equals("EMAIL")) { /* send email */ }
        else if (type.equals("SMS")) { /* send SMS */ }
    }
}

// ✅ Follows OCP using polymorphism
interface Notifier {
    void send();
}

class EmailNotifier implements Notifier {
    public void send() { /* send email */ }
}

class SMSNotifier implements Notifier {
    public void send() { /* send SMS */ }
}

class NotificationService {
    private Notifier notifier;
    public NotificationService(Notifier notifier) {
        this.notifier = notifier;
    }
    public void sendNotification() {
        notifier.send();
    }
}
```

---

### 3. **LSP – Liskov Substitution Principle**

**Definition**: Subtypes must be substitutable for their base types without altering the correctness of the program.

**Why**: Ensures that a subclass can stand in for a superclass without causing unexpected behavior.

**Example**:
```java
// ❌ Violates LSP
class Bird {
    void fly() {}
}

class Ostrich extends Bird {
    void fly() { throw new UnsupportedOperationException(); }
}

// ✅ Follows LSP
interface Bird { void eat(); }

interface FlyingBird extends Bird { void fly(); }

class Sparrow implements FlyingBird {
    public void eat() {}
    public void fly() {}
}

class Ostrich implements Bird {
    public void eat() {}
}
```

---

### 4. **ISP – Interface Segregation Principle**

**Definition**: No client should be forced to depend on methods it does not use.

**Why**: Fat interfaces force classes to implement unnecessary methods. Smaller interfaces lead to better code decoupling.

**Example**:
```java
// ❌ Violates ISP
interface Worker {
    void work();
    void eat();
}

class Robot implements Worker {
    public void work() {}
    public void eat() { /* doesn't make sense for robots */ }
}

// ✅ Follows ISP
interface Workable { void work(); }
interface Eatable { void eat(); }

class Human implements Workable, Eatable {
    public void work() {}
    public void eat() {}
}

class Robot implements Workable {
    public void work() {}
}
```

---

### 5. **DIP – Dependency Inversion Principle**

**Definition**: High-level modules should not depend on low-level modules. Both should depend on **abstractions**. Abstractions should not depend on details; details should depend on abstractions.

**Why**: Promotes loose coupling and enhances testability.

**Example**:
```java
// ❌ Violates DIP
class LightBulb {
    void turnOn() {}
    void turnOff() {}
}

class Switch {
    private LightBulb bulb;
    public Switch() {
        this.bulb = new LightBulb();
    }
    public void operate() {
        bulb.turnOn();
    }
}

// ✅ Follows DIP
interface Switchable {
    void turnOn();
    void turnOff();
}

class LightBulb implements Switchable {
    public void turnOn() {}
    public void turnOff() {}
}

class Switch {
    private Switchable device;
    public Switch(Switchable device) {
        this.device = device;
    }
    public void operate() {
        device.turnOn();
    }
}
```

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
