import { useEffect, useState } from 'react';
import './App.css';


function App() {
    const [page, setPage] = useState<string>();

    const handleClick = () => {
        setPage('test');
    };

    useEffect(() => {
    }, []);


    return (
        <div>
            <h1 id="tableLabel">Testing</h1>
            <button onClick={handleClick}>Click me</button>
            <p>{page}</p>
        </div>
    );

}

export default App;