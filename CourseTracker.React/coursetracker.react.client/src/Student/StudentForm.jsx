
const StudentForm = ({ student, setStudent, saveStudent, cancelStudent }) => {

    const onSubmitClick = () => {
        saveStudent(student);
    }

    const onCancelClick = () => {
        cancelStudent();
    }

    var contents = 
        <div className="border p-3">
            <h2>Average: {student.average} %</h2>

            <input type="hidden" id="id" value={student.id}></input>

            <div className="row form-group">
                <div className="col-md-12 fw-bold">
                    <label htmlFor="firstName" className="required">First Name</label>
                </div>
                <div className="col-md-12">
                    
                </div>
                <div className="col-md-12">
                    <input id="firstName" className="form-control w-50" type="text" value={student.firstName}
                        onChange={(e) => setStudent({ ...student, firstName: e.target.value })} />
                </div>
            </div>

            <div className="row form-group">
                <div className="col-md-12 fw-bold">
                    <label htmlFor="lastName" className="required">Last Name</label>
                </div>
                <div className="col-md-12">

                </div>
                <div className="col-md-12">
                    <input id="lastName" className="form-control w-50" type="text" value={student.lastName}
                        onChange={(e) => setStudent({ ...student, lastName: e.target.value })} />
                </div>
            </div>

            <div className="row form-group">
                <div className="col-md-12 fw-bold">
                    <label htmlFor="programName" className="required">Program Name</label>
                </div>
                <div className="col-md-12">

                </div>
                <div className="col-md-12">
                    <input id="programName" className="form-control w-50" type="text" value={student.programName}
                        onChange={(e) => setStudent({ ...student, programName: e.target.value })} />
                </div>
            </div>

            <div className="mt-3">
                <button className="btn btn-primary me-2" onClick={onSubmitClick} >
                    Save
                </button>
                <button className="btn btn-secondary me-2" onClick={onCancelClick} >
                    Cancel
                </button>
                <button className="btn btn-danger">
                    Delete
                </button>
            </div>

        </div>

    return (
        <div className="row">
            <div>
                {contents}
            </div>
        </div>
    );

}

export default StudentForm;