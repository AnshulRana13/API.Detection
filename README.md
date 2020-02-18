# Detectify Service

Detectify is a service that takes in a list of domain names via a REST API, and returns
the list of hosts that run on specific server. An example would be demo.nginx.com. The input and output is  formatted as JSON array, e.g. for [“example.com”, “blog.detectify.com”] input, we could have [“blog.detectify.com”] as output.

An optional feature is also developed to retrieve the IP address(es), so we know more precisely what we need to target. The IPs is associated with the hostnames. An example of such output would be {“blog.detectify.com”: [“8.8.8.8”]}.


# Technology and Infrastructure 

 - .Net Core Web API
 - JWT Authentication
 - Swagger
 - Azure redis cache service
 - Azure cosmos db service
 - docker

# Steps require to make service up and running.

 1.  git clone https://github.com/AnshulRana13/API.Detection.git
 2.  build Detectify.ServerDetection.API.sln , Please check with given url in build section for 
      various platform  https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-build      
 3. For visual code / visual studio youcan use IIS Express and run the application 
 4. Create a Docker Image by building and executing the Dockerfile using the Docker    
      CLI.When creating the image we also define a friendly name and tag. The name should  
      refer to the application, in this case aspnet. The tag is a string and commonly used as a 
      version number, in this case it's v0.1.
      **docker build -t aspnet-app:v0.1**
      You can view the Docker Images on your host using
       **docker images | head -n2**
 5. Make sure your network can access Azure services as I am using Azure redis cache
     service and Azure cosmos db service.     
 6. When Services is hosted sucessfully , You can see Swagger index.html page which will 
     display features of the service.

## How to use the service

 - Firstly, Service will Authenticate the user and you need to browse 
     https://localhost:44312/api/Auth , either through swagger or postman
     method : Post 
     body :    {"UserName": "anshul",	"Password": "anshul!123" }
     content-Type :  application/json
 
 - After successful execution of step 1, you will be issued a JWT token for further  
     authentication, as of now token has expiration time upto 24hrs. response example: 
     {
    "userInfo": {
        "userName": "anshul",
        "password": null,
        "firstName": "Anshul",
        "lastName": "Rana",
        "fullName": "Anshul Rana"
    },
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFuc2h1bCBSYW5hIiwibmJmIjoxNTgyMDI2NDUzLCJleHAiOjE1ODIxMTI4NTMsImlhdCI6MTU4MjAyNjQ1MywiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzMTIvIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzMTIvIn0.2TaY_zLiEdy95coHNitGjFIwg4siR9_o0aLlaFJEJmU",
    "tokenType": "Bearer"
}
 - Now, once we are issued a token we are ready to call actual service 
      https://localhost:44312/api/dns/lookup/nginx. , please use postman for calling the service ,  Authorization : Bearer <token> , content-Type :  application/json, method : post, body : [  "google.com",  "facebook.com",  "blog.detectify.com"] 
 
## Scalibilty 
 - This service can be scalable with bare minmum effort and will support all sort of  
      technology.
      
 - Radis cache and Mongodb service is used for caching and user information respectively.
 - We can also intgrate Kafka and other messaging queue to talk and intiate other services
 - I am using infrastruture as a service, which is helping to build service faster.
 - We can also integrate feature like config server, corellationId, API Gateway etc.