
const StudentRow = ({ student, editStudent }) => {

    const editStudentClick = (e) => {
        e.preventDefault();
        editStudent(student.id);
    };

	return (
        <tr>
            <td>
                <a href="" onClick={editStudentClick}>Edit</a>
            </td>
            <td>{student.firstName} {student.lastName}</td>
            <td>{student.programName}</td>
            <td>{student.average}</td>
        </tr>
	);
};

export default StudentRow;