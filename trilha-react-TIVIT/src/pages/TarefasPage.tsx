import { useState } from "react";
import { useTarefas } from "../hook/useTarefas";
import { TarefaList } from "../components/TarefasList";
import { StatusTarefa } from "../types/Tarefas";

export function TarefasPage() {
  const {
    tarefas,
    criar,
    remover,
    finalizar,
    loading,
    buscarPorTitulo,
    buscaPorStatus,
    buscarPorDataCriacao,
  } = useTarefas();

  const [titulo, setTitulo] = useState("");
  const [descricao, setDescricao] = useState("");
  const [buscar, setBuscar] = useState("");
  const [status, setStatus] = useState<StatusTarefa | "">("");
  const [dataCriacao, setDataCriacao] = useState("");

  // Funções de busca
  function handleSearch(value: string) {
    setBuscar(value);
    buscarPorTitulo(value);
  }
  // Função de busca por status
  function buscarStatus(status: StatusTarefa) {
    setStatus(status);
    buscaPorStatus(status);
  }
  // Função de busca por data de criação

  function handleSearchByDate(data: string) {
    setDataCriacao(data);
    buscarPorDataCriacao(data);
  }

  // Função de submissão de nova tarefa
  function handleSubmit() {
    if (!titulo) return;
    criar(titulo, descricao);
    setTitulo("");
    setDescricao("");
  }

  return (
    <div className="max-w-xl mx-auto mt-8 space-y-6">
      <div className="max-w-xl mx-auto mt-8">
        {" "}
        <div className="flex gap-4 items-center">
          {" "}
          {/* Input de busca por título */} {/* Buscador */}
          <input
            className="w-2/3 px-4 py-3 rounded-xl border border-slate-300 focus:outline-none focus:ring-2 focus:ring-blue-500 shadow-sm"
            placeholder="🔍 Buscar tarefa por título..."
            value={buscar}
            onChange={(e) => handleSearch(e.target.value)}
          />
          {/* Input de busca por data */}{" "}
          <input
            type="date"
            className="w-1/3 px-4 py-3 rounded-xl border border-slate-300 focus:outline-none focus:ring-2 focus:ring-blue-500 shadow-sm text-sm text-slate-500"
            value={dataCriacao}
            onChange={(e) => handleSearchByDate(e.target.value)}
          />{" "}
        </div>{" "}
      </div>
      {/* Buscar por status */}
      <div className="flex gap-2">
        <button
          onClick={() => buscarStatus(StatusTarefa.Pendente)}
          className={`px-3 py-1 rounded-full text-xs font-medium ${
            status === StatusTarefa.Pendente
              ? "bg-blue-600 text-white"
              : "bg-slate-200 text-slate-700"
          }`}
        >
          Pendente
        </button>
        <button
          onClick={() => buscarStatus(StatusTarefa.Finalizado)}
          className={`px-3 py-1 rounded-full text-xs font-medium ${
            status === StatusTarefa.Finalizado
              ? "bg-green-600 text-white"
              : "bg-slate-200 text-slate-700"
          }`}
        >
          Finalizado
        </button>
      </div>

      {/* Card Minhas Tarefas */}
      <div className="bg-white rounded-2xl shadow p-6 space-y-4">
        <h1 className="text-2xl font-bold text-slate-700 text-center">
          🗂️ Minhas Tarefas
        </h1>
        <input
          className="  w-full
          px-4 py-3
          rounded-xl
          border border-slate-300
          focus:outline-none
          focus:ring-2 focus:ring-blue-500
          shadow-sm"
          placeholder="Título da Tarefa"
          value={titulo}
          onChange={(e) => setTitulo(e.target.value)}
        />
        <textarea
          className="  w-full
          px-4 py-3
          rounded-xl
          border border-slate-300
          focus:outline-none
          focus:ring-2 focus:ring-blue-500
          shadow-sm"
          placeholder="Descrição"
          value={descricao}
          onChange={(e) => setDescricao(e.target.value)}
        />
        {/* Buscar por data de criação */}
        <input
          type="date"
          className="  w-full
          px-4 py-3
          rounded-xl
          border border-slate-300
          focus:outline-none
          focus:ring-2 focus:ring-blue-500
          shadow-sm text-sm text-slate-500"
          value={dataCriacao}
          onChange={(e) => handleSearchByDate(e.target.value)}
        />
        <button
          onClick={handleSubmit}
          className="w-full bg-blue-600 hover:bg-blue-700 text-white font-medium py-3 rounded-xl transition"
        >
          ➕ Adicionar Tarefa
        </button>
        {loading ? (
          <p>Carregando...</p>
        ) : (
          <TarefaList
            tarefas={tarefas}
            onDelete={remover}
            onFinalizar={finalizar}
          />
        )}
      </div>
    </div>
  );
}
