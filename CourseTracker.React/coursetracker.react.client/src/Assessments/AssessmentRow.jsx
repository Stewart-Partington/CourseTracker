
const AssessmentRow = ({ assessment, editAssessment, deleteAssessment }) => {

    const editAssessmentClick = (e) => {
        e.preventDefault();
        editAssessment(assessment.id);
    };

    const deleteAssessmentClick = (e) => {
        e.preventDefault();
        deleteAssessment(assessment.id);
    }

    return (
        <tr>
            <td>
                <a href="" onClick={editAssessmentClick}>Edit</a>
                <a href="" onClick={deleteAssessmentClick} className="ms-1">Delete</a>
            </td>
            <td>{assessment.name}</td>
            <td>{assessment.assessmentTypeDescription}</td>
            <td>{assessment.grade}</td>
            <td>{assessment.weight}</td>
        </tr>
    );

}

export default AssessmentRow;