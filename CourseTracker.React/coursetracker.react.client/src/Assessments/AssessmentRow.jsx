
const AssessmentRow = ({ assessment, editAssessment }) => {

    const editAssessmentClick = (e) => {
        e.preventDefault();
        editAssessment(assessment.id);
    };

    return (
        <tr>
            <td>
                <a href="" onClick={editAssessmentClick}>Edit</a>
            </td>
            <td>{assessment.name}</td>
            <td>{assessment.assessmentTypeDescription}</td>
            <td>{assessment.grade}</td>
            <td>{assessment.weight}</td>
        </tr>
    );

}

export default AssessmentRow;