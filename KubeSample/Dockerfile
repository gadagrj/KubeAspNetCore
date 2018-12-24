FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["KubeSample/KubeSample.csproj", "KubeSample/"]
COPY ["KubeSample.Data/KubeSample.Data.csproj", "KubeSample.Data/"]
RUN dotnet restore "KubeSample/KubeSample.csproj"
COPY . .
WORKDIR "/src/KubeSample"
RUN dotnet build "KubeSample.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "KubeSample.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "KubeSample.dll"]




# docker build -t kubeaspnetapp:v4 -f E:/2018/K8Samples/ASPNETCOREK8/KubeSampleDockerfile .
# docker tag kubeaspnetapp:v4 rjgadag/kubeaspnetapp:v4
# docker push rjgadag/kubeaspnetapp