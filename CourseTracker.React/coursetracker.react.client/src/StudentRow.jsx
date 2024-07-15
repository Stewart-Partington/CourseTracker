
const StudentRow = ({ student }) => {
	return (
        <tr>
            <td></td>
            <td>{student.firstName} {student.lastName}</td>
            <td>{student.programName}</td>
            <td>{student.average}</td>
        </tr>
	);
};

export default StudentRow;