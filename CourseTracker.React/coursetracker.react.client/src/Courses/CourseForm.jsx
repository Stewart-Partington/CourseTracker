import { useState } from 'react';

const CourseForm = ({ course, setCourse, saveCourse, cancelCourse, deleteCourse, courseSaved, errors }) => {

    const onSubmitClick = () => {
        saveCourse(course);
    }

    const onDeleteClick = () => {
        deleteCourse(course.id);
    }

    var contents =
        <>
            <h2>Grade: {course.grade} %</h2>
            <div className="border p-3">

                <div className="row form-group">
                    <div className="col-md-12 fw-bold">
                        <label htmlFor="name" className="required">Name</label>
                    </div>
                    <div className="col-md-12">
                        {errors.name && <div className="text-danger">{errors.name}</div>}
                    </div>
                    <div className="col-md-12">
                        <input id="name" className="form-control w-50" type="text" value={course.name}
                            onChange={(e) => setCourse({ ...course, name: e.target.value })} />
                    </div>
                </div>

                <div className="row form-group">
                    <div className="col-md-12 fw-bold">
                        <label htmlFor="semester">Semester</label>
                    </div>
                    <div className="col-md-12">
                        {errors.semester && <div className="text-danger">{errors.semester}</div>}
                    </div>
                    <div className="col-md-12">
                        <input id="semester" className="form-control w-50" type="number" value={course.semester}
                            onChange={(e) => setCourse({ ...course, semester: e.target.value })} />
                    </div>
                </div>

                <div className="row form-group">
                    <div className="col-md-12 fw-bold">
                        <label htmlFor="notes">Notes</label>
                    </div>
                    <div className="col-md-12">
                        {errors.notes && <div className="text-danger">{errors.notes}</div>}
                    </div>
                    <div className="col-md-12">
                        <input id="notes" className="form-control w-50" type="text" value={course.notes}
                            onChange={(e) => setCourse({ ...course, notes: e.target.value })} />
                    </div>
                </div>

                <div className="mt-3">
                    <button className="btn btn-primary me-2" onClick={onSubmitClick} >
                        Save
                    </button>
                    <button className="btn btn-secondary me-2" onClick={cancelCourse} >
                        Cancel
                    </button>
                    {courseSaved && (
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

export default CourseForm;

