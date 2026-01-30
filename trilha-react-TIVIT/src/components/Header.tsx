export function Header() {
  return (
    <header className="bg-[#0033A0] text-white shadow-md">
      <div className="max-w-6xl mx-auto px-6 py-4 flex items-center justify-between">
        {/* Logo / Nome */}
        <div className="flex items-center gap-2">
          <div
            className="w-10 h-10 rounded-full bg-white text-[#0033A0] 
                          flex items-center justify-center font-bold text-lg"
          >
            B T
          </div>
          <h1 className="text-xl font-semibold tracking-wide">
            BOOTCAMP - TIVIT • Gestão de Tarefas
          </h1>
        </div>

        {/* Ações */}
        <nav className="flex gap-4 text-sm">
          <button className="hover:underline">Tarefas</button>
        </nav>
      </div>
    </header>
  );
}
