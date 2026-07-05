import { useEffect, useState } from 'react';
import './App.css';

interface Forecast {
    date: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}

function App() {
    const [page, setPage] = useState<Forecast[]>();

    useEffect(() => {
    }, []);


    return (
        <div>
            <h1 id="tableLabel">Testing</h1>
        </div>
    );

}

export default App;