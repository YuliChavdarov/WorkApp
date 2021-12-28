import './styles/App.css';
import Login from "./components/Login";
import Register from "./components/Register";
import { Route, Routes } from 'react-router-dom';
import { AuthProvider } from './contexts/AuthContext';
import PageNotFound from './components/PageNotFound';

function App() {
    return (
        <div className="App">
            <AuthProvider>
                <Routes>
                    <Route path="/login" element={<Login />} />
                    <Route path="/register" element={<Register />} />

                    <Route path="*" element={<PageNotFound />} />
                </Routes>
            </AuthProvider>
        </div>
    );
}

export default App;
