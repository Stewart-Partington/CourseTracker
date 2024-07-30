import { useState } from 'react';

const AssessmentForm = ({ assessment, setAssessment, saveAssessment, cancelAssessment, deleteAssessment, assessmentSaved, errors }) => {

    const onSubmitClick = () => {
        saveAssessment(assessment);
    }

    const onDeleteClick = () => {
        deleteAssessment(assessment.id);
    }

    var contents =
        <>
            <h2>Grade: {assessment.grade} %</h2>
            <div className="border p-3">

                <div className="row form-group">
                    <div className="col-md-12 fw-bold">
                        <label htmlFor="name" className="required">Name</label>
                    </div>
                    <div className="col-md-12">
                        {errors.name && <div className="text-danger">{errors.name}</div>}
                    </div>
                    <div className="col-md-12">
                        <input id="name" className="form-control w-50" type="text" value={assessment.name}
                            onChange={(e) => setAssessment({ ...assessment, name: e.target.value })} />
                    </div>
                </div>

                {/*<div className="row form-group">*/}
                {/*    <div className="col-md-12 fw-bold">*/}
                {/*        <label htmlFor="semester">Semester</label>*/}
                {/*    </div>*/}
                {/*    <div className="col-md-12">*/}
                {/*        {errors.semester && <div className="text-danger">{errors.semester}</div>}*/}
                {/*    </div>*/}
                {/*    <div className="col-md-12">*/}
                {/*        <input id="semester" className="form-control w-50" type="number" value={assessment.semester}*/}
                {/*            onChange={(e) => setAssessment({ ...assessment, semester: e.target.value })} />*/}
                {/*    </div>*/}
                {/*</div>*/}

                {/*<div className="row form-group">*/}
                {/*    <div className="col-md-12 fw-bold">*/}
                {/*        <label htmlFor="notes">Notes</label>*/}
                {/*    </div>*/}
                {/*    <div className="col-md-12">*/}
                {/*        {errors.notes && <div className="text-danger">{errors.notes}</div>}*/}
                {/*    </div>*/}
                {/*    <div className="col-md-12">*/}
                {/*        <input id="notes" className="form-control w-50" type="text" value={assessment.notes}*/}
                {/*            onChange={(e) => setAssessment({ ...assessment, notes: e.target.value })} />*/}
                {/*    </div>*/}
                {/*</div>*/}

                <div className="mt-3">
                    <button className="btn btn-primary me-2" onClick={onSubmitClick} >
                        Save
                    </button>
                    <button className="btn btn-secondary me-2" onClick={cancelAssessment} >
                        Cancel
                    </button>
                    {assessmentSaved && (
                        <button className="btn btn-danger" onClick={onDeleteClick} >
                            Delete
                        </button>
                    )}
                </div>

            </div>
        </>

    return (
        <div className="row">
            <div>
                {contents}
            </div>
        </div>
    );

}

export default AssessmentForm;
