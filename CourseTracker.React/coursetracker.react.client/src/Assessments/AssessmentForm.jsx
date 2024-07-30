import { useState } from 'react';

const AssessmentForm = ({ assessment, setAssessment, saveAssessment, cancelAssessment, deleteAssessment, assessmentSaved, errors }) => {

    const [typeOption, setTypeOption] = useState(assessment.assessmentType);
    const typeOptions = [
        { value: "", label: "Please Select" },
        { value: "1", label: "Assignment" },
        { value: "2", label: "Test" },
        { value: "3", label: "Exam" }
    ];
    const handleTypeSelect = e => {
        assessment.assessmentType = parseInt(e.target.value);
        setAssessment(assessment);
        setTypeOption(e.target.value);
    };

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

                <div className="row form-group">
                    <div className="col-md-12 fw-bold">
                        <label htmlFor="assessmentType" className="required">Assessment Type</label>
                    </div>
                    <div className="col-md-12">
                        {errors.assessmentType && <div className="text-danger">{errors.assessmentType}</div>}
                    </div>
                    <div className="col-md-12">
                        <select value={typeOption} onChange={handleTypeSelect} className="form-control w-50">
                            {typeOptions.map((option) => (
                                <option value={option.value}>{option.label}</option>
                            ))}
                            {/*{typeOptions.map((option) => (*/}
                            {/*    <option value={option.value}>{option.label}</option>*/}
                            {/*))}*/}
                        </select>
                    </div>
                </div>

                <div className="row form-group">
                    <div className="col-md-12 fw-bold">
                        <label htmlFor="grade">Grade</label>
                    </div>
                    <div className="col-md-12">
                        {errors.notes && <div className="text-danger">{errors.grade}</div>}
                    </div>
                    <div className="col-md-12">
                        <input id="grade" className="form-control w-50" type="text" value={assessment.grade}
                            onChange={(e) => setAssessment({ ...assessment, grade: e.target.value })} />
                    </div>
                </div>

                <div className="row form-group">
                    <div className="col-md-12 fw-bold">
                        <label htmlFor="weight">Weight</label>
                    </div>
                    <div className="col-md-12">
                        {errors.weight && <div className="text-danger">{errors.weight}</div>}
                    </div>
                    <div className="col-md-12">
                        <input id="weight" className="form-control w-50" type="text" value={assessment.weight}
                            onChange={(e) => setAssessment({ ...assessment, weight: e.target.value })} />
                    </div>
                </div>

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
