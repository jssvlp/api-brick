FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app
COPY --from=build-env /app/out .

ENV SECRET_API_KEY vYGEpxjzfBVlMlqwhvWXRUxmEhTYrwyoeYmXrwwlSKZdJulHXG
ENV NOTIFICATION_MAIL jossias.vel@gmail.com
ENV SENDGRID_API_KEY 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
ENV RESET_PASSWORD_TEMPLATE d-f4a9b10a299c463692333d7fb4dfb5c8
ENV DOMAIN https://constructoramejiapolanco.com

ENTRYPOINT ["dotnet", "api-brick.dll"]