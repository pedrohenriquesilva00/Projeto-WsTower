# Configurar o projeto na sua máquina: 
SQL Server:
Rode o Script da pasta Database para criar o Banco, as tabelas e informações dela.

API:
Abra a API e em Properties > launchSettings.json
mude o "applicationUrl" para seu endereço de IP local.

Logo em seguida vá na pasta Contexts > CampeonatoContext.cs
e mude o "Server=localhost"; para o nome do seu servidor.

Xamarin:
Abra o projeto Xamarin, e vá na pasta Helpers > Utils.cs
e em client.BaseAddress = new Uri("http://localhost:5000/api/"); coloque seu endereço de IP local.
Mude apenas o localhost.

Pronto, agora você pode rodar o projeto na sua máquina.

nstall API
# Clone this repository
$ git clone https://github.com/DanielObara/NLW-1.0

# Go into the repository
$ cd NLW-1.0/backend

# Install dependencies
$ yarn install

# Run Migrates
$ yarn knex:migrate

# Run Seeds
$ yarn knex:seed

# Start server
$ yarn dev

# running on port 3333
