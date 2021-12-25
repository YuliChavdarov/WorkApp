import Register from "./components/Register";

function App() {

    let token = 123;

    fetch('https://localhost:44319/api/login', {method: "POST", headers: {"Content-type" : "application/json"}, body: `{"email": "client1234@abv.bg", "password": "ToziOnzi1"}`})
    .then(res => res.json()).then(data => {
        fetch('https://localhost:44319/api/login/clients', {method: "GET", headers: {"Authorization": `Bearer ${data.token}`}}).then(res => console.log(res));
    });

  return (
    <div className="App">
        <Register />
    </div>
  );
}

export default App;
