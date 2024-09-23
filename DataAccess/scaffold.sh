#!/bin/bash
dotnet ef dbcontext scaffold \
  "Server=localhost;Database=postgres;User Id=cro1;Password=cro1;" \
  Npgsql.EntityFrameworkCore.PostgreSQL \
  --output-dir ./Models \
  --context-dir . \
  --context PaperContext  \
  --no-onconfiguring \
  --force