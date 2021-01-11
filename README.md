# webapi-rest-net-framework-client
This is the client for the  [webapi-rest-net-framework repository](https://github.com/hikager/webapi-rest-net-framework). It is based on WPF and MVVM pattern which calls the api (provider).

## What is this client about?
Transfers from one _warehouse_ to another an amount of products using Post and Get request to the web-api-rest.

### Improves

1. Passing from body parameters (from post request)
2. Creating views in the database to avoid using DTOs (from server)
3. Using _ShouldSeralizedX_ to avoid massive DTOs (from server)
4. Passing per parameter the amount of product instead of using a binding property with textBox (view - client)
5. Load the server endpoint asyncronous (Avoiding errors when the client is starting)
6. Adding some label for _Server Status_ (as if the server is On or is not connected the client to it)


### Database structure

<img align="left" src="https://github.com/hikager/webapi-rest-net-framework-client/blob/master/pic-repo/database-record-structure.PNG">
