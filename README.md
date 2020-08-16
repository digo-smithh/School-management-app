# 📚 School-management-app 📚
### Feito por Rodrigo Smith e Eduardo Migueis, em C# e NodeJS

Um aplicativo para cadastro de um resultado que um aluno teve em determinada disciplina. Foi feito com o objetivo de colocarmos em prática conhecimentos de Estrutura de Dados.

## 🔵 Mais sobre... 🔵
Este aplicativo foi feito com o objetivo de colocarmos em prática conhecimentos sobre as estruturad de dados Fila e Lista Ligada. Suas funcionalidades são simples, porém sua lógica é muito estruturada e pensada.

## 💽 Fila e Lista Ligada 💽
Farei um pequeno resumo dessas duas estruturas, relacionando-o com seus usos em nosso projeto.

##### Fila:
Uma Fila consiste em uma classe que armazena dados (comumente, em uma matriz unidimensional), mas seguindo o princípio FIFO (First in, First out). Isso significa que, ao ser adicionado dados no vetor, apenas conseguiremos remover os primeiros que foram adicionados, assim como em uma fila de supermercado: o primeiro que chega, é o primeiro que sai.
                                                
                                           FIM DA FILA        INICIO DA FILA
                    DADOS SENDO ADICIONADOS ->  🟥🟩🟩🟩🟩🟩🟩🟩🟩  <- DADOS SENDO REMOVIDOS
                                                
                                                🟩🟥🟩🟩🟩🟩🟩🟩🟩

                                                🟩🟩🟥🟩🟩🟩🟩🟩🟩
                                                
                                                        (...)

                                                🟩🟩🟩🟩🟩🟩🟩🟩🟥

##### Lista Ligada:
Uma Lista Ligada, na prática, funciona exatamente como um vetor. Sua diferença está no armazenamento físico dos dados na memória RAM. Enquanto um vetor, ao ser declarado, separa uma região inteira da memória para ser possivelmente utilizada futuramente, uma Lista Ligada procura automaticamente por qualquer local disponível, para alojar os dados, **conforme eles são adicionados.**

                                                        VETOR
                                                          
     🟥 - DADOS ADICIONADOS  NO VETOR        🟧🟩🟩🟩🟩🟩🟩🟩🟩🟩🟦  <- DECLARAÇÃO DE UM VETOR DE 9 ESPAÇOS
     🟩 - ESPAÇO VAZIO NO VETOR
     🟦 - OUTROS DADOS QUAISQUER             🟧🟥🟥🟥🟥🟥🟥🟩🟩🟩🟦  <- DADOS ADICIONADOS
     🟧 - ESPAÇO VAZIO NA MEMÓRIA                                            
                                                
                                                     LISTA LIGADA
                                                
                                             🟦🟧🟦🟧🟦🟧🟦🟧🟧🟧🟦 
                                             
                                             🟦🟩🟦🟧🟦🟧🟦🟧🟧🟧🟦 <- ADICIONANDO UM DADO...
                                             
                                             🟦🟩🟦🟩🟦🟧🟦🟧🟧🟧🟦 <- ADICIONANDO MAIS UM...
