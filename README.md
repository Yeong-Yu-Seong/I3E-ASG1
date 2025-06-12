# I3E Assignment 1 - Warehouse Escape

## Scenario  
You are trapped in a mysterious warehouse and must complete a series of challenges to escape. As you progress through each area, you’ll solve puzzles, collect key items, and avoid obstacles. Your final goal: reach the boat and get out!

---

## 🎮 Controls
- `WASD` – Move  
- `E` – Interact

---

## 🧩 Game Objectives Breakdown

### 🔹 First Area – Storage Room  
- Objective: Push **3 boxes** into the green zone.  
- Reward: A **key card** spawns after completing the objective.  
- Use the key card on the **left door** beside the poster to exit.

### 🔹 Second Area – Server Room & Obstacle Course  
- Objective: Collect **6 wires** scattered across different rooms:
  - 1 in the server room  
  - 2 in the corridor  
  - 3 in the obstacle course room (1 below the obstacle course, 2 on it)  
- Hazards:
  - Touching a **red wire** deals 10 damage  
  - Falling into **toxic liquid** causes instant death and respawns you  
- Reward: A **key card** appears in the server room to unlock the **power room**

### 🔹 Third Area – Power Room  
- Objective: Insert **3 fuses** into the correct fuse slots.  
- Details:
  - Each fuse and slot is **color-coded**: Red, Yellow, Green  
  - You can only carry **one fuse at a time**  
  - If a fuse is placed incorrectly:
    - It disappears from your inventory  
    - It respawns in its original location  
    - An **error message** appears  
- **Fuse Locations**:
  - Red Fuse: Front-left corner of the room  
  - Yellow Fuse: Back-right corner of the room  
  - Green Fuse: Front-right corner near the door  
- Reward: The **dock door** opens

### 🔹 Fourth Area – Dock & Escape  
- Objective: Collect **3 planks** to build a platform to the escape boat
- Locations:
  - 1 on each side of the dock (between cargo stacks)  
  - 1 near the door you entered from  
- Mechanics:
  - Each plank adds a piece of platform  
  - Falling into the water respawns you on the dock  
- Reward: Reaching the boat shows the **end screen** with your **score**

---

## ⭐ Collectibles
There are **6 hidden collectibles**, each worth **1 point**. These are **small, spinning items** distinct from regular interactables.

**Locations**:
- Storage Room  
- Server Room  
- Obstacle Course Room  
- Power Room  
- Dock  
- Right before the exit

---

## 🖥️ System Requirements
- Platform: PC (Windows)  
- Input: Keyboard & Mouse  
- Engine: Built in **Unity**  
- Recommended: Mid-spec PC with Unity-supported GPU  

---

## 🐞 Known Bugs / Limitations
- Occasionally, the error message for incorrect fuse placement may **not display for all fuse slots**.
- Only one item can be carried at a time (by design)  
- Respawn logic may not work at times
- Right door cannot be interacted on

---

## 🧠 Puzzle Answer Key
### Fuse Puzzle Solution:
- Red Fuse → Red Slot  
- Yellow Fuse → Yellow Slot  
- Green Fuse → Green Slot  

---

## 🖌️ Textures & Visuals
All textures created by me were made using **Canva**:

1. [Texture 1](https://www.canva.com/design/DAGoVshefQQ/rUocxPdMr0U56Rsq4VXuDw/edit?utm_content=DAGoVshefQQ&utm_campaign=designshare&utm_medium=link2&utm_source=sharebutton)  
2. [Texture 2](https://www.canva.com/design/DAGoUtq0AT8/o6HveceY5Fdf7IMS8Ax0LQ/edit?utm_content=DAGoUtq0AT8&utm_campaign=designshare&utm_medium=link2&utm_source=sharebutton)  
3. [Texture 3](https://www.canva.com/design/DAGoU91oaA0/aii1kOZkqQF5Yg_f4whRPw/edit?utm_content=DAGoU91oaA0&utm_campaign=designshare&utm_medium=link2&utm_source=sharebutton)

---

## 🙏 Credits
- **ChatGPT (OpenAI)** – Assisted in:
  - Fixing bugs  
  - Writing and structuring code (especially for fuse logic, dock mechanics, and UI feedback)  
  - Designing error message systems and game manager logic  
  - Creating visual feedback indicators  
  - Helping with some of the Canva textures

- **Pixabay** – Source for **free sound effects and background music**  
  - [https://pixabay.com/](https://pixabay.com/)

---

Thank you for playing **Warehouse Escape**!