
const StudentRow = ({ student, editStudent, deleteStudent }) => {

    const editStudentClick = (e) => {
        e.preventDefault();
        editStudent(student.id);
    };

    const deleteStudentClick = (e) => {
        e.preventDefault();
        deleteStudent(student.id);
    };

	return (
        <tr>
            <td>
                <a href="" onClick={editStudentClick}>Edit</a>
                <a href="" onClick={deleteStudentClick} className="ms-1">Delete</a>
            </td>
            <td>{student.firstName} {student.lastName}</td>
            <td>{student.programName}</td>
            <td>{student.average}</td>
        </tr>
	);
};

export default StudentRow;