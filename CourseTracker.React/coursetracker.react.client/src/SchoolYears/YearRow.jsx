
const YearRow = ({ schoolYear, editSchoolYear, deleteSchoolYear }) => {

    const editSchoolYearClick = (e) => {
        e.preventDefault();
        editSchoolYear(schoolYear.id);
    };

    const deleteSchoolYearClick = (e) => {
        e.preventDefault();
        deleteSchoolYear(schoolYear.id);
    }

    return (
        <tr>
            <td>
                <a href="" onClick={editSchoolYearClick}>Edit</a>
                <a href="" onClick={deleteSchoolYearClick} className="ms-1">Delete</a>
            </td>
            <td>{schoolYear.index}</td>
            <td>{schoolYear.year}</td>
            <td>{schoolYear.average}</td>
        </tr>
    );

}

export default YearRow;
