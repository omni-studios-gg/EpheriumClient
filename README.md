# MMORPG Server Architecture Overview

This document outlines the server architecture for our custom-built MMORPG using **uMMORPG** as the foundation. The architecture is designed for modularity, scalability, and maintainability with a clean separation of concerns between core game logic, authentication, and microservices.

## 🧱 Core Components

### 1. 🗝️ AuthServer
Handles all authentication-related tasks.

- **Responsibilities:**
  - Account registration & login
  - Password verification (secure hashing)
  - IP address logging
  - Authentication token generation
  - Realm/server selection logic
- **Tech Stack:**
  - ASP.NET Core Web API
  - C# 9 / .NET 9
  - SQL (SQLite or MySQL)
- **Security:**
  - Rate limiting & brute-force protection
  - Token-based session auth
  - IP tracking & blacklist logic

### 2. 🌍 WorldServer
A separate dedicated server responsible for hosting the actual game world.

- **Responsibilities:**
  - Handles movement, combat, questing, NPCs
  - Manages characters, items, spells, and regions
  - Syncs persistent player data to Character DB
  - Maintains individual shard logic
- **Tech Stack:**
  - Unity (uMMORPG)
  - Mirror Networking
  - Custom C# game logic
- **Sharding Model:**
  - Multiple WorldServer instances per region or realm
  - Each WorldServer is a standalone Unity instance

## 🔌 Microservices

### 3. 💬 Chat Service
A real-time communication layer decoupled from the game logic.

- **Responsibilities:**
  - Global chat, local chat, whispers, party/guild chats
  - Mute/kick/ban features for moderation
  - Channel subscriptions per player
- **Tech Stack:**
  - FastAPI (Python) or Node.js
  - Redis pub/sub for scalability
  - WebSocket or Socket.IO for communication

### 4. 📦 Inventory & Auction Service *(Planned)*
Scalable item storage, trade, and auction house logic.

- **Future Responsibilities:**
  - Secure cross-server inventory transactions
  - Cross-realm auction listings
  - Item lock and logging for trades
- **Considerations:**
  - REST API layer between game client and service
  - Centralized item database

### 5. 🛡️ Moderation/Logging Service
Tracks and audits player behavior.

- **Responsibilities:**
  - Logs chat, movement, trade, and combat logs
  - Supports report handling & GM tools
  - Exposes audit dashboard for admin use
- **Tech Stack:**
  - PostgreSQL for log storage
  - Web dashboard with authentication
  - Discord webhook integration for alerts

## 🗃️ Databases

| Name           | Purpose                         |
|----------------|----------------------------------|
| AuthDB         | Stores account/login credentials |
| CharacterDB    | Character progress, inventory, stats |
| WorldDB        | Persistent world state, NPCs, quests |
| LogDB          | Logs of all server actions and player activity |

## 📡 Communication Flow

```text
Client → AuthServer → Token/Session → WorldServer
           ↓
         Microservices (Chat, etc.)