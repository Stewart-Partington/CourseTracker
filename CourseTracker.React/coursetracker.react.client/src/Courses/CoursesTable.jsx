import useCourse from "../../Hooks/UseCourses";
import CourseRow from "./CourseRow";

const CoursesTable = ({ schoolYearId }) => {

    const { courses, addCourse, editCourse, deleteCourse } = useCourse(schoolYearId);

	const contents = 
		<>
            <section className="panel panel-default border p-3 mt-3">

                <div className="panel-heading">
                    <h3 className="panel-title">Courses</h3>
                </div>

                <div className="panel-body">

                    <div className="row mt-3">
                        <div className="col-md-12">
                            <button className="btn btn-primary" onClick={addCourse}>
                                Add Course
                            </button>
                        </div>
                    </div>

                    <div className="table-responsive">
                        <table id="tblCourses" className="table table-striped">
                            <thead>
                                <tr>
                                    <th>&nbsp;</th>
                                    <th>Name</th>
                                    <th>Semester</th>
                                    <th>Grade</th>
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    courses != undefined ? courses.map(course => <CourseRow key={course.id} course={course} editCourse={editCourse}
                                        deleteCourse={deleteCourse} />) : "<tr>loading...</tr>"
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

}

export default CoursesTable;