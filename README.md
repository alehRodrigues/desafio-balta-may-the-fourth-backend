![balta](https://baltaio.blob.core.windows.net/static/images/dark/balta-logo.svg)

![Logo do App](https://github.com/balta-io/desafio-balta-may-the-fourth-backend/assets/965305/880fab7e-3998-4a0d-98ad-1d6ffc11298b)

## 🎖️ Desafio
**May the Fourth** é a quarta edição dos **Desafios .NET** realizados pelo [balta.io](https://balta.io). Durante esta jornada, fizemos parte do batalhão backend onde unimos forças para entregar um App completo.

## 📱 Projeto
Desenvolvimento de uma API completa, fornecendo recursos como criação, leitura, atualização e exclusão de dados referentes ao universo **Star Wars**.

## Participantes
### 🚀 Capitão
[Alexandre Rodrigues](https://github.com/DoufaDev)

### 💂‍♀️ Batalhão
* [Leonardo Gasperin](https://github.com/leonardoGasperin)
* [Matheus Leal](https://github.com/Matheusleal)
* [Duglas Neves](https://github.com/DoufaDev)
* [Denisson Silva](https://github.com/DoufaDev)

## ⚙️ Tecnologias
* C# 12
* .NET 8
* ASP.NET
* Minimal APIs
* SQLite

## 🥋 Skills Desenvolvidas
* Comunicação
* Trabalho em Equipe
* Networking
* Muito conhecimento técnico

## Sobre a API

   Essa API foi desenvolvida com a abordagem de Minimals API, projetada para ser simples, leve e fácil de usar. Você pode enteder mais a respeito dessa abordagem [esse artigo](https://blog.balta.io/aspnet-minimal-apis/) e se você quiser se aprofundar ainda mais [assista esse vídeo.](https://youtu.be/s_ihuUjnsec)
    
2. Tokens e Acesso    

    Por se tratar de uma API pública, criada para fãs, não será necessário um login ou criação de token de acesso. Sendo assim, você já pode ter acesso a nossa API através do endereço ***urlDaAPI.com.br.***
    
3. Retorno da API    

    Todos os endpoints de consulta retornarão dados no tipo JSON. Consultas inválidas ou indisponíves retornaram um [status HTTP](https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Status) com o motivo da falha.

## 🧪 Como testar o projeto
Você pode acessar a API via link
`https://staris-api.runasp.net`
e utilizar os endpoints, exemplo:
`https://staris-api.runasp.net/api/characters`
Você também pode utilizar os filtros como por exemplo 
`https://staris-api.runasp.net/api/characters?search=3`

## Endpoints de Buscas
1. Buscando Filmes

Você poderá buscar uma lista com todos os filmes ou uma lista ds filmes filtrados por parametros. Com o método GET faça a requisição para o endpoit **`MoviesList`** para obter a lista de filmes sem filtros. Para filtrar por parâmetro use o mesmo método porém com o parâmetro e valor correspondente por exemplo: **`moviesList?director="Jhon Doe"`** . No exemplo abaixo está o formato do retorno, com ele você poderá conhecer os parametros os demais disponíveis para as requisições.

```json
{
  "title": "The Rise of the Jedi",
  "episode": 10,
  "openingCrawl": "After the fall of the Empire, the galaxy face",
  "director": "Jana Doe",
  "producer": "Leo Smith",
  "releaseDate": "2028-12-15",
  "characters": [
    {"id": 1, "name": "Kara Zor-El"},
    {"id": 2, "name": "Jaxxon T. Tumperakki"},
    {"id": 3, "name": "Mara Jade"},
    {"id": 4, "name": "Thrawn"},
    {"id": 5, "name": "R2-D2"}
  ],
  "planets": [
    {"id": 1, "name": "Coruscant"},
    {"id": 2, "name": "Tatooine"},
    {"id": 3, "name": "Dagobah"}
  ],
  "vehicles": [
    {"id": 1, "name": "Speeder Bikes"},
    {"id": 2, "name": "AT-AT Walkers"}
  ],
  "starships": [
    {"id": 1, "name": "Millennium Falcon"},
    {"id": 2, "name": "X-wing"},
    {"id": 3, "name": "TIE Fighter"}
  ]
}
```
2. Buscando Personagens

Você poderá buscar uma lista com todos os personagens ou uma lista ds personagens filtrados por parametros. Com o método GET faça a requisição para o endpoit **`CharacterList`** para obter a lista de personagens sem filtros. Para filtrar por parâmetro use o mesmo método porém com o parâmetro e valor correspondente por exemplo: **`/CharacterList?gender=female`** . No exemplo abaixo está o formato do retorno, com ele você poderá conhecer os parametros os demais disponíveis para as requisições.

``` json
{
  "name": "Zara Kell",
  "height": "172 cm",
  "weight": "68 kg",
  "hairColor": "black",
  "skinColor": "tan",
  "eyeColor": "green",
  "birthYear": "242 ABY",
  "gender": "female",
  "planet": {"id": 1, "title": "Tatooine"},
  "movies": [
    {"id": 1, "title": "The Battle of the Stars"},
    {"id": 2, "title": "Return of the Light"},
    {"id": 3, "title": "Warriors of the Shadow Realm"}
  ]
}
```


3. Buscando Planetas

Você poderá buscar uma lista com todos os planetas ou uma lista dos planetas filtrados por parametros. Com o método GET faça a requisição para o endpoit **`PlanetList`** para obter a lista de planetas sem filtros. Para filtrar por parâmetro use o mesmo método porém com o parâmetro e valor correspondente por exemplo: **`/PlanetList?climate=temperate`** . No exemplo abaixo está o formato do retorno, com ele você poderá conhecer os parametros os demais disponíveis para as requisições.

4. Veículos

Você poderá buscar uma lista com todos os veículos ou uma lista dos veículos filtrados por parametros. Com o método GET faça a requisição para o endpoit **`VehicleList`** para obter a lista de veículos sem filtros. Para filtrar por parâmetro use o mesmo método porém com o parâmetro e valor correspondente por exemplo: **`/VehicleList?name=Voyager`** . No exemplo abaixo está o formato do retorno, com ele você poderá conhecer os parametros os demais disponíveis para as requisições.

```json
{
  "name": "Star Voyager",
  "model": "SV-2",
  "manufacturer": "Galactic Starcraft",
  "costInCredits": "500000",
  "length": "120 meters",
  "maxSpeed": "950 km/h",
  "crew": "5",
  "passengers": "30",
  "cargoCapacity": "150000 kg",
  "consumables": "2 years",
  "class": "Cruiser",
  "movies": [
    {"id": 1, "title": "The Return of the Voyager"},
    {"id": 2, "title": "Voyager's Endgame"}
  ]
}
```

5. Naves Estelares

Você poderá buscar uma lista com todas as naves estelares ou uma lista das naves estelares filtradas por parametros. Com o método GET faça a requisição para o endpoit **`StarShipsList`** para obter a lista de naves estelares sem filtros. Para filtrar por parâmetro use o mesmo método porém com o parâmetro e valor correspondente por exemplo: **`/StarShipsList?manufacturer=Shipworks`** . No exemplo abaixo está o formato do retorno, com ele você poderá conhecer os parametros os demais disponíveis para as requisições.

```json
{
  "name": "Galactic Explorer",
  "model": "GX-3",
  "manufacturer": "Interstellar Shipworks",
  "costInCredits": "800000",
  "length": "85 meters",
  "maxSpeed": "880 km/h",
  "crew": "10",
  "passengers": "40",
  "cargoCapacity": "200000 kg",
  "hyperdriveRating": "1.5",
  "mglt": "70",
  "consumables": "6 months",
  "class": "Explorer",
  "movies": [
    {"id": 1, "title": "Galactic Odyssey"},
    {"id": 2, "title": "The Edge of the Universe"}
  ] 
}
```






# 💜 Participe
Quer participar dos próximos desafios? Junte-se a [maior comunidade .NET do Brasil 🇧🇷 💜](https://balta.io/discord)
