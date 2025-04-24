## 🕹️ IA em Games: Máquinas de Estados Finitos com Navegação Inteligente para NPCs
Este repositório contém a implementação de uma aplicação de IA para jogos utilizando Máquinas de Estados Finitos (FSM) combinadas com NavMesh e waypoints, onde um NPC muda seu comportamento dinamicamente dependendo da proximidade do jogador e se movimenta de forma otimizada pelo cenário.

## 💡 Descrição
O NPC inicia no estado de patrulhamento 🚶‍♂️, deslocando-se entre pontos predefinidos (waypoints) com uso de NavMesh, garantindo uma movimentação fluida e eficiente. Ao detectar o jogador dentro de uma distância específica, o NPC transita para o estado de perseguição 🏃‍♂️, passando a seguir o jogador pelo ambiente de forma estratégica e responsiva.

## 🛠️ Funcionalidades
- Patrulhamento com Waypoints: O NPC se movimenta de forma planejada entre pontos definidos no cenário, simulando uma patrulha realista.

- Perseguição com NavMesh: Quando o jogador entra em uma zona de detecção, o NPC utiliza o sistema de navegação do Unity (NavMesh) para seguir o jogador de maneira eficiente, evitando obstáculos.

- Transições de Estado Inteligentes: Toda a lógica de comportamento é gerida por uma máquina de estados finitos, que organiza e executa as mudanças de estado de forma estruturada.

## 🚀 Tecnologias Utilizadas
- 🎮 Engine: Unity 6

- 💻 Linguagem: C#

- 🧭 Navegação: Unity NavMesh

- 📍 Waypoints: Sistema de pontos de patrulha

## 🎯 Objetivo
Este projeto foi desenvolvido como parte das atividades da disciplina de IA em Jogos do curso de Jogos Digitais da PUC Campinas 🎓. O objetivo é aplicar conceitos de inteligência artificial e navegação em ambientes virtuais para simular comportamentos inteligentes de NPCs.
