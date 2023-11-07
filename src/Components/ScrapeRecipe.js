import React, { useState } from 'react';
import axios from 'axios';
import '../Styles/styles.css'; // Make sure to import your styles

const ScrapeRecipe = () => {
  const [userInputURL, setUserInputURL] = useState('');
  const [scrapedData, setScrapedData] = useState({ title: '', ingredients: [], instructions: [] });

  const handleSubmit = async (event) => {
    event.preventDefault();
    try {
      // Replace with your scraping logic
      const response = await axios.post('/scrape-recipe', { url: userInputURL });
      setScrapedData(response.data);
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <div>
      <div className="header">
        <h1>Three Bears Kitchen</h1>
        <p>Paste a recipe URL to scrape</p>
      </div>
      <div className="hero">
        <div className="hero-image">
          {/* Add your hero image here */}
        </div>
        <div className="hero-text">
          <h2>Scrape a Recipe</h2>
          <p>Paste a recipe URL below to get started.</p>
        </div>
      </div>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          value={userInputURL}
          onChange={(event) => setUserInputURL(event.target.value)}
          placeholder="Enter Recipe URL"
        />
        <button type="submit" className="cta-button">Scrape Recipe</button>
      </form>
      <div className="features">
        <div className="feature">
          <h3>Recipe Title</h3>
          <p>{scrapedData.title}</p>
        </div>
        <div className="feature">
          <h3>Ingredients</h3>
          <ul>
            {scrapedData.ingredients.map((ingredient, index) => (
              <li key={index}>{ingredient}</li>
            ))}
          </ul>
        </div>
        <div className="feature">
          <h3>Instructions</h3>
          <ol>
            {scrapedData.instructions.map((instruction, index) => (
              <li key={index}>{instruction}</li>
            ))}
          </ol>
        </div>
      </div>
    </div>
  );
};

export default ScrapeRecipe;
