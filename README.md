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