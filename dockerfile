FROM microsoft/aspnetcore-build:2.0.7-2.1.105-jessie AS builder
RUN mkdir /build && \
    cd /build && \
    git clone https://github.com/alessandrorodiani/aspnetcore-web-example.git
WORKDIR /build/aspnetcore-web-example/src
RUN dotnet publish -o /published/aspnetcore-web-example

FROM microsoft/aspnetcore
WORKDIR /web/aspnetcore-web-example
COPY --from=builder /published/aspnetcore-web-example .
CMD ["dotnet", "MyDemoApp.dll"]
EXPOSE 80/tcp
