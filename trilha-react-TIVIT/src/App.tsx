import { TarefasPage } from "./pages/TarefasPage";
import { Header } from "./components/Header";
import { Footer } from "./components/Footer";

export default function App() {
  return (
    <div className="min-h-screen bg-slate-100">
      <Header />
      <TarefasPage />
      <Footer />
    </div>
  );
}
