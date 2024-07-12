import { useEffect, useState } from 'react';

function App() {
    const [students, setStudents] = useState();

    useEffect(() => {
        populateStudentsData();
    }, []);

    const contents = students === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        : <table className="table table-striped" aria-labelledby="tableLabel">
            <thead>
                <tr>
                    <th>&nbsp;</th>
                    <th>Name</th>
                    <th>Program</th>
                    <th>Average</th>
                </tr>
            </thead>
            <tbody>
                {students.map(forecast =>
                    <tr key={forecast.Name}>
                        <td>{forecast.Program}</td>
                        <td>{forecast.Average}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            <h1 id="tableLabel">Students</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>
    );

    async function populateStudentsData() {

        fetch('https://localhost:7147/api/Students')
            .then(response => response.json())
            .then(data => console.log(data));
            //.then(json => setStudents(json))
            //.catch(error => console.error(error));

    }

    //async function populateStudentsData() {
    //    const response = await fetch('students');
    //    const data = await response.json();
    //    setStudents(data);
    //}

}

export default App;