import { useContext } from 'react';
import { navContext } from "../App";
import useStudents from "../../Hooks/UseStudents";
import Banner from "../Banner";
import StudentRow from "./StudentRow";
import { DeleteModalProvider } from "../DeleteContext";
import DeleteModal from "../DeleteModal";

const Students = () => {

    const { navigate } = useContext(navContext);
    const { navValues: navValues } = useContext(navContext);
    const { students, addStudent, editStudent, deleteStudent } = useStudents(navigate);

    const contents = students === undefined
        ?
        <>
            <Banner heading="Getting Students..." />
        </>
        :
        <>
            <DeleteModalProvider>
                <DeleteModal></DeleteModal>
                <Banner heading="Students" />
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
                        {students.map(student => <StudentRow key={student.id} student={student} editStudent={editStudent} deleteStudent={deleteStudent} />)}
                    </tbody>
                </table>       
            </DeleteModalProvider>
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