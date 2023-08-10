# Smakownia

Online pizzeria application, based on a simplified microservices architecture and Docker containers.

![preview](github/img/preview.png)

## Getting Started

> Make sure you have installed and configured docker in your environment.

Clone all repositories:

```bash
git clone https://github.com/smakownia/sk-gateway.git
git clone https://github.com/smakownia/sk-products.git
git clone https://github.com/smakownia/sk-basket.git
git clone https://github.com/smakownia/sk-frontend.git
```

Build and run each of them:

```bash
cd sk-gateway
docker-compose build 
docker-compose up -d

cd ../sk-products
docker-compose build
docker-compose up -d

cd ../sk-basket
docker-compose build
docker-compose up -d

cd ../sk-frontend
docker-compose build
docker-compose up -d
```

## Technologies

### Gateway service

- ASP .NET core
- Ocelot
- Swagger

### Products service

- ASP .NET core
- Swagger
- Entity Framework Core
- MsSQL
- CQRS
- DDD

### Basket service

- ASP .NET core
- Swagger
- Redis
- CQRS
- DDD

### Frontend service

- React
- TypeScript
- Next.js
- Tailwind CSS
- React Query
- React Hook Form

## Architecture overview

This reference application is cross-platform at the server and client-side, thanks to .NET 6 services capable of running on Linux or Windows containers depending on your Docker host. The architecture proposes a microservice oriented architecture implementation with multiple autonomous microservices (each one owning its own database/cache) and implementing different approaches within each microservice (simple CRUD or DDD/CQRS patterns) using HTTP as the communication protocol between the client apps and the microservices.

![diagram](github/img/diagram.png)
