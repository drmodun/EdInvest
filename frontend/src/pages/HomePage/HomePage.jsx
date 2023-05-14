const HomePage = () => {
  document.querySelector(':root').style.setProperty('--header-background', 'var(--color-blue)');
  document.querySelector(':root').style.setProperty('--header-nav-color', 'white');
  return <div className="headerMargin">Home page</div>;
};

export default HomePage;
