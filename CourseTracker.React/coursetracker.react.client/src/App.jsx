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
                {students.map(student =>
                    <tr key={student.id}>
                        <td></td>
                        <td>{student.firstName}</td>
                        <td>{student.programName}</td>
                        <td>{student.average}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div className="row">
            <h1 id="tableLabel">Students</h1>
            <p>This component demonstrates fetching data from the server.</p>
            <div>
                {contents}
            </div>
        </div>
    );

    async function populateStudentsData() {
        fetch('https://localhost:7147/api/Students')
            .then(response => response.json())
            .then(json => setStudents(json))
            .catch(error => console.error(error));
    }

}

export default App;