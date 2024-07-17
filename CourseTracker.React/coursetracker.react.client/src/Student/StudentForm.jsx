
const StudentForm = ({ student }) => {

    var contents = 
    <>
        <h2>Average: {student.average} %</h2>
    </>

    return (
        <div className="row">
            <div>
                {contents}
            </div>
        </div>
    );

}

export default StudentForm;