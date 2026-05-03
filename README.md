## Getting Started!
### Clone the Repository

```bash
git clone https://github.com/yourusername/minesweeper.git
cd minesweeper
```

---

### Building the Project

```bash
dotnet build
```

This will restore dependencies and compile the project.

---

### Running the Game

```bash
dotnet run --project Minesweeper.Core
```

The game will start in the console. Follow the console prompts to:

1. Choose board size (`Small`, `Medium`, `Large`)
2. Start a new game or load a saved game
3. Reveal cells or place flags using coordinates
The format and all further instructions should be properly explained by the console.
If you wish to quit at any point in the game, simply type q, and it will take you back to the main menu
