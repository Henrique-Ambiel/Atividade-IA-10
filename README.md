# 🕹️ IA em Games: Máquinas de Estados Finitos para NPCs
Este repositório contém a implementação de uma aplicação de IA para jogos utilizando Máquinas de Estados Finitos (FSM), onde um NPC muda seu comportamento dependendo da proximidade do jogador.

## 💡 Descrição
O NPC começa em um estado de patrulhamento 🚶‍♂️ e, quando o jogador se aproxima a uma distância específica, o NPC transita para o estado de perseguidor 🏃‍♂️. Este comportamento é controlado por uma máquina de estados finitos, permitindo que o NPC tenha um comportamento mais dinâmico e interativo no jogo.

## 🛠️ Funcionalidades
- Patrulhamento: O NPC se move de forma aleatória em uma área designada, buscando observar a cena.
- Perseguição: Quando o jogador entra em uma zona de detecção, o NPC troca para o estado de perseguidor e começa a seguir o jogador.
- Transições de Estado: O comportamento do NPC é gerido por uma máquina de estados finitos, que gerencia as mudanças de estado de forma simples e eficiente.
 
## 🚀 Tecnologias Utilizadas
- 🎮 Engine: Unity6 (versão utilizada no desenvolvimento)
- 💻 Linguagem: C#

## 🎯Objetivo
Este projeto faz parte das atividades da disciplina de IA em jogos do curso de Jogos Digitais da PUC Campinas 🎓.
