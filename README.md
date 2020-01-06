# BlackJack Dev Tech Test

- Simple Domain Driven Design approach followed
- Logic baked into  model in **BlackJackGame.cs** which is the central source of truth and can't be in an invalid state
- Services built around model to change it's state
- InMemory repository used for data storage. 
- In a real implementation a NoSql database would be used for the games and a Relational Database used for the Players
- Players would be in their own bounded context and have their own microservices and model deployed seperately from the game
- Tests for controllers, services and model. In a real implementation integration and BDD tests using Specflow would be added

## Instructions

[Postman Collection to test API](https://raw.githubusercontent.com/neilpimley/blackjacktechtest/master/Chambers.Partners.WebApi.Tests/Chambers.postman_collection.json)

Start a Game
http://localhost:63191/api/games/start
```
{ 
	"playerid":1 
}
```
This will return a GameId to use for Stick and Hit

Hit
http://localhost:63191/api/games/hit/1 (where GameId is 1)
```
{ 
	"playerid":1 
}
```
Stick
http://localhost:63191/api/games/stick/1 (where GameId is 1)
```
{ 
	"playerid":1 
}
```
