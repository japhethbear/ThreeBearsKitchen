import React from 'react';
import { Link } from 'react-router-dom';
import '../Styles/styles.css'

function HomePage() {
  return (
    <div className="landing-page">
      <header className="header">
        <h1>Welcome to Three Bears Kitchen</h1>
        <p>Your source for delicious recipes!</p>
      </header>
      <section className="hero">
        <div className="hero-image">
          {/* Add your hero image here */}
        </div>
        <div className="hero-text">
          <h2>Discover New Recipes</h2>
          <p>Find and save your favorite recipes with ease.</p>
        </div>
      </section>
      <section className="features">
        <div className="feature">
          {/* Add an icon or image for the feature */}
          <h3>Scrape Recipes</h3>
          <p>Scrape recipes from your favorite websites.</p>
        </div>
        <div className="feature">
          {/* Add an icon or image for the feature */}
          <h3>Save and Share</h3>
          <p>Save recipes and share them as images with friends.</p>
        </div>
        <div className="feature">
          {/* Add an icon or image for the feature */}
          <h3>Mobile-Optimized</h3>
          <p>Enjoy our app on your mobile device anytime, anywhere.</p>
        </div>
      </section>
      <section className="cta">
        <h2>Get Started Today!</h2>
        <p>Join our community of food enthusiasts.</p>
        <Link to="/scrape" className="cta-button">
          Start Scaping
        </Link>
      </section>
    </div>
  );
}

export default HomePage;
