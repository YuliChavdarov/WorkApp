import './App.css';

function App() {

    fetch('https://localhost:44319/api/register', {method: "POST"}).then(res => res.json()).then(data => console.log(data));

  return (
    <div className="App">
      <header className="App-header">
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
      </header>
    </div>
  );
}

export default App;
