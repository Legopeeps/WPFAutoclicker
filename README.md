# WPF AutoClicker

A simple Windows desktop auto-clicker application built using **C# and WPF**.

The application uses the Windows `user32.dll` API to simulate left mouse clicks at a user-defined interval.

## Features

- Start and stop automatic mouse clicking
- Adjustable click delay in milliseconds
- Simple WPF user interface
- Uses native Windows mouse events
- Lightweight and easy to modify

## Screenshots

_Will be added at a later date..._

## How It Works

The application uses the Windows API function:

```csharp
mouse_event()
```

from:

```csharp
user32.dll
```

to simulate mouse button presses.

A click consists of two events:

```csharp
mouse_event(0x0002, 0, 0, 0, UIntPtr.Zero); // Left mouse button down
mouse_event(0x0004, 0, 0, 0, UIntPtr.Zero); // Left mouse button up
```

The delay between clicks is controlled by the value entered in the **Delay (ms)** textbox.

Example:

```
Delay: 1000
```

will perform one click every second.

---

## Usage

1. Launch the application.
2. Enter the desired click delay in milliseconds. The equivalence in clicks-per-second will be displayed
3. Press **Start Autoclicker**.
4. The application will begin generating left mouse clicks.
5. Press **Stop Autoclicker** to stop.
