import React from 'react';
import { Routes, Route } from 'react-router-dom';
import ScrapeRecipe from './Components/ScrapeRecipe';
import RecipeDisplay from './Components/RecipeDisplay';
import HomePage from './Components/HomePage';

function App() {
  return (
    <div className="App">
      <Routes>
          <Route path="/scrape" element={<ScrapeRecipe/>} />
          <Route path="/display" element={<RecipeDisplay/>} />
          <Route path="/" element={<HomePage/>} />
      </Routes>
    </div>
  );
}

export default App;
