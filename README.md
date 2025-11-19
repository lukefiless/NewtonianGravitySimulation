# Newtonian Gravity Simulation (Unity)

A **real-time N-body gravity simulation** built with **Unity** and **C#**, modeling realistic orbital mechanics based on **Newton’s Law of Universal Gravitation**.  
The project visualizes the interactions of celestial bodies — planets, stars, and moons — in a dynamic universe governed by physics.

---

## Description

**Newtonian Gravity Simulation** is an educational and visual physics sandbox demonstrating how gravitational forces govern motion in space.  
Each celestial body attracts others using Newton’s law of gravitation, resulting in realistic orbital behavior.  
The system supports **multiple interacting bodies (N-body simulation)**, adjustable parameters, and real-time debugging tools.

Designed for **learning, research, and experimentation**, it allows users to explore the chaotic and fascinating nature of gravitational systems.

---

## Features

-  **N-Body Physics Engine**  
  - Simulates multiple celestial bodies influencing each other with gravitational forces.
  - Adjustable gravitational constant and time scaling.

-  **Celestial Body System**
  - Supports planets, moons, stars, and custom mass objects.
  - Each object’s position, mass, and velocity define its orbital behavior.

-  **Orbit Visualization & Debug Tools**
  - Real-time orbit path rendering in the editor.
  - Custom inspector windows for debugging orbits and trajectories.

-  **Performance Optimizations**
  - Efficient calculation of gravitational interactions.
  - Frame-independent physics updates.

-  **Modular C# Architecture**
  - Separate scripts for physics (`NBodySimulation`, `GravityObject`, `Universe`) and visuals (`OrbitDebugDisplay`).

-  **Editor Tools**
  - Custom editors for planet setup and orbit debugging.
  - Easily create, visualize, and fine-tune planetary systems inside the Unity Editor.

---

## Technology Stack

| Category | Technology | Purpose |
|-----------|-------------|----------|
| **Engine** | Unity (2022+) | Game engine for physics and rendering |
| **Language** | C# | Simulation logic and component scripting |
| **Core Scripts** | `NBodySimulation`, `Universe`, `CelestialBody`, `GravityObject` | Handle gravitational interactions |
| **Editor Tools** | Custom Unity Editors | Debugging, visualization, and parameter tuning |
| **Input System** | Unity Input System | Optional player or camera control |
| **Physics Model** | Newtonian Mechanics | Governs movement and interaction between bodies |

---

## Core Simulation Overview

The simulation calculates the gravitational force between all pairs of bodies:

\[
F = G \cdot \frac{m_1 m_2}{r^2}
\]

Each body’s velocity and position are updated per frame:

```csharp
Vector3 direction = otherBody.Position - this.Position;
float distance = direction.magnitude;
float forceMagnitude = G * (this.mass * otherBody.mass) / (distance * distance);
Vector3 acceleration = direction.normalized * (forceMagnitude / this.mass);
velocity += acceleration * Time.deltaTime;
position += velocity * Time.deltaTime;
```

🧩 **Key Scripts Explained**

| **Script** | **Description** |
|-------------|-----------------|
| `CelestialBody.cs` | Defines physical properties like mass, position, and velocity. |
| `GravityObject.cs` | Encapsulates gravitational attraction logic. |
| `NBodySimulation.cs` | Core loop calculating forces between all bodies. |
| `Universe.cs` | Maintains the list of all active celestial bodies and updates them. |
| `OrbitDebugDisplay.cs` | Draws trajectory paths using Gizmos for visual debugging. |
| `GravityBodyEditor.cs` | Adds custom inspector controls for tuning simulation in the Unity Editor. |
| `OrbitDebugEditor.cs` | Provides orbit visualization tools inside the editor. |

---

🚀 **How to Run the Simulation**

**1️⃣ Clone the Repository**
```
git clone https://github.com/yourusername/NewtonianGravitySimulation.git
```


**2️⃣ Open in Unity**
- Open **Unity Hub**.  
- Click **“Add Project”** → select the project folder.

**3️⃣ Load the Demo Scene**
- Open:  
```
Assets/Scenes/Test.unity
```


**4️⃣ Play the Simulation**
- Click ▶️ in the Unity Editor to start the simulation.  
- Adjust object properties in the **Inspector** to modify mass, velocity, or initial position.

**5️⃣ (Optional)**
- Enable orbit visualization in the Scene view by toggling **Orbit Debug Display** in the Inspector.
