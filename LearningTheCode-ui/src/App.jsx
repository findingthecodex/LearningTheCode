import { useState } from 'react'
import './App.css'

function App() {
  const [view, setView] = useState('home');

  // --- 1. STARTSIDAN ---
  if (view === 'home') {
    return (
        <div className="splash-container">
          <main className="splash-content">
            <div className="logo-wrapper">
              <span className="logo-icon">🚀</span>
              <h1 className="logo-text">Learning<span className="accent">The</span>Code</h1>
            </div>
            <p className="tagline">Ditt första steg mot att lära dig koda.</p>
            <button className="get-started-btn" onClick={() => setView('pick-language')}>
              Börja lära dig nu →
            </button>
          </main>
        </div>
    );
  }

  // --- 2. VÄLJ SPRÅK-SIDAN ---
  if (view === 'pick-language') {
    return (
        <div className="splash-container">
          <main className="splash-content">
            <h2 className="view-title">Vad vill du lära dig idag?</h2>
            <div className="language-grid">
              <div className="language-card highlight" onClick={() => setView('csharp-lessons')}>
                <div className="lang-icon">#️⃣</div>
                <h3>C#</h3>
                <p>Lär dig grunderna i Objektorienterad Programmering</p>
                <button className="select-btn">Välj C#</button>
              </div>
              <div className="language-card disabled">
                <div className="lang-icon">⚛️</div>
                <h3>React</h3>
                <p>Kommer snart...</p>
              </div>
            </div>
            <button className="back-link" onClick={() => setView('home')}>← Gå tillbaka</button>
          </main>
        </div>
    );
  }

  // --- 3. C# LEKTIONS-SIDA ---
  return (
      <div className="splash-container">
        <main className="splash-content">
          <h2 className="view-title">Välkommen till C# Basics</h2>
          <div className="course-content">
            <p>Här börjar din resa. Välj ett kapitel:</p>
            <ul className="chapter-list">
              <li>1. Introduktion till C#</li>
              <li>2. Vad är Variabler?</li>
              <li>3. Klasser och Objekt</li>
            </ul>
          </div>
          <button className="back-link" onClick={() => setView('pick-language')}>← Tillbaka till språk</button>
        </main>
      </div>
  );
}

export default App