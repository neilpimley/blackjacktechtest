# BlackJack Dev Tech Test

- Simple Domain Driven Design approach followed
- Logic baked into  model in **BlackJackGame.cs** which is the central source of truth and can't be in an invalid state
- Services built around model to change it's state
- InMemory repository used for data storage. 
- In a real implementation a NoSql database would be used for the games and a Relational Database used for the Players
- Players would be in their own bounded context and have their own microservices and model deployed seperately from the game
- Tests for controllers, services and model. In a real implementation integration and BDD tests using Specflow would be added
