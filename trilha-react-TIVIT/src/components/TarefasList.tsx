import { type Tarefa, StatusTarefa } from "../types/Tarefas";

interface Props {
  tarefas: Tarefa[];
  onDelete: (id: number) => void;
  onFinalizar: (id: number) => void;
}

const formatarDataHora = (dataIso: string): string => {
  const data = new Date(dataIso);
  return data.toLocaleString("pt-BR", {
    day: "2-digit",
    month: "2-digit",
    year: "numeric",
    hour: "2-digit",
    minute: "2-digit",
  });
};

export function TarefaList({ tarefas, onDelete, onFinalizar }: Props) {
  return (
    <ul className="space-y-3">
      {tarefas.map((tarefa) => {
        const finalizada = tarefa.status === StatusTarefa.Finalizado;

        return (
          <li
            key={tarefa.id}
            className={`
              rounded-lg
              shadow-sm
              px-3 py-2
              flex flex-col gap-1
              transition
              ${finalizada ? "bg-green-50 opacity-80" : "bg-white"}
            `}
          >
            <h3
              className={`font-semibold ${
                finalizada ? "line-through text-slate-400" : "text-slate-800"
              }`}
            >
              {tarefa.titulo}
            </h3>

            <p className="text-sm text-slate-500">{tarefa.descricao}</p>
            <p className="text-xs text-slate-400 text-right">
              {formatarDataHora(tarefa.dataCriacao)}
            </p>
            <div className="flex justify-between items-center mt-2">
              <span
                className={`text-xs px-3 py-1 rounded-full font-medium
                  ${
                    finalizada
                      ? "bg-green-100 text-green-700"
                      : "bg-blue-100 text-blue-700"
                  }
                `}
              >
                {finalizada ? "✅ Finalizado" : "🕒 Pendente"}
              </span>

              <div className="flex gap-4">
                {!finalizada && (
                  <button
                    onClick={() => onFinalizar(tarefa.id)}
                    className="text-sm text-green-600 hover:text-green-800"
                  >
                    Finalizar
                  </button>
                )}

                <button
                  onClick={() => onDelete(tarefa.id)}
                  className="text-sm text-red-600 hover:text-red-800"
                >
                  Excluir
                </button>
              </div>
            </div>
          </li>
        );
      })}
    </ul>
  );
}
