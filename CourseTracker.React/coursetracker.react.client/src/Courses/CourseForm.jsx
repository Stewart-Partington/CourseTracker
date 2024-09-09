import { useState } from 'react';

const CourseForm = ({ course, setCourse, saveCourse, cancelCourse, courseSaved, errors }) => {

    const [notes, setNotes] = useState(course.notes);
    const handleNotesChange = e => {
        course.notes = e.target.value;
        setCourse(course);
        setNotes(e.target.value);
    }

    const onSubmitClick = () => {
        saveCourse(course);
    }

    var contents =
        <>
            <h2>Grade: {course.grade} %</h2>
            <div className="border p-3 row">

                <div className="col-6">

                    <div className="row form-group">
                        <div className="col-md-12 fw-bold">
                            <label htmlFor="name" className="required">Name</label>
                        </div>
                        <div className="col-md-12">
                            {errors.name && <div className="text-danger">{errors.name}</div>}
                        </div>
                        <div className="col-md-12">
                            <input id="name" className="form-control" type="text" value={course.name}
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
                            <input id="semester" className="form-control" type="number" value={course.semester}
                                onChange={(e) => setCourse({ ...course, semester: e.target.value })} />
                        </div>
                    </div>

                </div>

                <div className="col-6">

                    <div className="row form-group">
                        <div className="col-md-12 fw-bold">
                            <label htmlFor="notes">Notes</label>
                        </div>
                        <div className="col-md-12">
                            {errors.notes && <div className="text-danger">{errors.notes}</div>}
                        </div>
                        <div className="col-md-12">
                            <textarea name="notes" className="form-control" rows="5" value={course.notes}
                                onChange={handleNotesChange} ></textarea>
                        </div>
                    </div>

                </div>

                <div className="mt-3">
                    <button className="btn btn-primary me-2" onClick={onSubmitClick} >
                        Save
                    </button>
                    <button className="btn btn-secondary me-2" onClick={cancelCourse} >
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

export default CourseForm;

