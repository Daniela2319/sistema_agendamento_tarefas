export function Footer() {
  return (
    <footer className="mt-12 bg-slate-100 text-slate-600 text-sm py-6">
      <div className="max-w-xl mx-auto flex flex-col md:flex-row justify-between items-center px-4 gap-2">
        <p>© {new Date().getFullYear()} Sistema de Tarefas</p>
        <div className="flex gap-4 items-center">
          <a
            href="https://www.linkedin.com/in/danielavelteredu/"
            target="_blank"
            rel="noopener noreferrer"
            className="flex items-center gap-2 hover:text-blue-600 transition"
          >
            {/* Ícone do LinkedIn (SVG) */}
            <svg
              xmlns="http://www.w3.org/2000/svg"
              fill="currentColor"
              viewBox="0 0 24 24"
              className="w-5 h-5"
            >
              <path
                d="M19 0h-14c-2.76 0-5 2.24-5 
                5v14c0 2.76 2.24 5 5 5h14c2.76 
                0 5-2.24 5-5v-14c0-2.76-2.24-5-5-5zm-11 
                19h-3v-10h3v10zm-1.5-11.27c-.97 
                0-1.75-.79-1.75-1.76s.78-1.76 
                1.75-1.76 1.75.79 1.75 
                1.76-.78 1.76-1.75 1.76zm13.5 
                11.27h-3v-5.6c0-1.34-.03-3.07-1.87-3.07-1.87 
                0-2.16 1.46-2.16 2.97v5.7h-3v-10h2.88v1.37h.04c.4-.75 
                1.37-1.54 2.82-1.54 3.01 0 3.57 1.98 
                3.57 4.55v5.62z"
              />
            </svg>
            My LinkedIn
          </a>
        </div>
      </div>
    </footer>
  );
}
