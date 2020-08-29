# Basado en https://github.com/SoftwareDeveloperBlog/Docker-compose-dotnet-core-and-mssql
# Usaremos la misma del curso
FROM mcr.microsoft.com/mssql/server:2019-GA-ubuntu-16.04

USER root

# Creamos el directorio de la aplicacion
RUN mkdir -p /usr/src/app
WORKDIR /usr/src/app

# Copiamos el script de inicializacion
COPY . /usr/src/app

# Permisos de ejecucion para el script de inicializacion
RUN chmod +x /usr/src/app/entrypoint.sh
RUN chmod +x /usr/src/app/initialization.sh

# Ejecutar MS SQL server y el script de inicializacion (al mismo tiempo)
#  Nota-> Comentar si solo se necesita ejecutar SQL Server (sin el script de inicializacion)
#CMD /bin/bash ./entrypoint.sh
ENTRYPOINT ["/bin/bash", "./entrypoint.sh"]