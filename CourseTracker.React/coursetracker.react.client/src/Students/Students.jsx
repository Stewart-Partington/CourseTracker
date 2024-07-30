import { useContext } from 'react';
import { navContext } from "../App";
import useStudents from "../../Hooks/UseStudents";
import Banner from "../Banner";
import StudentRow from "./StudentRow";
import { bannerContext } from "../App";

const Students = () => {

    const { navigate } = useContext(navContext);
    const { students, banner, addStudent, editStudent } = useStudents(navigate);

    const contents = students === undefined
        ?
        <bannerContext.Provider value={{ banner }} >
            <Banner />
        </bannerContext.Provider>
        :
        <>
            <bannerContext.Provider value={{ banner }} >
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
                    {students.map(student => <StudentRow key={student.id} student={student} editStudent={editStudent} />)}
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