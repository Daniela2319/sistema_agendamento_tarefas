import { useEffect, useState } from "react";
import { type Tarefa, StatusTarefa } from "../types/Tarefas";
import { tarefaService } from "../services/api";

export function useTarefas() {
  const [tarefas, setTarefas] = useState<Tarefa[]>([]);
  const [loading, setLoading] = useState(false);

  // Funções de busca
  async function carregarTodas() {
    setLoading(true);
    const response = await tarefaService.getAll();
    setTarefas(response.data);
    setLoading(false);
  }
  // Função de criação
  async function criar(titulo: string, descricao: string) {
    await tarefaService.create({
      titulo,
      descricao,
      status: StatusTarefa.Pendente,
      dataCriacao: new Date().toISOString(),
    });
    carregarTodas();
  }
  // Função de remoção
  async function remover(id: number) {
    await tarefaService.remove(id);
    carregarTodas();
  }
  // Função de busca por título
  async function buscarPorTitulo(titulo: string) {
    if (!titulo) {
      carregarTodas();
      return;
    }

    const response = await tarefaService.buscarPorTitulo(titulo);
    setTarefas(response.data);
  }

  useEffect(() => {
    // eslint-disable-next-line react-hooks/set-state-in-effect
    carregarTodas();
  }, []);

  // Função de finalização
  async function finalizar(id: number) {
    const tarefa = tarefas.find((t) => t.id === id);
    if (!tarefa) return;
    await tarefaService.finalizar(id);
    carregarTodas();
  }

  // função de busca por status
  async function buscaPorStatus(status: StatusTarefa) {
    const response = await tarefaService.buscarPorStatus(status);
    setTarefas(response.data);
  }

  // função de busca por data de criação
  async function buscarPorDataCriacao(dataCriacao: string) {
    const response = await tarefaService.buscarPorDataCriacao(dataCriacao);
    setTarefas(response.data);
  }

  return {
    tarefas,
    loading,
    criar,
    remover,
    finalizar,
    buscarPorTitulo,
    buscaPorStatus,
    buscarPorDataCriacao,
  };
}
