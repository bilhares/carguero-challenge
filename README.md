# carguero-challenge

## Api developed for a Challenge

## How to run
- Install EF Core CLI for .Net Core
```
 dotnet tool install --global dotnet-ef --version 3.0.0
```
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
    "username": string
}
```
### Get User by username
- GET
- Url http://localhost:5000/api/user/GetByUsername?username=string
- Response data
```
{
    "username": string,
    "id": number
}
```
### Register Address
- POST
- Url
http://localhost:5000/api/address
- Data
```
{
  "zipCode": string,
  "number": number,
  "city": string,
  "district": string,
  "state": string,
  "userId": number,
  "complement": string
}
```
### Get Address by username
- GET
- Url http://localhost:5000/api/address/GetByUsername?username=string
- Response data
```
[
    {
        "zipCode": string,
        "number": number,
        "city": string,
        "district": string,
        "state": string,
        "userId": number,
        "complement": string,
        "user": {
                    "username": string,
                    "id": number
                }
    }
]
```
### Update Address
- PUT
- Url http://localhost:5000/api/address/{AddressId}
- Data
```
{
  "number": number,
  "complement": string
}
```
### Delete Address
- DELETE
- Url http://localhost:5000/api/address/{AddressId}?username=string
