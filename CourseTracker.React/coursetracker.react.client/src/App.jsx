import React, { useEffect, useState } from 'react';
import Banner from "./Banner";
import StudentRow from "./StudentRow";
import NavValues from "../Helpers/NavValues";

const navContext = React.createContext(NavValues.students);

function App() {
    const [students, setStudents] = useState();

    useEffect(() => {
        populateStudentsData();
    }, []);

    const addStudent = () => {
        setStudents([
            ...students,
            {
                id: 0,
                firstName: "Joe",
                lastName: "Schmoe",
                programName: "PP!",
                average: 72
            }
        ]);
    };

    const contents = students === undefined
        ?
        <Banner bannerText = "Getting Students..." />
        :
        <>
            <Banner bannerText="Students" />
            <table className="table table-striped" aria-labelledby="tableLabel">
                <thead>
                    <tr>
                        <th>&nbsp;</th>
                        <th>Name</th>
                        <th>Program</th>
                        <th>Average</th>
                    </tr>
                </thead>
                <tbody>
                    {students.map(student => <StudentRow key={ student.id} student={student} />)}
                </tbody>
            </table>
            <buttonn className="btn btn-primary" onClick={addStudent} >
                Add Student
            </buttonn>
        </>;

    return (
        <div className="row">
            <div>
                {contents}
            </div>
        </div>
    );

    async function populateStudentsData() {
        fetch('/api/students')
            .then(response => response.json())
            .then(json => setStudents(json))
            .catch(error => console.error(error));
    }

}

export { navContext };
export default App;