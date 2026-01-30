import axios from "axios";
import { type Tarefa, StatusTarefa } from "../types/Tarefas";

const api = axios.create({
  baseURL: "http://localhost:8001/api",
});

export const tarefaService = {
  // CRUD
  getAll: () => api.get<Tarefa[]>("/Tarefa"),

  getById: (id: number) => api.get<Tarefa>(`/Tarefa/${id}`),

  create: (tarefa: Omit<Tarefa, "id">) => api.post("/Tarefa", tarefa),

  update: (tarefa: Tarefa) => api.put(`/Tarefa/${tarefa.id}`, tarefa),

  remove: (id: number) => api.delete(`/Tarefa/${id}`),

  // BUSCAS
  buscarPorTitulo: (titulo: string) =>
    api.get<Tarefa[]>(`/Tarefa/buscarPorTitulo`, {
      params: { titulo },
    }),

  buscarPorDataCriacao: (dataCriacao: string) =>
    api.get<Tarefa[]>(`/Tarefa/buscarPorDataCriacao`, {
      params: { dataCriacao },
    }),

  buscarPorStatus: (status: StatusTarefa) =>
    api.get<Tarefa[]>(`/Tarefa/buscarPorStatus`, {
      params: { status },
    }),

  finalizar: (id: number) => api.patch(`/Tarefa/${id}/finalizar`),
};
