# Para configurar o projeto na sua máquina

# SQL Server:
Rode o Script da pasta Database para criar o Banco, as tabelas e informações dela.

# API:
Abra a API e em Properties > launchSettings.json
mude o "applicationUrl" para seu endereço de IP local.

Caso não lembre seu IP ou não saiba onde encontrar,
abra o Prompt de comando no modo Administrador e digite
"ipconfig". Veja o endereço que estiver em "IPv4" e adicione ao projeto.

Logo em seguida vá na pasta Contexts > CampeonatoContext.cs
e mude o "Server=localhost"; para o nome do seu servidor.

# Xamarin:
Abra o projeto Xamarin, e vá na pasta Helpers > Utils.cs
e em client.BaseAddress = new Uri("http://localhost:5000/api/"); coloque seu endereço de IP local.
Mude apenas o localhost.

Pronto, agora você pode rodar o projeto na sua máquina.
