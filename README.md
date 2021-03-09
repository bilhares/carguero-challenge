# carguero-challenge

## Api developed for a Challenge

## How to run
- Create a Database With name 'carguero'
- Open folder '\carguero-challenge\AddressRegister.Infra' and start cmd
- Run the command:
```bash
dotnet ef database update --startup-project ..\AddressRegister.Api
```
- Run the project 
```bash
dotnet run --project ..\AddressRegister.Api
 ```

## Endpoints

### Register user
- POST
- Url
http://localhost:5000/api/user
- Data
```
{
    "username": "string"
}
```
### Get User by username
- GET
- Url localhost:5000/api/user/GetByUsername?username=string
- Data
```
{
    "username": "string",
    "id": number
}
```