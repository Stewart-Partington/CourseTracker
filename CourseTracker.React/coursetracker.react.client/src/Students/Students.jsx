import { useEffect, useState, useContext } from 'react';
import Banner from "../Banner";
import StudentRow from "./StudentRow";
import NavValues from "../../Helpers/NavValues";
import { navContext } from "../App";

const Students = () => {

    const [students, setStudents] = useState();
    const { navigate } = useContext(navContext);

    useEffect(() => {
        populateStudentsData();
    }, []);

    const addStudent = () => {
        navigate(NavValues.student, null);
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
            <button className="btn btn-primary" onClick={addStudent} >
                Add Student
            </button>
        </>;

    return (
        <div className="row">
            <div>
                {contents}
            </div>
        </div>
    );

    async function populateStudentsData() {
        await fetch('/api/students')
            .then(response => response.json())
            .then(json => setStudents(json))
            .catch(error => console.error(error));
    }

}

export default Students;