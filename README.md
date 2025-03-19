# Definição do Projeto

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

---

## Design Patterns
1. **Repository Pattern**: Utilizado para isolar a lógica de acesso ao banco de dados.
2. **Dependency Injection**: Utilizado para desacoplar componentes e facilitar testes.
