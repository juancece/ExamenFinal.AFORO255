#!/bin/bash

# Ejecutar Microsoft SQL Server y el script de inicializacion (al mismo tiempo)
/usr/src/app/initialization.sh & /opt/mssql/bin/sqlservr