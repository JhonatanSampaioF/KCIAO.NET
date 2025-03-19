![image](https://github.com/user-attachments/assets/9f0a7951-c726-468e-8538-9ef8ac9ce35e)# Definição do Projeto

### Integrantes
Gustavo Vieira Bargas - rm553471
</br>
Jhonatan Sampaio Ferreira - rm553791
</br>
Vivian Sy Ting Wu - rm553169

---

## Objetivo do Projeto
Desenvolver uma funcionalidade integrada ao aplicativo da Odontoprev para **promover a cultura de prevenção** em saúde bucal, reduzindo sinistros através de:
- 🗓️ Calendário personalizado para consultas e troca de itens de higiene.
- 🔔 Notificações inteligentes baseadas no perfil do usuário.

---

## Escopo:

Desenvolver uma nova funcionalidade dentro do aplicativo existente da Odontoprev que auxilie os usuários a manterem sua saúde bucal em dia por meio de um sistema de notificações e acompanhamento preventivo.

### Funcionalidades Principais
1. **Questionário inicial**: Coleta de dados sobre histórico de saúde bucal.
2. **Calendário preventivo**: Gestão de eventos (consultas, troca de escova, etc.).
3. **Sistema de notificações**: Lembretes personalizados via push ou e-mail.
4. **Interface intuitiva**: Design acessível e fácil navegação.

### Requisitos
| **Funcionais** | **Não Funcionais** |
|----------------|---------------------|
| Coleta de dados do usuário | Compatibilidade com Android/iOS |
| Gerenciamento de eventos | Conformidade com LGPD |
| Notificações personalizadas | Desempenho otimizado |
| - | Acessibilidade |
| - | UX/UI |

##### Requisitos Funcionais:

1.	Coleta de dados do usuário no primeiro acesso (doenças, última consulta ao dentista, troca de escova de dente e outros fatores que afetam a saúde bucal) .
2.	Exibição e gerenciamento de eventos no calendário: O usuário pode adicionar novas entradas para consultas, troca de escova e protetor bucal e editar ou excluir eventos existentes.
3.	Envio de notificações periódicas personalizadas com lembretes de consultas e dicas de cuidados bucais (com base nas informações do questionário inicial).

##### Requisitos Não Funcionais:

1.	Compatibilidade com dispositivos Android e iOS – garantindo que a nova funcionalidade seja integrada ao aplicativo da Odontoprev em ambas as plataformas.
2.	Segurança e proteção de dados do usuário, assegurando que as informações médicas e pessoais coletadas estejam protegidas de acordo com a LGPD (Lei Geral de Proteção de Dados).
3.	Desempenho otimizado, para que o aplicativo funcione de maneira fluida, sem travamentos ou problemas de lentidão.
4.	Acessibilidade, garantindo que todos os tipos de usuários, incluindo aqueles com deficiências visuais ou motoras, possam utilizar a funcionalidade de maneira eficiente.
5.	Interface de fácil navegação com acesso ao calendário, gerenciamento de eventos e personalização de lembretes.

---

## Arquitetura

### Abordagem Monolítica
A API foi desenvolvida em **arquitetura monolítica**, justificada por:

| **Vantagem** | **Explicação** |
|--------------|----------------|
| **Baixa Complexidade** | Projeto de baixa complexidade, não gerando necessidade da divisão em microsserviços. |
| **Simplicidade** | Escopo definido e funcionalidades centralizadas. |
| **Custo Reduzido** | Sem necessidade de infraestrutura complexa. |
| **Integração Simplificada** | Comunicação única com o app mobile existente. |
| **Velocidade** | Entrega ágil de MVP para validação do conceito. |
| **Integração Simplificada** | Comunicação única com o frontend mobile, sem utilização de múltiplas apis. |

### Estrutura do Projeto
KCIAO.NET/
</br>
├── Controllers/          # Endpoints da API
</br>
├── Services/             # Lógica de negócio
</br>
├── Models/               # Entidades
</br>
├── Repositories/         # Acesso a dados
</br>
├── Infrastructure/       # Configurações
</br>
└── appsettings.json      # Configurações do banco de dados

### Design Patterns
1. **Repository Pattern**: Utilizado para isolar a lógica de acesso ao banco de dados.
2. **Dependency Injection**: Utilizado para desacoplar componentes e facilitar testes.

---

## Lista de Endpoints  
Os endpoints abaixo seguem a estrutura padrão de uma API RESTful e estão mapeados para os domínios principais do sistema.  

---

### **Domínios e URLs Base**  
| Domínio   | URL Base         |  
| :-------: | :--------------: |  
| Cliente   | `/Cliente`       |  
| Consulta  | `/Consulta`      |  
| Doença    | `/Doenca`        |  
| Evento    | `/Evento`        |  

---

### **Cliente**  
| Método HTTP | Descrição        | URL                                      | Corpo da Requisição (Exemplo) |  
| :---------: | ---------------- | ---------------------------------------- | ----------------------------- |  
| `GET`       | Listar todos     | `http://localhost:5007/Cliente`          | -                             |  
| `GET`       | Detalhes         | `http://localhost:5007/Cliente/{id_cliente}`     | -                             |  
| `POST`      | Criar            | `http://localhost:5007/Cliente`          | `{ "nm_cliente": "João" }`          |  
| `PUT`       | Atualizar        | `http://localhost:5007/Cliente/{id_cliente}`     | `{ "nm_cliente": "João Silva" }`    |  
| `DELETE`    | Excluir          | `http://localhost:5007/Cliente/{id_cliente}`     | -                             |  

---

### **Consulta**  
| Método HTTP | Descrição        | URL                                      | Corpo da Requisição (Exemplo) |  
| :---------: | ---------------- | ---------------------------------------- | ----------------------------- |  
| `GET`       | Listar todos     | `http://localhost:5007/Consulta`         | -                             |  
| `GET`       | Buscar por ID    | `http://localhost:5007/Consulta/{id_consulta}`    | -                             |  
| `POST`      | Agendar          | `http://localhost:5007/Consulta`         | `{ "profissional": "Maria de Jesus", "local_consulta": "Hospital Odontológico Paulista", "horario_consulta": "1400", "fk_evento": "21" }` |  
| `PUT`       | Atualizar        | `http://localhost:5007/Consulta/{id_consulta}`    | `{ "profissional": "Mariana de Jesus", "local_consulta": "Hospital Odontológico Consolação", "horario_consulta": "1500", "fk_evento": "21" }` |  
| `DELETE`    | Cancelar         | `http://localhost:5007/Consulta/{id_consulta}`    | -                             |  

---

### **Doença**  
| Método HTTP | Descrição        | URL                                      | Corpo da Requisição (Exemplo) |  
| :---------: | ---------------- | ---------------------------------------- | ----------------------------- |  
| `GET`       | Listar todas     | `http://localhost:5007/Doenca`           | -                             |  
| `GET`       | Buscar por ID    | `http://localhost:5007/Doenca/{id_doenca}`      | -                             |  
| `POST`      | Cadastrar        | `http://localhost:5007/Doenca`           | `{ "nm_doenca": "Cárie" }`         |  
| `PUT`       | Atualizar        | `http://localhost:5007/Doenca/{id_doenca}`      | `{ "nm_doenca": "Gengivite" }`     |  
| `DELETE`    | Excluir          | `http://localhost:5007/Doenca/{id_doenca}`      | -                             |  

---

### **Evento**  
| Método HTTP | Descrição        | URL                                      | Corpo da Requisição (Exemplo) |  
| :---------: | ---------------- | ---------------------------------------- | ----------------------------- |  
| `GET`       | Listar todos     | `http://localhost:5007/Evento`           | -                             |  
| `GET`       | Buscar por ID    | `http://localhost:5007/Evento/{id_evento}`      | -                             |  
| `POST`      | Criar            | `http://localhost:5007/Evento`           | `{ "tipo_evento": "Troca de Escova", "desc_evento": "Troca de escova de dentes", "dt_evento": 2025-03-25, "fk_cliente": "21" }` |  
| `PUT`       | Atualizar        | `http://localhost:5007/Evento/{id_evento}`      | `{ "tipo_evento": "Troca de Escova", "desc_evento": "Troca de escova de dentes", "dt_evento": 2025-03-25, "fk_cliente": "21" }` |  
| `DELETE`    | Excluir          | `http://localhost:5007/Evento/{id_evento}`      | -                             |  

---

## Testes

### **Cliente**
#### Listagem
![image](https://github.com/user-attachments/assets/72ecdbbe-0bb3-4773-bd42-7fa3caae4a0d)

#### Create
![image](https://github.com/user-attachments/assets/11d9fa11-1e8f-4176-b76d-589fdb613dae)

#### Details
![image](https://github.com/user-attachments/assets/d96fdc22-912e-4aad-ae81-429127aed0fd)

#### Edit
![image](https://github.com/user-attachments/assets/022cc8d7-e2cb-49d3-ac46-8650bc2a8a07)

#### Delete
![image](https://github.com/user-attachments/assets/a3190362-3131-449e-ac4e-74c708f6713d)

### **Consulta**
#### Listagem
![image](https://github.com/user-attachments/assets/f82509d2-47d9-4944-b8ad-42503d4512ff)

#### Create
![image](https://github.com/user-attachments/assets/50eeabc0-ccdc-4b88-bdf6-7d0a12ddf8e8)

#### Details
![image](https://github.com/user-attachments/assets/d345fbc4-0cc0-4649-a882-dc8caa04a4b9)

#### Edit
![image](https://github.com/user-attachments/assets/bc3f7fd3-dd9e-4dbb-99a2-53febd75d3ed)

#### Delete
![image](https://github.com/user-attachments/assets/86dcde40-5307-4969-9f69-49a352b2394e)

### **Doença**
#### Listagem
![image](https://github.com/user-attachments/assets/1b0227ab-1cf7-457c-8541-3fd07b284589)

#### Create
![image](https://github.com/user-attachments/assets/139d25fd-0703-4c1c-bce6-b9cd87b93ede)

#### Details
![image](https://github.com/user-attachments/assets/3a073631-5dfe-451e-abbe-d9e19c9c64fb)

#### Edit
![image](https://github.com/user-attachments/assets/ebb60adb-d327-4909-9d75-00cb5dbefa75)

#### Delete
![image](https://github.com/user-attachments/assets/baabce32-363d-41bd-887f-e5712de7be5a)

### **Evento**
#### Listagem
![image](https://github.com/user-attachments/assets/d3f38998-936f-450b-a317-54c1a111b288)

#### Create
![image](https://github.com/user-attachments/assets/fb45ed62-957e-4122-9dd5-020a60b2d3d0)

#### Details
![image](https://github.com/user-attachments/assets/1a534010-a941-4546-9397-d5907172061d)

#### Edit
![image](https://github.com/user-attachments/assets/300341ce-66da-408f-980f-728cee10ca70)

#### Delete
![image](https://github.com/user-attachments/assets/c885f3a1-fdf5-498d-becb-2f687fdaaf56)
