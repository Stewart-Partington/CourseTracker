import { useContext, useState } from 'react';
import useStudents from "../../Hooks/UseStudents";
import Banner from "../Banner";
import StudentRow from "./StudentRow";
import NavValues from "../../Helpers/NavValues";
import { navContext } from "../App";
import { bannerContext } from "../App";

const Students = () => {

    const { students, setStudents } = useStudents();
    const { navigate } = useContext(navContext);

    const addStudent = () => {
        navigate(NavValues.student, "00000000-0000-0000-0000-000000000000");
    };

    const [banner, setBanner] = useState("Students");

    const contents = students === undefined
        ?
        <h1>Getting Students...</h1>
        :
        <>
            <bannerContext.Provider value={{ banner, setBanner }} >
                <Banner/>
            </bannerContext.Provider>
            <button className="btn btn-primary" onClick={addStudent} >
                Add Student
            </button>
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
        </>;

    return (
        <div className="row">
            <div>
                {contents}
            </div>
        </div>
    );

}

export default Students;