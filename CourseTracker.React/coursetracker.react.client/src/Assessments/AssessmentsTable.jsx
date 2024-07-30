import useAssessments from "../../Hooks/UseAssessments";
import AssessmentRow from "./AssessmentRow";

const AssessmentsTable = ({ courseId }) => {

	const { assessments, addAssessment, editAssessment } = useAssessments(courseId);

    const contents =
        <>
            <section className="panel panel-default border p-3 mt-3">

                <div className="panel-heading">
                    <h3 className="panel-title">Assessments</h3>
                </div>

                <div className="panel-body">

                    <div className="row mt-3">
                        <div className="col-md-12">
                            <button className="btn btn-primary" onClick={addAssessment}>
                                Add Assessment
                            </button>
                        </div>
                    </div>

                    <div className="table-responsive">
                        <table id="tblAssessments" className="table table-striped">
                            <thead>
                                <tr>
                                    <th>&nbsp;</th>
                                    <th>Name</th>
                                    <th>Type</th>
                                    <th>Grade</th>
                                    <th>Weight</th>
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    assessments != undefined ? assessments.map(assessment => <AssessmentRow key={assessment.id} assessment={assessment} editAssessment={editAssessment} />) : "<tr>loading...</tr>"
                                }
                            </tbody>
                        </table>
                    </div>

                </div>

            </section>

        </>

    return (
        <div className="row">
            <div>
                {contents}
            </div>
        </div>
    );

};

export default AssessmentsTable;