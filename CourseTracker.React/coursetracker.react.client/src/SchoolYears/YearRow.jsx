
const YearRow = ({ schoolYear, editSchoolYear }) => {

    const editSchoolYearClick = (e) => {
        e.preventDefault();
        editSchoolYear(schoolYear.id);
    };

    return (
        <tr>
            <td>
                <a href="" onClick={editSchoolYearClick}>Edit</a>
            </td>
            <td>{schoolYear.index}</td>
            <td>{schoolYear.year}</td>
            <td>{schoolYear.average}</td>
        </tr>
    );

}

export default YearRow;
