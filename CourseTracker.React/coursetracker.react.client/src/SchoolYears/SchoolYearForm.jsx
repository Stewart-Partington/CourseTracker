import { useState } from 'react';

const SchoolYearForm = ({ schoolYear, setSchoolYear, saveSchoolYear, cancelSchoolYear, schoolYearSaved, errors }) => {

    const onSubmitClick = () => {
        saveSchoolYear(schoolYear);
    }

    var contents =
        <>
            <h2>Average: {schoolYear.average} %</h2>
        <div className="border p-3">

            <div className="row form-group">
                <div className="col-md-12 fw-bold">
                    <label htmlFor="index" className="required">Index</label>
                </div>
                <div className="col-md-12">
                        {errors.index && <div className="text-danger">{errors.index}</div>}
                </div>
                <div className="col-md-12">
                        <input id="index" className="form-control w-50" type="number" value={schoolYear.index}
                            onChange={(e) => setSchoolYear({ ...schoolYear, index: e.target.value })} />
                </div>
            </div>

            <div className="row form-group">
                <div className="col-md-12 fw-bold">
                    <label htmlFor="year" className="required">Year</label>
                </div>
                <div className="col-md-12">
                        {errors.year && <div className="text-danger">{errors.year}</div>}
                </div>
                <div className="col-md-12">
                        <input id="year" className="form-control w-50" type="number" value={schoolYear.year}
                            onChange={(e) => setSchoolYear({ ...schoolYear, year: e.target.value })} />
                </div>
            </div>

            <div className="mt-3">
                <button className="btn btn-primary me-2" onClick={onSubmitClick} >
                    Save
                </button>
                <button className="btn btn-secondary me-2" onClick={cancelSchoolYear} >
                    Cancel
                </button>
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

export default SchoolYearForm;