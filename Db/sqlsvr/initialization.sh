#!/bin/bash

# esperar por el MSSQL server
export STATUS=1
i=0

while [[ $STATUS -ne 0 ]] && [[ $i -lt 30 ]]; do
  i=$i+1
  /opt/mssql-tools/bin/sqlcmd -t 1 -U sa -P Aforo255#2019 -Q "select 1" >> /dev/null
  STATUS=$?
done

if [[ $Status -ne 0 ]]; then
  echo "Error: MSSQL SERVER took more than thirty seconds to start up."
  exit 1
fi 

echo "====== MSSQL SERVER STARTED ======" | tee -a ./config.log
# Run the startup script to create the DB and the schema in the DB
/opt/mssql-tools/bin/sqlcmd -S 127.0.0.1 -U sa -P Aforo255#2019 -d master -i create-database.sql

echo "====== MSSQL CONFIG COMPLETE ======" | tee -a ./config.log