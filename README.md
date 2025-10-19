# Gerenciamento-EDDII

## Descrição do Projeto

O **Gerenciamento-EDDII** é um sistema de gerenciamento de projetos e tarefas desenvolvido em **C#** com arquitetura **MVC** (Model-View-Controller). O projeto permite que usuários adicionem, visualizem, alterem e removam projetos, além de gerenciar tarefas associadas a cada projeto de forma organizada e eficiente. Ele foi desenvolvido como prática de programação para controle de fluxo e manipulação de dados no console.

O sistema possui uma interface de console interativa, onde os usuários podem navegar por menus, escolher opções e realizar ações sobre projetos e tarefas. As funcionalidades incluem adição de novos projetos, consulta de projetos existentes, remoção de projetos, inclusão de tarefas, alteração de status de tarefas, listagem detalhada de tarefas e filtros avançados por status ou prioridade.

Cada projeto é representado por um **ID único** e um nome descritivo, enquanto cada tarefa possui ID, descrição, prioridade e status. O status das tarefas pode ser **Aberta**, **Concluída** ou **Cancelada**, permitindo um acompanhamento visual e estatístico do progresso dos projetos cadastrados.

O sistema implementa **validações de entrada de dados**, garantindo que IDs sejam números inteiros válidos e que campos obrigatórios não fiquem vazios. Isso melhora a confiabilidade do software e reduz erros durante a execução no console, oferecendo uma experiência mais robusta para o usuário.

Uma das principais funcionalidades do projeto é o **resumo geral**, que apresenta métricas de todos os projetos cadastrados, incluindo número total de tarefas, tarefas abertas, concluídas e canceladas, além do percentual de conclusão. Essa visão proporciona um acompanhamento rápido do andamento dos projetos de maneira consolidada.

O projeto é totalmente **modular**, com controllers separados para projetos e tarefas. O `ProjetoController` gerencia operações relacionadas a projetos, enquanto o `TarefaController` lida com a criação, alteração e filtragem de tarefas. A separação de responsabilidades segue boas práticas de programação orientada a objetos.

A camada de modelos (`Model`) é composta pelas classes `Projeto`, `Projetos` e `Tarefa`, que encapsulam os dados e métodos necessários para a manipulação das entidades do sistema. Essa organização facilita a manutenção, extensão do projeto e futura implementação de novas funcionalidades.

O **MenuView** serve como interface principal com o usuário, apresentando todas as opções de operação e interagindo diretamente com os controllers. Ele garante que o fluxo do programa seja claro, intuitivo e seguro, guiando o usuário em todas as etapas do gerenciamento de projetos e tarefas.

O projeto também é compatível com práticas de versionamento e gerenciamento de código, podendo ser hospedado em **GitHub**, permitindo colaboração, controle de versões e documentação histórica das alterações realizadas ao longo do desenvolvimento.

Por fim, o **Gerenciamento-EDDII** é uma solução educativa completa, ideal para estudo de conceitos de C#, orientação a objetos, manipulação de listas, uso de enumerações, validação de entrada de dados e construção de sistemas de console robustos, servindo como base para futuros projetos mais complexos de gerenciamento ou sistemas de informação.
