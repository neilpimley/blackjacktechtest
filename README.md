# BlackJack Dev Tech Test

- Simple Domain Driven Design approach followed
- Logic baked into  model in **BlackJackGame.cs** which is the central source of truth and can't be in an invalid state
- Services built around model to change it's state
- InMemory repository used for data storage. 
- In a real implementation a NoSql database would be used for the games and a Relational Database used for the Players
- Players would be in their own bounded context and have their own microservices and model deployed seperately from the game
- Tests for controllers, services and model. In a real implementation integration and BDD tests using Specflow would be added
- A real implementation would also have logging in the services and providers to debug any issues

## Instructions to test

[Postman Collection to test API](https://raw.githubusercontent.com/neilpimley/blackjacktechtest/master/Chambers.Partners.WebApi.Tests/Chambers.postman_collection.json)

There are 2 players in the system with Id of 1 and 2

Start a Game
http://localhost:63191/api/games/start
```
{ 
	"playerid":1 
}
```
This will return a GameId to use for Stick and Hit and also the players hand

Hit
http://localhost:63191/api/games/hit/1 (where GameId is 1)
```
{ 
	"playerid":1 
}
```
This returns a game object with the players new hand and a winner if the player's score exceeds 21.

Stick
http://localhost:63191/api/games/stick/1 (where GameId is 1)
```
{ 
	"playerid":1 
}
```
This returns a game object with the players hand and a winner.
