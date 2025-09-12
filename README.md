# Turing Machine Simulator 🖥️🤖

A modular **Turing Machine (TM) simulator** written in C#.  
Simulate the execution of any Turing machine with **standard input symbols**.  
Ideal for learning, testing TM algorithms, and visualizing step-by-step execution.

---

## Table of Contents

- [Features](#-features)  
- [Project Structure](#-project-structure)  
- [Getting Started](#-getting-started)  
- [Usage](#-usage)
- [Example](#-example)
- [Contributing](#-contributing)
- [License](LICENCE)  

---

## 🌟 Features

- Fully modular design with:
  - **Tape** (manages head movement and tape content)  
  - **TuringMachine** (core logic, halting and acceptance check)  
  - **Transition** (state change rules)  
- Supports **any input string**
- Tracks **head position, current state, steps**, and halting status  
- Configurable **maximum step limit** to prevent infinite loops  
- Clean console output for visualization and debugging  

---

## 📂 Project Structure

turing-machine-simulator/
│
├── src/
│   ├── Inputs/
│   │   └── MachineInputs.cs
│   │
│   ├── Models/
│   │   ├── MoveDirection.cs
│   │   ├── Tape.cs
│   │   └── Transition.cs
│   │
│   ├── Services/
│   │   └── TuringMachine.cs
│   │
│   ├── Program.cs
│   └── TuringMachineSimulator.csproj
│
├── .gitignore
├── LICENSE
└── README.md


**Design Notes:**

| Class | Responsibility |
|-------|----------------|
| `Tape.cs` | Encapsulates tape content, head movement, and blank symbol logic |
| `TuringMachine.cs` | Runs the machine, executes steps, checks halting and acceptance |
| `Transition.cs` | Represents a single transition (current state, read/write symbol, move, next state) |
| `Program.cs` | Entry point with hardcoded Turing machine and input tape |

---

## ⚡ Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) or later  
- IDE (VS Code, Visual Studio) or terminal

### Build & Run

```bash
cd src
dotnet build
dotnet run
```

---

## 📝 Usage

1. Define Turing machine states and transitions in `MachineInputs.cs`.

2. Set the input tape (any string of symbols, e.g., "aaaabbbb")

3. Call:
```var result = machine.Run(maxSteps: 10000);```

4.  Run() returns a tuple:

| Field | Description |
|-------|----------------|
| finalTape | Final tape content after execution |
| finalState | Current state after execution |
| halted | True if machine halted before reaching max steps |
| accepted | True if machine reached an accepting state |
| steps | Number of steps executed |

---

## 🎯 Example

Language : $L = \{a^n b^n : n \ge 1\}$

Input tape: "aaaabbbb"

```
******************************
Final tape (trimmed): Tape contents: xxxxyyyy_
Head at: 7 (shown with ^ below)
xxxxyyyy_
       ^
Blank symbol: '_'
Halted: True
Accepted: True
Final state: q_accept
Steps: 41
******************************
```

## 🤝 Contributing

1. Fork the repository  
2. Create a feature branch  
   ```bash
   git checkout -b feature-name
    ```

3. Commit changes with clear messages
4. Push to your branch and create a Pull Request
