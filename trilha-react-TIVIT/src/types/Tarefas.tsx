export const StatusTarefa = {
  Pendente: "Pendente",
  Finalizado: "Finalizado",
} as const;

export type StatusTarefa = (typeof StatusTarefa)[keyof typeof StatusTarefa];

export interface Tarefa {
  id: number;
  titulo: string;
  descricao: string;
  dataCriacao: string;
  status: StatusTarefa;
}
