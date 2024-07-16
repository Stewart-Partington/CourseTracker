import { useContext } from 'react';
import NavValues from "../../Helpers/NavValues";
import { navContext } from "../App";

const StudentRow = ({ student }) => {

    const { navigate } = useContext(navContext);

    const editStudent = (e) => {
        e.preventDefault();
        navigate(NavValues.student, student.id);
    };

	return (
        <tr>
            <td>
                <a href="" onClick={editStudent}>Edit</a>
            </td>
            <td>{student.firstName} {student.lastName}</td>
            <td>{student.programName}</td>
            <td>{student.average}</td>
        </tr>
	);
};

export default StudentRow;