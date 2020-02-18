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
 3. For visual code / visual studio use can use IIS Express and run the application 